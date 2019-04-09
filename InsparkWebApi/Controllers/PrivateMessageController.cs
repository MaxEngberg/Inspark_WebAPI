using InsparkWebApi.Models;
using InsparkWebApi.Repositories;
using InsparkWebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace InsparkWebApi.Controllers
{
    public class PrivateMessageController : ApiController
    {
        private ApplicationDbContext dataContext = new ApplicationDbContext();
        private PrivateMessageRepository privateMessageRepository;
        private ChatRepository chatRepository;

        public PrivateMessageController()
        {
            privateMessageRepository = new PrivateMessageRepository(dataContext);
            chatRepository = new ChatRepository(dataContext);

        }

		// GET: oruinsparkwebapi.azurewebsites.net/Api/PrivateMessage/
		public IEnumerable<PrivateMessage> Get()
        {
            var allPrivateMessages = privateMessageRepository.ShowAll().ToList();
            return allPrivateMessages;
        }

		// POST: oruinsparkwebapi.azurewebsites.net/Api/PrivateMessage/AddPrivateMessage/{chatId}
		[HttpPost]
        public void AddPrivateMessage([FromBody]PrivateMessage privateMessage,[FromUri]int chatId)
        {
            var chat = chatRepository.GetById(chatId);
            var messagesInChat = chat.Messages;
            privateMessageRepository.Add(privateMessage);
			privateMessageRepository.SaveChanges(privateMessage);
			messagesInChat.Add(privateMessage);
			dataContext.SaveChanges();
        }
    }
}