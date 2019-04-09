using InsparkWebApi.Models;
using InsparkWebApi.Repositories.Base;
using InsparkWebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsparkWebApi.Repositories
{
	public class GroupChatRepository : Repository<GroupChat>
	{
		public GroupChatRepository(ApplicationDbContext context) : base(context)
		{

		}
	}
}