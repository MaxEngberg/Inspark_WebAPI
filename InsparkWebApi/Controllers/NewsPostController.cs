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
    public class NewsPostController : ApiController
    {
        private ApplicationDbContext dataContext = new ApplicationDbContext();
        private NewsPostRepository newsPostRepository;
        private UserRepository userRepository;

        public NewsPostController()
        {
            newsPostRepository = new NewsPostRepository(dataContext);
            userRepository = new UserRepository(dataContext);
        }



        // GET: oruinsparkwebapi.azurewebsites.net/api/NewsPost
        public IEnumerable<NewsPost> Get()
        {
            var allGroupPosts = newsPostRepository.ShowAll().ToList();

            return allGroupPosts;
        }

        // GET: oruinsparkwebapi.azurewebsites.net/api/NewsPost/5
        public NewsPost Get(int id)
        {
            var newsPost = newsPostRepository.GetById(id);

            return newsPost;

        }

        // POST: oruinsparkwebapi.azurewebsites.net/api/NewsPost
        [HttpPost]
        public void AddNewsPost([FromBody]NewsPost newsPost)
        {
			newsPostRepository.Add(newsPost);
			newsPostRepository.SaveChanges(newsPost);
		}

        // POST: oruinsparkwebapi.azurewebsites.net/api/NewsPost/AddUserToNewsPostViewed/1/1
        [HttpPost]
		public HttpResponseMessage AddUserToNewsPostViewed(int newsPostId, string userName)
		{
			NewsPost newsPost = newsPostRepository.GetById(newsPostId);
			ApplicationUser user = userRepository.FindByUserName(userName);

			if (newsPost.Views.Contains(user))
			{
				return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Denna användare har redan sett det här.");
			}

			else
			{
				newsPost.Views.Add(user);
				dataContext.SaveChanges();

				return Request.CreateResponse(HttpStatusCode.OK, "Användaren har nu sett posten.");
			}
		}

        // POST: oruinsparkwebapi.azurewebsites.net/api/NewsPost/EditNewsPost
        [HttpPost]
        public HttpResponseMessage EditNewsPost([FromBody]EditNewsPostModel editNewsPostModel)
        {
             NewsPost newsPost = newsPostRepository.GetById(editNewsPostModel.Id);

            if (newsPost == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Group post with id = " + editNewsPostModel.Id.ToString() + "not found");
            }
            else
            {
                newsPost.Title = editNewsPostModel.Title;
                newsPost.Text = editNewsPostModel.Text;
                newsPost.Description = editNewsPostModel.Description;
                newsPost.Picture = editNewsPostModel.Picture;
                newsPost.Pinned = editNewsPostModel.Pinned;
				

                newsPostRepository.SaveChanges(newsPost);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }

        // DELETE: oruinsparkwebapi.azurewebsites.net/api/NewsPost/5
        public void Delete(int id)
        {
            newsPostRepository.Remove(id);
            dataContext.SaveChanges();
        }
    }
}
