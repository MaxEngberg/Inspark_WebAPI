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
    public class ViewController : ApiController
	{
		private ApplicationDbContext dataContext = new ApplicationDbContext();

		private ViewRepository viewRepository;
		private UserRepository userRepository;
		private ChatRepository chatRepository;
		private GroupChatRepository groupChatRepository;
		public ViewController()
		{
			groupChatRepository = new GroupChatRepository(dataContext);
			chatRepository = new ChatRepository(dataContext);
			viewRepository = new ViewRepository(dataContext);
			userRepository = new UserRepository(dataContext);
		}
		// GET: oruinsparkwebapi.azurewebsites.net/Api/View
		[HttpGet]
		public IEnumerable<View> Get()
		{
			var views = viewRepository.ShowAll().ToList();
			return views;
		}

		// GET: oruinsparkwebapi.azurewebsites.net/Api/View/{ViewviewId}
		[HttpGet]
		public View Get(int viewId)
		{
			var view = viewRepository.GetById(viewId);
			return view;
		}

		// POST: oruinsparkwebapi.azurewebsites.net/Api/View/AddViewToChat/{chatId}
		[HttpPost]
		public void AddViewToChat([FromBody]View view, [FromUri]int chatId)
		{
			var chatViewsList = chatRepository.GetById(chatId).Views;
			viewRepository.Add(view);
			viewRepository.SaveChanges(view);
			chatViewsList.Add(view);
			dataContext.SaveChanges();
		}

		// POST: oruinsparkwebapi.azurewebsites.net/Api/View/AddViewToGroupChat/{groupChatId}
		[HttpPost]
		public void AddViewToGroupChat([FromBody]View view, int groupChatId)
		{
			var groupChatViewsList = groupChatRepository.GetById(groupChatId).Views;
			viewRepository.Add(view);
			viewRepository.SaveChanges(view);
			groupChatViewsList.Add(view);
			dataContext.SaveChanges();
		}

		//DELETE: // POST: oruinsparkwebapi.azurewebsites.net/Api/View/{viewId}
		public void Delete(int viewId)
		{
			viewRepository.Remove(viewId);
			dataContext.SaveChanges();
		}
	}
}