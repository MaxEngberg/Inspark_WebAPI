using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InsparkWebApi.Models;
using InsparkWebApi.Models.GroupItems;
using InsparkWebApi.Repositories.Base;
using InsparkWebApi.Services;

namespace InsparkWebApi.Repositories
{
    public class GroupRepository : Repository<Group>
    {
        public GroupRepository(ApplicationDbContext context) : base(context)
        {

        }
		public int GetIdByName(string name)
		{
			var groupId = Items.FirstOrDefault(u => u.Name == name).Id;
			return groupId;
		}
	}
}