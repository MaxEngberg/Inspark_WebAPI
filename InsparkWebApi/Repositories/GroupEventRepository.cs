using InsparkWebApi.Models.GroupItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InsparkWebApi.Repositories.Base;
using InsparkWebApi.Services;

namespace InsparkWebApi.Repositories
{
    public class GroupEventRepository : Repository<GroupEvent>
    {
        public GroupEventRepository(ApplicationDbContext context) : base(context)
        {

        }

    }
}