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
    public class AttendingEventController : ApiController
    {
        private ApplicationDbContext dataContext = new ApplicationDbContext();
        private EventRepository eventRepository;
        private AttendingEventRepository attendingEventRepository;
        private UserRepository userRepository;

        public AttendingEventController()
        {
            eventRepository = new EventRepository(dataContext);
            userRepository = new UserRepository(dataContext);
            attendingEventRepository = new AttendingEventRepository(dataContext);
        }

        // GET: oruinsparkwebapi.azurewebsites.net/api/GroupEvent/
        public IEnumerable<AttendingEvent> Get()
        {
            var allAttending = attendingEventRepository.ShowAll().ToList();

            return allAttending;
        }

        // GET: oruinsparkwebapi.azurewebsites.net/api/GroupEvent/1
        public AttendingEvent Get(int id)
        {
            var attending = attendingEventRepository.GetById(id);
            return attending;
        }

        // POST: oruinsparkwebapi.azurewebsites.net/api/GroupEvent/
        [HttpPost]
        public void Post([FromBody]AttendingEvent attendingEvent)
        {
            attendingEventRepository.Add(attendingEvent);
            attendingEventRepository.SaveChanges(attendingEvent);
        }

        // GET: oruinsparkwebapi.azurewebsites.net/api/GroupEvent/Count/
        [HttpGet]
        public int Count(int eventID)
        {
            return attendingEventRepository.SearchFor(e => e.EventId == eventID).Count();
        }

        // GET: oruinsparkwebapi.azurewebsites.net/api/GroupEvent/GetAttendingUsers/
        [HttpGet]
        public IEnumerable<ApplicationUser> GetAttendingUsers(int eventId)
        {
            ICollection<ApplicationUser> users = new List<ApplicationUser>();
            var attendings = attendingEventRepository.SearchFor(s => s.EventId == eventId).ToList();

            foreach (AttendingEvent attending in attendings)
                if (attending.IsComing == true)
                {
                    users.Add(attending.User);
                }

            return users;
        }

        // GET: oruinsparkwebapi.azurewebsites.net/api/GroupEvent/GetAttendingEventsOfUser/
        [HttpGet]
        public IEnumerable<Event> GetAttendingEventsOfUser(string userId)
        {
            ICollection<Event> events = new List<Event>();
            var attendings = attendingEventRepository.SearchFor(s => s.UserId == userId).ToList();
            foreach(AttendingEvent attending in attendings)
            {
                events.Add(attending.Event);
            }

            return events;
        }

        // DELETE: oruinsparkwebapi.azurewebsites.net/api/GroupEvent/1
        public void Delete(int id)
        {
            attendingEventRepository.Remove(id);
            dataContext.SaveChanges();
        }
    }
}
