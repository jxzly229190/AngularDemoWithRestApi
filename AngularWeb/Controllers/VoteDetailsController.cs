using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AngularWeb;

namespace AngularWeb.Controllers
{
    public class VoteDetailsController : ApiController
    {
        private TeamManage_VoteEntities db = new TeamManage_VoteEntities();

        // GET: api/VoteDetails
        public IQueryable<VoteDetail> GetVoteDetails()
        {
            return db.VoteDetails;
        }

        // GET: api/VoteDetails/5
        [ResponseType(typeof(VoteDetail))]
        public IHttpActionResult GetVoteDetail(int id)
        {
            VoteDetail voteDetail = db.VoteDetails.Find(id);
            if (voteDetail == null)
            {
                return NotFound();
            }

            return Ok(voteDetail);
        }

        // PUT: api/VoteDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVoteDetail(int id, VoteDetail voteDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != voteDetail.Id)
            {
                return BadRequest();
            }

            db.Entry(voteDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoteDetailExists(id))
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

        // POST: api/VoteDetails
        [ResponseType(typeof(VoteDetail))]
        public IHttpActionResult PostVoteDetail(VoteDetail voteDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VoteDetails.Add(voteDetail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = voteDetail.Id }, voteDetail);
        }

        // DELETE: api/VoteDetails/5
        [ResponseType(typeof(VoteDetail))]
        public IHttpActionResult DeleteVoteDetail(int id)
        {
            VoteDetail voteDetail = db.VoteDetails.Find(id);
            if (voteDetail == null)
            {
                return NotFound();
            }

            db.VoteDetails.Remove(voteDetail);
            db.SaveChanges();

            return Ok(voteDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VoteDetailExists(int id)
        {
            return db.VoteDetails.Count(e => e.Id == id) > 0;
        }
    }
}