using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InsparkWebApi.Models.GroupItems;
using InsparkWebApi.Repositories.Base;
using InsparkWebApi.Services;

namespace InsparkWebApi.Repositories
{
    public class GroupPostRepository : Repository<GroupPost>
    {
        public GroupPostRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}