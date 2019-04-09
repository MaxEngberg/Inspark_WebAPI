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
    public class GroupEventController : ApiController
    {
        private ApplicationDbContext dataContext = new ApplicationDbContext();
        private GroupEventRepository groupEventRepository;
        private GroupRepository groupRepository;
        private UserRepository userRepository;

        public GroupEventController()
        {
            groupEventRepository = new GroupEventRepository(dataContext);
            groupRepository = new GroupRepository(dataContext);
            userRepository = new UserRepository(dataContext);
        }

        // GET: oruinsparkwebapi.azurewebsites.net/api/GroupEvent/
        public IEnumerable<GroupEvent> Get()
        {
            var allGroupEvents = groupEventRepository.ShowAll().ToList();

            return allGroupEvents;
        }

        // GET: oruinsparkwebapi.azurewebsites.net/api/GroupEvent/1
        public GroupEvent Get(int id)
        {
            var groupEvent = groupEventRepository.GetById(id);
            return groupEvent;
        }

        // POST: oruinsparkwebapi.azurewebsites.net/api/GroupEvent/
        [HttpPost]
        public void AddGroupEvent([FromBody]GroupEvent groupEvent)
        {
            groupEventRepository.Add(groupEvent);
            groupEventRepository.SaveChanges(groupEvent);
        }

        // POST: oruinsparkwebapi.azurewebsites.net/api/GroupEvent/EditGroupEvent
        [HttpPost]
        public HttpResponseMessage EditGroupEvent([FromBody]EditGroupEventModel editGroupEventModel)
        {
            GroupEvent groupEventItem = groupEventRepository.GetById(editGroupEventModel.Id);

            if (groupEventItem == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Group post with id = " + editGroupEventModel.Id.ToString() + "not found");
            }
            else
            {
                groupEventItem.Title = editGroupEventModel.Title;
                groupEventItem.Description = editGroupEventModel.Description;
                groupEventItem.TimeForEvent = editGroupEventModel.TimeForEvent;
                groupEventItem.Location = editGroupEventModel.Location;
                groupEventItem.Picture = editGroupEventModel.Picture;

                groupEventRepository.SaveChanges(groupEventItem);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }

        // DELETE: oruinsparkwebapi.azurewebsites.net/api/GroupEvent/1
        public void Delete(int id)
        {
            groupEventRepository.Remove(id);
            dataContext.SaveChanges();
        }
    }
}
