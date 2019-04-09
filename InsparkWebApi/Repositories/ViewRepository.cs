using InsparkWebApi.Models;
using InsparkWebApi.Repositories.Base;
using InsparkWebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InsparkWebApi.Repositories
{
	public class ViewRepository : Repository<View>
	{
		public ViewRepository(ApplicationDbContext context) : base(context)
		{

		
		}
	}
}