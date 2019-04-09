using InsparkWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InsparkWebApi.Repositories.Base;
using InsparkWebApi.Services;

namespace InsparkWebApi.Repositories
{
    public class SectionRepository : Repository<Section>
    {
        public SectionRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}