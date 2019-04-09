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
    public class AttendingGroupEventController : ApiController
    {
        private ApplicationDbContext dataContext = new ApplicationDbContext();
        private GroupEventRepository groupEventRepository;
        private AttendingGroupEventRepository attendingGroupEventRepository;
        private UserRepository userRepository;

        public AttendingGroupEventController()
        {
            groupEventRepository = new GroupEventRepository(dataContext);
            userRepository = new UserRepository(dataContext);
            attendingGroupEventRepository = new AttendingGroupEventRepository(dataContext);
        }

        // GET: oruinsparkwebapi.azurewebsites.net/api/GroupEvent/
        public IEnumerable<AttendingGroupEvent> Get()
        {
            var allAttending = attendingGroupEventRepository.ShowAll().ToList();

            return allAttending;
        }

        // GET: oruinsparkwebapi.azurewebsites.net/api/GroupEvent/1
        public AttendingGroupEvent Get(int id)
        {
            var attending = attendingGroupEventRepository.GetById(id);
            return attending;
        }

        // POST: oruinsparkwebapi.azurewebsites.net/api/GroupEvent/
        [HttpPost]
        public void Post([FromBody]AttendingGroupEvent attending)
        {
            attendingGroupEventRepository.Add(attending);
            attendingGroupEventRepository.SaveChanges(attending);
        }

        // GET: oruinsparkwebapi.azurewebsites.net/api/GroupEvent/Count
        [HttpGet]
        public int Count(int eventID)
        {
            return attendingGroupEventRepository.SearchFor(e => e.GroupEventId == eventID).ToList().Count();
        }

        // GET: oruinsparkwebapi.azurewebsites.net/api/GroupEvent/GetAttendingUsers
        [HttpGet]
        public IEnumerable<ApplicationUser> GetAttendingUsers (int groupEventId)
        {
            ICollection<ApplicationUser> users = new List<ApplicationUser>();
            var attendings = attendingGroupEventRepository.SearchFor(s => s.GroupEventId == groupEventId).ToList();

            foreach(AttendingGroupEvent attending in attendings)
            if(attending.IsComing == true) 
            {
                users.Add(attending.User);
            }

            return users;
        }

        // GET: oruinsparkwebapi.azurewebsites.net/api/GroupEvent/GetAttendingGroupEventsOfUser
        [HttpGet]
        public IEnumerable<GroupEvent> GetAttendingGroupEventsOfUser(string userId)
        {
            ICollection<GroupEvent> groupEvents = new List<GroupEvent>();
            var attendings = attendingGroupEventRepository.SearchFor(s => s.UserId == userId).ToList();
            foreach (AttendingGroupEvent attending in attendings)
            {
                groupEvents.Add(attending.GroupEvent);
            }

            return groupEvents;
        }

        // DELETE: oruinsparkwebapi.azurewebsites.net/api/GroupEvent/1
        public void Delete(int id)
        {
            attendingGroupEventRepository.Remove(id);
            dataContext.SaveChanges();
        }
    }
}

