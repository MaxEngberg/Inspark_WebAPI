using InsparkWebApi.Models;
using InsparkWebApi.Models.GroupItems;
using InsparkWebApi.Repositories;
using InsparkWebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace InsparkWebApi.Controllers
{
    public class GroupMessageController : ApiController
    {
        private ApplicationDbContext dataContext = new ApplicationDbContext();
        private GroupRepository groupRepository;
        private UserRepository userRepository;
        private GroupMessageRepository groupMessageRepository;
		private GroupChatRepository groupChatRepository;

		public GroupMessageController()
        {
			groupChatRepository = new GroupChatRepository(dataContext);
			groupRepository = new GroupRepository(dataContext);
            userRepository = new UserRepository(dataContext);
            groupMessageRepository = new GroupMessageRepository(dataContext);
        }
		// GET: oruinsparkwebapi.azurewebsites.net/Api/GroupMessage/GetSentMessagesInGroup/{groupId}/{senderId}
		[HttpGet]
        public IEnumerable<GroupMessage> GetSentMessagesInGroup(int groupId, string senderId)
        {
            var sentGroupMessages = groupMessageRepository.SearchFor(s => s.GroupId == groupId & s.Sender.Id == senderId).ToList();

            return (IEnumerable<GroupMessage>)sentGroupMessages;
        }

		// GET: oruinsparkwebapi.azurewebsites.net/Api/GroupMessage/GetRecievedMessagesInGroup/{groupId}/{senderId}
		[HttpGet]
        public IEnumerable<GroupMessage> GetRecievedMessagesInGroup(int groupId, string senderId)
        {
            var recievedGroupMessages = groupMessageRepository.SearchFor(s => s.GroupId == groupId & s.Sender.Id != senderId).ToList();

            return recievedGroupMessages;
        }

		// POST: oruinsparkwebapi.azurewebsites.net/Api/GroupMessage/AddGroupMessage/{chatId}
		[HttpPost]
        public void AddGroupMessage([FromBody]GroupMessage groupMessage, [FromUri]int chatId)
        {
			var groupChat = groupChatRepository.GetById(chatId);
			var messagesInGroupChat = groupChat.GroupMessages;
			groupMessageRepository.Add(groupMessage);
            groupMessageRepository.SaveChanges(groupMessage);
			messagesInGroupChat.Add(groupMessage);
			dataContext.SaveChanges();
		}
    }
}