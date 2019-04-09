using InsparkWebApi.Models;
using InsparkWebApi.Repositories.Base;
using InsparkWebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsparkWebApi.Repositories
{
    public class EventRepository : Repository<Event>
    {
        public EventRepository(ApplicationDbContext context) : base(context)
        {

        }

    }
}