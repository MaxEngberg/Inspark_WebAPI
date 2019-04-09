using InsparkWebApi.Models;
using InsparkWebApi.Repositories;
using InsparkWebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;


namespace InsparkWebApi.Controllers
{
    public class ChatController : ApiController
    {
        private ApplicationDbContext dataContext = new ApplicationDbContext();
        private ChatRepository chatRepository;
        private UserRepository userRepository;
		private ViewRepository viewRepository;
		private PrivateMessageRepository privateMessageRepository;

        public ChatController()
        {
			viewRepository = new ViewRepository(dataContext);
			chatRepository = new ChatRepository(dataContext);
            userRepository = new UserRepository(dataContext);
            privateMessageRepository = new PrivateMessageRepository(dataContext);

        }

		// GET: oruinsparkwebapi.azurewebsites.net/Api/Chat/getChattsByUser/{userId}
		[HttpGet]
        public IEnumerable<Chat> getChattsByUser(string userId)
        {
            var user = userRepository.GetByIdUser(userId);
            var chats = chatRepository.ShowAll().Where(c => c.Users.Contains(user));

            return chats;
        }

		// GET: oruinsparkwebapi.azurewebsites.net/Api/Chat/GetSingleChat/{chatId}
		[HttpGet]
        public IEnumerable<Chat> GetSingleChat(int chatID)
        {
            var chat = chatRepository.SearchFor(s => s.Id == chatID);
            return chat;
        }

		// GET: oruinsparkwebapi.azurewebsites.net/Api/Chat/GetMessagesInChat/{chatId}
		[HttpGet]
        public IEnumerable<PrivateMessage> GetMessagesInChat(int chatId)
        {
            var allMessages = chatRepository.GetById(chatId).Messages;
            return allMessages;
        }

		// POST: oruinsparkwebapi.azurewebsites.net/Api/Chat/GetMessagesInChat/{userId1}/{userId2}/{chatId}
		[HttpPost]
        public void AddUsersToChat(string userId1, string userId2, int chatId)
        {

            var chat = chatRepository.GetById(chatId);
            var user1 = userRepository.GetByIdUser(userId1);
            var user2 = userRepository.GetByIdUser(userId2);
            user1.Chats.Add(chat);
            user2.Chats.Add(chat);
            chat.Users.Add(user1);
            chat.Users.Add(user2);
            dataContext.SaveChanges();
        }

		// POST: oruinsparkwebapi.azurewebsites.net/Api/Chat/CreateChat/{userId1}/{userId2}
		[HttpPost]
        public void CreateChat([FromUri]string userId1, [FromUri] string userId2 )
		{
            Chat chat = new Chat();
            chatRepository.Add(chat);
			chatRepository.SaveChanges(chat);
            Thread.Sleep(500);
			AddUsersToChat(userId1, userId2, chat.Id);
        }

		// POST: oruinsparkwebapi.azurewebsites.net/Api/Chat/RemoveUserFromChatViewed/{chatId}
		public void RemoveUsersFromChatViewed(int chatId)
		{
			var chat = chatRepository.GetById(chatId);
			var chatViewed = chat.Views;
			//viewRepository.GetById();
			chatViewed.Clear();
			chatRepository.SaveChanges(chat);
		}

		// DELETE: oruinsparkwebapi.azurewebsites.net/Api/Chat/{chatId}
		public void Delete(int chatID)
		{
			chatRepository.Remove(chatID);
			dataContext.SaveChanges();
		}
	}
}