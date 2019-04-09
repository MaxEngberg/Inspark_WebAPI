using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InsparkWebApi.Models
{
	public class Chat
	{
        public Chat()
        {	
            Users = new  HashSet<ApplicationUser>();
			Views = new HashSet<View>();
			Messages = new HashSet<PrivateMessage>();
        }
		[Key]
		public int Id { get; set; }
		public virtual ICollection<View> Views { get; set; }
		public virtual ICollection<ApplicationUser> Users { get; set; }
		public virtual ICollection<PrivateMessage> Messages { get; set; }
	}
}