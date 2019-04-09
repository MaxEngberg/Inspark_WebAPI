using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using InsparkWebApi.Models.GroupItems;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json;

namespace InsparkWebApi.Models
{
    //This class contains the properties for the "ApplicationUser" model.
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
                this.Group = new HashSet<Group>();
               
                GroupMessageSender = new HashSet<GroupMessage>();
				IsEmailConfirmed = false;
                ConfirmToken = ReplaceCharacters("+", "/", "=");
		}
        
        public string Section { get; set; }
        public string Role { get; set; }

        public bool IsEmailConfirmed { get; set; }
        public string ConfirmToken { get; set; }
        public byte[] ProfilePicture { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

		public virtual ICollection<Group> Group { get; set; }
		public virtual ICollection<Chat> Chats { get; set; }
		public virtual ICollection<GroupChat> GroupChats { get; set; }

		
        [JsonIgnore]
        public virtual ICollection<GroupMessage> GroupMessageSender { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        public string ReplaceCharacters(string a, string b, string c)
        {
            string input = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            string inputOne = input.Replace(a, "f");
            string inputTwo = inputOne.Replace(b, "e");
            string inputThree = inputTwo.Replace(c, "a");
            return inputThree;
        }
    } 
}