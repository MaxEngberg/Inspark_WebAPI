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
	public class GroupChatController : ApiController
	{
		private ApplicationDbContext dataContext = new ApplicationDbContext();
		private GroupChatRepository groupChatRepository;
        private GroupRepository groupRepository;
        private UserRepository userRepository;

        public GroupChatController()
        {
            groupChatRepository = new GroupChatRepository(dataContext);
            groupRepository = new GroupRepository(dataContext);
            userRepository = new UserRepository(dataContext);
        }

		// GET: oruinsparkwebapi.azurewebsites.net/Api/GroupChat
		[HttpGet]
		public IEnumerable<GroupChat> Get()
		{
			var groupChats = groupChatRepository.ShowAll().ToList();
			return groupChats;
		}

		// GET: oruinsparkwebapi.azurewebsites.net/Api/GroupChat/{groupChatID}
		[HttpGet]
		public IEnumerable<GroupChat> Get(int groupChatID)
		{
			var groupChat = groupChatRepository.SearchFor(s => s.Id == groupChatID);
			return groupChat;
		}

		// POST: oruinsparkwebapi.azurewebsites.net/Api/GroupChat/AddUserToGroupChat/{userId}/{groupChatID}
		[HttpPost]
        public void AddUserToGroupChat(string userId, int groupChatId)
        {

            var groupChat = groupChatRepository.GetById(groupChatId);
            var user = userRepository.GetByIdUser(userId);
            user.GroupChats.Add(groupChat);
            groupChat.Users.Add(user);
            dataContext.SaveChanges();
        }

		// POST: oruinsparkwebapi.azurewebsites.net/Api/GroupChat/AddGroupChat
		[HttpPost]
		public void AddGroupChat([FromBody]GroupChat groupChat, int groupId)
		{
			var group = groupRepository.GetById(groupId);
			GroupController gc = new GroupController();
			groupChatRepository.Add(groupChat);

			groupChatRepository.SaveChanges(groupChat);
		}

		// POST: oruinsparkwebapi.azurewebsites.net/Api/GroupChat/RemoveUserFromGroupChatViewed/{chatId}/{userId}
		[HttpPost]
		public void RemoveUsersFromGroupChatViewed(int chatId)
		{
			var groupChat = groupChatRepository.GetById(chatId);
			var groupChatViewed = groupChat.Views;
			groupChatViewed.Clear();
			groupChatRepository.SaveChanges(groupChat);
		}

		// DELETE: oruinsparkwebapi.azurewebsites.net/Api/GroupChat/{groupChatID}
		public void Delete(int groupChatID)
		{
			groupChatRepository.Remove(groupChatID);
			dataContext.SaveChanges();
		}
	}
}