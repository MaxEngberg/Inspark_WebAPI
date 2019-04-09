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
    public class GroupController : ApiController
    {
        private ApplicationDbContext dataContext = new ApplicationDbContext();
        private GroupRepository groupRepository;
        private UserRepository userRepository;
        private ActivationCodeRepository codeRepository;
        private GroupChatRepository groupChatRepository;

        public GroupController()
        {
            groupRepository = new GroupRepository(dataContext);
            userRepository = new UserRepository(dataContext);
            codeRepository = new ActivationCodeRepository(dataContext);
            groupChatRepository = new GroupChatRepository(dataContext);

        }


        // GET: oruinsparkwebapi.azurewebsites.net/api/Group
        public IEnumerable<Group> Get()
        {
            var allGroups = groupRepository.ShowAll().ToList();

            return allGroups;
        }

        // GET: oruinsparkwebapi.azurewebsites.net/api/Group/1
        public Group Get(int id)
        {
            var group = groupRepository.GetById(id);

            return group;

        }
		public int GetIdByName(string name)
		{
			var groupId = groupRepository.GetIdByName(name);

			return groupId;
		}

		//GET: oruinsparkwebapi.azurewebsites.net/api/Group/GetGroupsFromSection/1
		[HttpGet]
        public IEnumerable<Group> GetGroupsFromSection(int sectionId)
        {
            var allGroups = groupRepository.SearchFor(s => s.SectionId == sectionId).ToList();

            return (IEnumerable<Group>)allGroups;
        }

        //GET: oruinsparkwebapi.azurewebsites.net/api/Group/GetUsersFromGroup/1
        [HttpGet]
        public IEnumerable<ApplicationUser> GetUsersFromGroup(int groupId)
        {
     
            Group group = groupRepository.GetById(groupId);
            var allUsers = group.Users;

            return allUsers;
        }

        //GET: oruinsparkwebapi.azurewebsites.net/api/Group/GetGroupsFromUser/1
        [HttpGet]
        public IEnumerable<Group> GetGroupsFromUser(string userId)
        {
            IEnumerable<Group> groups = new List<Group>();

            ApplicationUser user = userRepository.GetByIdUser(userId);
            groups = user.Group;
            
            return groups;
        }

        // POST: oruinsparkwebapi.azurewebsites.net/api/Group/AddGroup
        [HttpPost]
        public void AddGroup([FromBody]Group group)
        {
            groupRepository.Add(group);
            groupRepository.SaveChanges(group);
		}

		// POST: oruinsparkwebapi.azurewebsites.net/api/Group/AddUserToGroup/1/2
		[HttpPost]
        public HttpResponseMessage AddUserToGroup(int groupId, string userId)
        {
            Group group = groupRepository.GetById(groupId);
            GroupChatController groupChatController = new GroupChatController();
            var groupChat = group.GroupChat;
            ApplicationUser user = userRepository.GetByIdUser(userId);

            if (group.Users.Contains(user))
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Denna användare är redan med i vald grupp.");
            }

            else {
                user.Group.Add(group);
                group.Users.Add(user);
                dataContext.SaveChanges();
                groupChatController.AddUserToGroupChat(userId, groupChat.Id);
                return Request.CreateResponse(HttpStatusCode.OK, "Användaren inlagd i grupp.");
            }
        }
		[HttpPost]
		public void AddGroupChatToGroup(int groupId, int groupChatId)
		{
			var groupChat = groupChatRepository.GetById(groupChatId);
			var group = groupRepository.GetById(groupId);

			group.GroupChat = groupChat;
			dataContext.SaveChanges();
			
		}

		// POST: oruinsparkwebapi.azurewebsites.net/api/Group/RemoveUserFromGroup/1/2
		[HttpPost]
        public void RemoveUserFromGroup(int groupId, string userId)
        {
            Group group = groupRepository.GetById(groupId);
            ApplicationUser user = userRepository.GetByIdUser(userId);
            user.Group.Remove(group);
            group.Users.Remove(user);
            dataContext.SaveChanges();
        }

        // POST: oruinsparkwebapi.azurewebsites.net/api/Group/AddUserToGroupByCode/123456/1-231231231231
        [HttpPost]
        public HttpResponseMessage AddUserToGroupByCode(string code, string userId)
        {
            ActivationCode codeInfo = codeRepository.GetGroupByCode(code);
            if(codeInfo == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Koden hittades inte. Försök igen.");
            }

            int group = codeInfo.GroupId;
            if (codeInfo.Activated == true)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Kod: " + code + " är redan aktiverad.");
            }

            else
            {
                Group groupID = groupRepository.GetById(group);
                ApplicationUser user = userRepository.GetByIdUser(userId);

                user.Group.Add(groupID);
                groupID.Users.Add(user);
                codeInfo.Activated = true;
                dataContext.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Du är nu inlagd i din introduktionsgrupp.");
            }
        }

        // POST: oruinsparkwebapi.azurewebsites.net/api/Group/EditGroup
        [HttpPost]
        public HttpResponseMessage EditGroup([FromBody]EditGroupModel editGroupModel)
        {
            Group group = groupRepository.GetById(editGroupModel.Id);

                if (group == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Group with id = " + editGroupModel.Id.ToString() + "not found");
                }
                else
                {
                    group.Name = editGroupModel.Name;
                    group.SectionId = editGroupModel.SectionId;
                    group.IsIntroGroup = editGroupModel.IsIntroGroup;

                    groupRepository.SaveChanges(group);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }

        // DELETE: oruinsparkwebapi.azurewebsites.net/api/Group/1
        [HttpDelete]
        public void Delete(int id)
        {
            groupRepository.Remove(id);
            dataContext.SaveChanges();
        }
    }
}
