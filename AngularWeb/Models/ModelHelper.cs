using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AngularWeb;

namespace TeamManager.Models
{
    public class ModelHelper
    {
        public static VoteItemModel TransferToVoteItemModel(VoteItem item)
        {
            var model = new VoteItemModel()
            {
                Id = item.Id,
                PId = item.PId,
                Comment = item.Comment,
                CreatedBy = item.CreatedBy,
                CreatedTime = item.CreatedTime,
                Members = item.Nominees,
                Nominator = item.Nominator,
                Name = item.Name,
                State = item.State,
                ModifiedBy = item.ModifiedBy,
                ModifiedTime = item.ModifiedTime
            };

            return model;
        }

        public static VoteItem TransferToVoteItem(VoteItemModel model)
        {
            var item = new VoteItem()
            {
                Id = model.Id,
                PId = model.PId,
                Comment = model.Comment,
                CreatedBy = model.CreatedBy,
                CreatedTime = model.CreatedTime,
                Nominees = model.Members,
                Nominator = model.Nominator,
                Name = model.Name,
                State = model.State,
                ModifiedBy = model.ModifiedBy,
                ModifiedTime = model.ModifiedTime
            };

            return item;
        }
    }
}