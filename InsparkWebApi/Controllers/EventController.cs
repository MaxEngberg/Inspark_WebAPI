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
    public class EventController : ApiController
    {
        private ApplicationDbContext dataContext = new ApplicationDbContext();
        private EventRepository eventRepository;
        private UserRepository userRepository;

        public EventController()
        {
            eventRepository = new EventRepository(dataContext);
            userRepository = new UserRepository(dataContext);
        }

        // GET: oruinsparkwebapi.azurewebsites.net/api/GroupEvent/
        public IEnumerable<Event> Get()
        {
            var allEvents = eventRepository.ShowAll().ToList();

            return allEvents;
        }

        // GET: oruinsparkwebapi.azurewebsites.net/api/GroupEvent/1
        public Event Get(int id)
        {
            var evenT = eventRepository.GetById(id);
            return evenT;
        }

        // POST: oruinsparkwebapi.azurewebsites.net/api/GroupEvent/
        [HttpPost]
        public void AddEvent([FromBody]Event eventItem)
        {
            eventRepository.Add(eventItem);
            eventRepository.SaveChanges(eventItem);
        }

        [HttpPost]
        // POST: oruinsparkwebapi.azurewebsites.net/api/GroupEvent/EditEvent/
        public HttpResponseMessage EditEvent([FromBody]EditEventModel editEventModel)
        {
            Event eventItem = eventRepository.GetById(editEventModel.Id);

            if (eventItem == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Group post with id = " + editEventModel.Id.ToString() + "not found");
            }
            else
            {
                eventItem.Title = editEventModel.Title;
                eventItem.Description = editEventModel.Description;
                eventItem.TimeForEvent = editEventModel.TimeForEvent;
                eventItem.Location = editEventModel.Location;
                eventItem.Picture = editEventModel.Picture;

                eventRepository.SaveChanges(eventItem);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }

        // DELETE: oruinsparkwebapi.azurewebsites.net/api/GroupEvent/1
        public void Delete(int id)
        {
            eventRepository.Remove(id);
            dataContext.SaveChanges();
        }
    }
}
