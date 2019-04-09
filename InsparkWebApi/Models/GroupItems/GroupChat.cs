using InsparkWebApi.Models.GroupItems;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InsparkWebApi.Models
{
	public class GroupChat
	{
		public GroupChat ()
			{
			Users = new HashSet<ApplicationUser>();
			Views = new HashSet<View>();
			GroupMessages = new HashSet<GroupMessage>();
			}
		[Key]
		public int Id { get; set; }
		public string GroupName { get; set; }
        public byte[] GroupChatPic { get; set; }
		public virtual ICollection<View> Views { get; set; }
		public virtual ICollection<ApplicationUser> Users { get; set; }
		public virtual ICollection<GroupMessage> GroupMessages { get; set; }
	}
}