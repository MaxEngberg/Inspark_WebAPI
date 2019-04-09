using InsparkWebApi.Models;
using InsparkWebApi.Models.GroupItems;
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
    public class GroupPostController : ApiController
    {
        private ApplicationDbContext dataContext = new ApplicationDbContext();
        private GroupPostRepository groupPostRepository;
        private GroupRepository groupRepository;
        private UserRepository userRepository;

        public GroupPostController()
        {
            groupPostRepository = new GroupPostRepository(dataContext);
            groupRepository = new GroupRepository(dataContext);
            userRepository = new UserRepository(dataContext);
        }


        // GET: oruinsparkwebapi.azurewebsites.net/api/GroupEvent
        public IEnumerable<GroupPost> Get()
        {
            var allGroupPosts = groupPostRepository.ShowAll().ToList();

            return allGroupPosts;
        }

        // GET: oruinsparkwebapi.azurewebsites.net/api/GroupEvent/5
        public GroupPost Get(int id)
        {
            var groupPost = groupPostRepository.GetById(id);

            return groupPost;

        }

        // POST: oruinsparkwebapi.azurewebsites.net/api/GroupPost
        [HttpPost]
        public void AddGroupPost([FromBody]GroupPost groupPost)
		{ 
            groupPostRepository.Add(groupPost);
			groupPostRepository.SaveChanges(groupPost);
		}

		[HttpPost]
        // POST: oruinsparkwebapi.azurewebsites.net/api/GroupPost/AddUserToGroupPostViewed/1/2
        public HttpResponseMessage AddUserToGroupPostViewed(int groupPostId, string userName)
		{
			GroupPost groupPost = groupPostRepository.GetById(groupPostId);
			ApplicationUser user = userRepository.FindByUserName(userName);

			if (groupPost.Views.Contains(user))
			{
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Denna användare har redan sett det här.");
			}

			else
			{
				groupPost.Views.Add(user);
				dataContext.SaveChanges();

				return Request.CreateResponse(HttpStatusCode.OK, "Användaren har nu sett posten.");
			}
		}

		[HttpPost]
        // POST: oruinsparkwebapi.azurewebsites.net/api/GroupPost/EditGroupPost
        public HttpResponseMessage EditGroupPost([FromBody]EditGroupPostModel editGroupPostModel)
        {
            GroupPost groupPost = groupPostRepository.GetById(editGroupPostModel.Id);

            if (groupPost == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Group post with id = " + editGroupPostModel.Id.ToString() + "not found");
            }
            else
            {
                groupPost.Title = editGroupPostModel.Title;
                groupPost.Text = editGroupPostModel.Text;
                groupPost.Description = editGroupPostModel.Description;
                groupPost.Picture = editGroupPostModel.Picture;
                groupPost.Pinned = editGroupPostModel.Pinned;
				

                groupPostRepository.SaveChanges(groupPost);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }

        // DELETE: oruinsparkwebapi.azurewebsites.net/api/Group/5
        public void Delete(int id)
        {
            groupPostRepository.Remove(id);
            dataContext.SaveChanges();
        }
    }
}
