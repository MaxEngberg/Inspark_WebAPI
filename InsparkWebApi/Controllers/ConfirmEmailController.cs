using InsparkWebApi.Repositories;
using InsparkWebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace InsparkWebApi.Controllers
{
   
    public class ConfirmEmailController : ApiController
    {
        private ApplicationDbContext dataContext = new ApplicationDbContext();
        private UserRepository userRepository;

        public ConfirmEmailController()
        {
            userRepository = new UserRepository(dataContext);
        }

        // POST: oruinsparkwebapi.azurewebsites.net/api/ConfirmEmail/Validate/1
        [HttpPost]
        public HttpResponseMessage Validate(string tokenId)
        {
            var listOfUsers = userRepository.ShowAll().ToList();
            foreach (var user in listOfUsers)
            {
                if (tokenId == user.ConfirmToken && user.IsEmailConfirmed == false)
                {
                    user.IsEmailConfirmed = true;
                    dataContext.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, "Token is OK! Email validated.");
                }
            }

            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "This token is invalid. Please try again.");
        }

    }
}
