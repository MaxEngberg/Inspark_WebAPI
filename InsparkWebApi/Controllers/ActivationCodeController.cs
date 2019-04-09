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
    public class ActivationCodeController : ApiController
    {
        private ApplicationDbContext dataContext = new ApplicationDbContext();
        private ActivationCodeRepository codeRepository;
        private GroupRepository groupRepository;

        public ActivationCodeController()
        {
            codeRepository = new ActivationCodeRepository(dataContext);
            groupRepository = new GroupRepository(dataContext);
        }

        // POST: oruinsparkwebapi.azurewebsites.net/api/ActivationCode
        [HttpPost]
        public void Post([FromBody]ActivationCode code)
        {
            codeRepository.Add(code);
            codeRepository.SaveChanges(code);
        }

        // GET: oruinsparkwebapi.azurewebsites.net/api/ActivationCode/ReturnCountForGroup/1
        [HttpGet]
        public int ReturnCountForGroup(int groupId)
        {
            return codeRepository.Count(groupId);
        }

        // GET: oruinsparkwebapi.azurewebsites.net/api/ActivationCode/GetCodesFromGroup/1
        [HttpGet]
        public IEnumerable<ActivationCode> GetCodesFromGroup(int groupId)
        {
            var allCodes = codeRepository.SearchFor(g => g.GroupId == groupId).ToList();
            return (IEnumerable<ActivationCode>)allCodes;
        }
    }
}
