using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

namespace InsparkWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

          
            config.Routes.MapHttpRoute(
                name: "AddUserToGroup",
                routeTemplate: "api/Group/AddUserToGroup/{groupId}/{userId}",
                defaults: new { controller = "Group", action = "AddUserToGroup" }
            );

            config.Routes.MapHttpRoute(
                name: "RemoveUserToGroup",
                routeTemplate: "api/Group/RemoveUserFromGroup/{groupId}/{userId}",
                defaults: new { controller = "Group", action ="RemoveUserFromGroup" }
            );

            config.Routes.MapHttpRoute(
                name: "ReturnCountForGroup",
                routeTemplate: "api/ActivationCode/{action}/{groupId}",
                defaults: new { controller = "ActivationCode"}
           );

           config.Routes.MapHttpRoute(
                name: "GetCodesFromGroup",
                routeTemplate: "api/ActivationCode/GetCodesFromGroup/{groupId}",
                defaults: new { controller = "Group", action = "GetCodesFromGroup" }
            );

            config.Routes.MapHttpRoute(
                name: "GetByUsername",
                routeTemplate: "api/User/GetByUsername/{userName}/",
                defaults: new { controller = "User", action = "GetByUsername" }
            );

            config.Routes.MapHttpRoute(
                name: "AddUserToGroupByCode",
                routeTemplate: "api/Group/AddUserToGroupByCode/{code}/{userId}",
                defaults: new { controller = "Group", action = "AddUserToGroupByCode" }
            );

            config.Routes.MapHttpRoute(
                name: "ConfirmEmail",
                routeTemplate: "api/ConfirmEmail/Validate/{tokenId}",
                defaults: new { controller = "ConfirmEmail", action = "Validate" }
            );

            config.Routes.MapHttpRoute(
                name: "EditUser",
                routeTemplate: "api/User/EditUser/",
                defaults: new { controller = "User", action = "EditUser" }
            );

            config.Routes.MapHttpRoute(
               name: "AddGroup",
               routeTemplate: "api/Group/AddGroup/",
               defaults: new { controller = "Group", action = "AddGroup" }
           );

            config.Routes.MapHttpRoute(
                name: "EditGroup",
                routeTemplate: "api/Group/EditGroup/",
                defaults: new { controller = "Group", action = "EditGroup" }
            );

            config.Routes.MapHttpRoute(
            name: "AddGroupPost",
            routeTemplate: "api/GroupPost/AddGroupPost/",
            defaults: new { controller = "GroupPost", action = "AddGroupPost" }
            );

            config.Routes.MapHttpRoute(
               name: "EditGroupPost",
               routeTemplate: "api/GroupPost/EditGroupPost/",
               defaults: new { controller = "GroupPost", action = "EditGroupPost" }
           );

            config.Routes.MapHttpRoute(
                name: "AddNewsPost",
                routeTemplate: "api/NewsPost/AddNewsPost/",
                defaults: new { controller = "NewsPost", action = "AddNewsPost" }
            );

            config.Routes.MapHttpRoute(
               name: "EditNewsPost",
               routeTemplate: "api/NewsPost/EditNewsPost/",
               defaults: new { controller = "NewsPost", action = "EditNewsPost" }
            );

            config.Routes.MapHttpRoute(
                name: "AddEvent",
                routeTemplate: "api/Event/AddEvent/",
                defaults: new { controller = "Event", action = "AddEvent" }
           );

           config.Routes.MapHttpRoute(
               name: "EditEvent",
               routeTemplate: "api/Event/EditEvent/",
               defaults: new { controller = "Event", action = "EditEvent" }
           );
            //-----------------//
            config.Routes.MapHttpRoute(
               name: "AddGroupEvent",
               routeTemplate: "api/GroupEvent/AddGroupEvent/",
               defaults: new { controller = "GroupEvent", action = "AddGroupEvent" }
          );

            config.Routes.MapHttpRoute(
                name: "EditGroupEvent",
                routeTemplate: "api/GroupEvent/EditGroupEvent/",
                defaults: new { controller = "GroupEvent", action = "EditGroupEvent" }
            );

            config.Routes.MapHttpRoute(
                name: "GetUsersFromGroup",
                routeTemplate: "api/Group/GetUsersFromGroup/{groupId}",
                defaults: new { controller = "Group", action = "GetUsersFromGroup" }
            );

            config.Routes.MapHttpRoute(
                name: "GetGroupsFromSection",
                routeTemplate: "api/Group/GetGroupsFromSection/{sectionId}",
                defaults: new { controller = "Group", action = "GetGroupsFromSection" }
            );
			config.Routes.MapHttpRoute(
                name: "AddUserToNewsPostViewed",
                routeTemplate: "api/NewsPost/AddUserToNewsPostViewed/{newsPostId}/{userName}",
                defaults: new { controller = "NewsPost", action = "AddUserToNewsPostViewed" }
            );
			config.Routes.MapHttpRoute(
				name: "AddUserToGroupPostViewed",
				routeTemplate: "api/GroupPost/AddUserToGroupPostViewed/{groupPostId}/{userName}",
				defaults: new { controller = "GroupPost", action = "AddUserToGroupPostViewed" }
			);

            config.Routes.MapHttpRoute(
                name: "AddPrivateMessage",
                routeTemplate: "api/PrivateMessage/AddPrivateMessage/{chatId}/",
                defaults: new { controller = "PrivateMessage", action = "AddPrivateMessage" }
            );
            config.Routes.MapHttpRoute(
                name: "GetMessagesInChat",
                routeTemplate: "api/Chat/GetMessagesInChat/{chatId}/",
                defaults: new { controller = "Chat", action = "GetMessagesInChat" }
            );
                config.Routes.MapHttpRoute(
                name: "GetSentMessagesInGroup",
                routeTemplate: "api/GroupMessage/GetSentMessagesInGroup/{groupId}/{senderID}",
                defaults: new { controller = "GroupMessage", action = "GetSentMessagesInGroup" }
            );

            config.Routes.MapHttpRoute(
                name: "GetRecievedMessagesInGroup",
                routeTemplate: "api/GroupMessage/GetRecievedMessagesInGroup/{groupId}/{senderId}",
                defaults: new { controller = "groupMessage", action = "GetRecievedMessagesInGroup" }
            );
            config.Routes.MapHttpRoute(
                name: "AddGroupMessage",
                routeTemplate: "api/GroupMessage/AddGroupMessage/",
                defaults: new { controller = "GroupMessage", action = "AddGroupMessage" }
            );

            config.Routes.MapHttpRoute(
                name: "CountForEvent",
                routeTemplate: "api/AttendingEvent/Count/{eventID}",
                defaults: new { controller = "AttendingEvent", action = "Count" }
            );

            config.Routes.MapHttpRoute(
                name: "CountForGroupEvent",
                routeTemplate: "api/AttendingGroupEvent/Count/{eventID}",
                defaults: new { controller = "AttendingGroupEvent", action = "Count" }
            );

            config.Routes.MapHttpRoute(
                name: "GetGroupsFromUser",
                routeTemplate: "api/Group/GetGroupsFromUser/{userId}",
                defaults: new { controller = "Group", action = "GetGroupsFromUser" }
            );

            config.Routes.MapHttpRoute(
                name: "GetAttendingUsersForGroup",
                routeTemplate: "api/AttendingGroupEvent/GetAttendingUsers/{groupEventId}",
                defaults: new { controller = "AttendingGroupEvent", action = "GetAttendingUsers" }
            );

            config.Routes.MapHttpRoute(
                name: "GetAttendingUsersForEvent",
                routeTemplate: "api/AttendingEvent/GetAttendingUsers/{eventId}",
                defaults: new { controller = "AttendingEvent", action = "GetAttendingUsers" }
            );
            config.Routes.MapHttpRoute(
               name: "GetAttendingEventsOfUser",
               routeTemplate: "api/AttendingEvent/GetAttendingEventsOfUser/{userId}",
               defaults: new { controller = "AttendingEvent", action = "GetAttendingEventsOfUser" }
           );
            config.Routes.MapHttpRoute(
               name: "GetAttendingGroupEventsOfUser",
               routeTemplate: "api/AttendingGroupEvent/GetAttendingGroupEventsOfUser/{userId}",
               defaults: new { controller = "AttendingGroupEvent", action = "GetAttendingGroupEventsOfUser" }
           );
            config.Routes.MapHttpRoute(
              name: "GetSingleChat",
              routeTemplate: "api/Chat/GetSingleChat/{chatId}",
              defaults: new { controller = "Chat", action = "GetSingleChat" }
          );

            config.Routes.MapHttpRoute(
             name: "AddUsersToChat",
             routeTemplate: "api/Chat/AddUsersToChat/{userId1}/{userId2}/{chatId}",
             defaults: new { controller = "Chat", action = "AddUsersToChat" }
         );
            config.Routes.MapHttpRoute(
             name: "CreateChat",
             routeTemplate: "api/Chat/CreateChat/{userId1}/{userId2}",
             defaults: new { controller = "Chat", action = "CreateChat" }
         );
            config.Routes.MapHttpRoute(
             name: "GetChattsByUser",
             routeTemplate: "api/Chat/GetChattsByUser/{userId}/",
             defaults: new { controller = "Chat", action = "GetChattsByUser" }
         );

            config.Routes.MapHttpRoute(
             name: "EditResult",
             routeTemplate: "api/Result/EditResult/",
             defaults: new { controller = "Result", action = "EditResult" }
         );
            config.Routes.MapHttpRoute(
           name: "AddUserToGroupChat",
           routeTemplate: "api/GroupChat/AddUserToGroupChat/{userId}/{groupChatId}",
           defaults: new { controller = "GroupChat", action = "AddUserToGroupChat" }
		);
			config.Routes.MapHttpRoute(
			name: "AddViewToGroupChat",
			routeTemplate: "api/View/AddViewToGroupChat/{chatId}",
			defaults: new { controller = "View", action = "AddViewToGroupChat" }
		);
			config.Routes.MapHttpRoute(
			name: "AddViewToChat",
			routeTemplate: "api/View/AddViewToChat/{chatId}",
			defaults: new { controller = "View", action = "AddViewToChat" }
		);
			config.Routes.MapHttpRoute(
			name: "RemoveUsersFromChatViewed",
			routeTemplate: "api/Chat/RemoveUsersFromChatViewed/{chatId}",
			defaults: new { controller = "Chat", action = "RemoveUsersFromChatViewed" }
		);
			config.Routes.MapHttpRoute(
			name: "RemoveUsersFromGroupChatViewed",
			routeTemplate: "api/GroupChat/RemoveUsersFromGroupChatViewed/{chatId}",
			defaults: new { controller = "GroupChat", action = "RemoveUsersFromGroupChatViewed" }
		);
			config.Routes.MapHttpRoute(
			name: "GetIdByName",
			routeTemplate: "api/Group/GetIdByName/{name}",
			defaults: new { controller = "Group", action = "GetIdByName" }
		);
			config.Routes.MapHttpRoute(
			name: "AddGroupChat",
			routeTemplate: "api/GroupChat/AddGroupChat/{groupId}",
			defaults: new { controller = "GroupChat", action = "AddGroupChat" }
		);
			config.Routes.MapHttpRoute(
			name: "AddGroupChatToGroup",
			routeTemplate: "api/Group/AddGroupChatToGroup/{groupId}/{groupChatId}",
			defaults: new { controller = "Group", action = "AddGroupChatToGroup" }
		);
			
			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);
		}
    }
}
