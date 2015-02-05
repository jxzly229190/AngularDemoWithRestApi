using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace AngularWeb.Controllers
{
    public class VoteProjectsController : ApiController
    {
        private TeamManage_VoteEntities db = new TeamManage_VoteEntities();

        // GET: api/VoteProjects
        public IQueryable<VoteProject> GetVoteProjects(int ps=10,int pi=1)
        {
            return db.VoteProjects.OrderBy(p=>p.State).ThenByDescending(p=>p.Id).Skip(ps*(pi-1)).Take(ps);
        }
        
        // GET: api/VoteProjects/5
        [ResponseType(typeof(VoteProject))]
        public IHttpActionResult GetVoteProject(int id)
        {
            VoteProject voteProject = db.VoteProjects.Find(id);
            if (voteProject == null)
            {
                return NotFound();
            }

            return Ok(voteProject);
        }

        // PUT: api/VoteProjects/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVoteProject(int id, VoteProject voteProject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != voteProject.Id)
            {
                return BadRequest();
            }

            db.Entry(voteProject).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoteProjectExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/VoteProjects
        [ResponseType(typeof(VoteProject))]
        public IHttpActionResult PostVoteProject(VoteProject voteProject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VoteProjects.Add(voteProject);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = voteProject.Id }, voteProject);
        }

        // DELETE: api/VoteProjects/5
        [ResponseType(typeof(VoteProject))]
        public IHttpActionResult DeleteVoteProject(int id)
        {
            VoteProject voteProject = db.VoteProjects.Find(id);
            if (voteProject == null)
            {
                return NotFound();
            }

            db.VoteProjects.Remove(voteProject);
            db.SaveChanges();

            return Ok(voteProject);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VoteProjectExists(int id)
        {
            return db.VoteProjects.Count(e => e.Id == id) > 0;
        }
    }
}