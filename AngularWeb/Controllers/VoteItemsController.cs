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
using TeamManager.Models;

namespace AngularWeb.Controllers
{
    public class VoteItemsController : ApiController
    {
        private TeamManage_VoteEntities db = new TeamManage_VoteEntities();

        // GET: api/VoteItems
        public IList<VoteItemModel> GetVoteItems(int pid)
        {
            //Get the VoteItems
            var voteItems = db.VoteItems.Where(vi => vi.PId == pid && vi.State == 0).ToList();
            var userId = User.Identity.Name.Split(',')[0];
            var voteDetails = db.VoteDetails.Where(d => d.State == 0 && d.PId == pid);

            var itemModels = new List<VoteItemModel>();
            foreach (var i in voteItems)
            {
                var itemModel = ModelHelper.TransferToVoteItemModel(i);

                itemModel.IsSelected = voteDetails.FirstOrDefault(d => d.IId == i.Id && d.Voter == userId) != null;
                itemModel.PreSelected = itemModel.IsSelected;
                itemModel.Count = voteDetails.Count(d => d.IId == i.Id);

                itemModels.Add(itemModel);
            }
            return itemModels;
        }

        // GET: api/VoteItems/5
        [ResponseType(typeof(VoteItem))]
        public IHttpActionResult GetVoteItem(int id)
        {
            VoteItem voteItem = db.VoteItems.Find(id);
            if (voteItem == null)
            {
                return NotFound();
            }

            return Ok(voteItem);
        }

        // PUT: api/VoteItems/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVoteItem(int id, VoteItem voteItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != voteItem.Id)
            {
                return BadRequest();
            }

            db.Entry(voteItem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoteItemExists(id))
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

        // POST: api/VoteItems
        [ResponseType(typeof(VoteItem))]
        public IHttpActionResult PostVoteItem(VoteItem voteItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VoteItems.Add(voteItem);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = voteItem.Id }, voteItem);
        }

        // DELETE: api/VoteItems/5
        [ResponseType(typeof(VoteItem))]
        public IHttpActionResult DeleteVoteItem(int id)
        {
            VoteItem voteItem = db.VoteItems.Find(id);
            if (voteItem == null)
            {
                return NotFound();
            }

            db.VoteItems.Remove(voteItem);
            db.SaveChanges();

            return Ok(voteItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VoteItemExists(int id)
        {
            return db.VoteItems.Count(e => e.Id == id) > 0;
        }
    }
}