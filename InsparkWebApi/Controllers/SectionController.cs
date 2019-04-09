using InsparkWebApi.Models;
using InsparkWebApi.Repositories;
using InsparkWebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InsparkWebApi.Controllers
{
    public class SectionController : ApiController
    {
        private ApplicationDbContext dataContext = new ApplicationDbContext();
        private SectionRepository sectionRepository;

        public SectionController()
        {
            sectionRepository = new SectionRepository(dataContext);
        }

        // GET:  oruinsparkwebapi.azurewebsites.net/api/Section
        [HttpGet]
        public IEnumerable<Section> Get()
        {
            var allSections = sectionRepository.ShowAll().ToList();
            return allSections;
        }
    }
}
