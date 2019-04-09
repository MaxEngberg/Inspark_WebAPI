using InsparkWebApi.Models;
using InsparkWebApi.Repositories;
using InsparkWebApi.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Http;

namespace InsparkWebApi.Controllers
{   
    public class UserController : ApiController
    {
        private ApplicationDbContext dataContext = new ApplicationDbContext();
        private UserRepository userRepository;

        public UserController()
        {
            userRepository = new UserRepository(dataContext);
        }

        // GET:  oruinsparkwebapi.azurewebsites.net/api/User/
        public IEnumerable<ApplicationUser> Get()
        {
            var allUsers = userRepository.ShowAll().ToList();
            return allUsers;
        }

        // GET:  oruinsparkwebapi.azurewebsites.net/api/User/1
        public ApplicationUser Get(string id)
        {
           var user = userRepository.GetByIdUser(id);
           return user;
        }

        // GET:  oruinsparkwebapi.azurewebsites.net/api/User/GetByUsername/TestPerson
        public ApplicationUser GetByUsername(string userName)
        {
            var user = userRepository.FindByUserName(userName);
            return user;

        }

        // POST: oruinsparkwebapi.azurewebsites.net/api/User
        [HttpPost]
        public HttpResponseMessage Post([FromBody]ApplicationUser user)
        {

            var listOfUsers = userRepository.ShowAll().ToList();
            foreach (var userEmail in listOfUsers)
            {
                if (userEmail.Email == user.Email)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with email = " + user.Email + " already exists.");
                }
            }

            userRepository.Add(user);
            userRepository.SaveChanges(user);

            //var body = "<p>Här är din kod: " + user.ConfirmToken + "\n" + "Var vänlig bekräfta den på: http://localhost:51314/Home/Contact";
            //var message = new MailMessage();
            //message.To.Add(new MailAddress(user.Email));
            //message.From = new MailAddress("inspark-noreplies@outlook.com");
            //message.Subject = "Bekräfta din e-mailadress";
            //message.Body = string.Format(body);
            //message.IsBodyHtml = true;

            //using (var smtp = new SmtpClient())
            //{
               
            //    var credential = new NetworkCredential
            //    {
            //        UserName = "inspark-noreplies@outlook.com",
            //        Password = "Inspark123"
            //    };
            //    smtp.Credentials = credential;
            //    smtp.Host = "smtp-mail.outlook.com";
            //    smtp.Port = 587;
            //    smtp.EnableSsl = true;

            //    await smtp.SendMailAsync(message);
            //}

            return Request.CreateResponse(HttpStatusCode.OK);

        }

        //POST: oruinsparkwebapi.azurewebsites.net/api/User/EditUser
        [HttpPost]
        public HttpResponseMessage EditUser([FromBody]EditUserModel model)
        {
            ApplicationUser user = userRepository.GetByIdUser(model.Id);

            if (user == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User with id = " + model.Id.ToString() + "not found");
            }

            else
            {

                if (model.FirstName != null || model.FirstName != "")
                    user.FirstName = model.FirstName;
                
                if (model.LastName != null || model.LastName != "")
                    user.LastName = model.LastName;

                if (model.ProfilePicture != null)
                    user.ProfilePicture = model.ProfilePicture;

                if (model.PhoneNumber != null || model.PhoneNumber != "")
                    user.PhoneNumber = model.PhoneNumber;

                userRepository.SaveChanges(user);
                return Request.CreateResponse(HttpStatusCode.OK);
            }

        }

        // DELETE:  oruinsparkwebapi.azurewebsites.net/api/User/
        public void Delete(string id)
        {
            userRepository.RemoveUser(id);
            dataContext.SaveChanges();
        }
    }
}
