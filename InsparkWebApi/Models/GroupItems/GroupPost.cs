using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InsparkWebApi.Models.GroupItems
{
    //This class contains the properties for the "GroupPost" model.
    public class GroupPost
    {
		
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Byte[] Picture { get; set; }
		public Byte[] SenderPic { get; set; }
		public bool Pinned { get; set; }
		public string Author { get; set; }

        public Group Group { get; set; }
        public ApplicationUser Sender { get; set; }

		public virtual ICollection<ApplicationUser> Views { get; set; }

		public string SenderId { get; set; }
        public int GroupId { get; set; }

    }
    public class EditGroupPostModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public Byte[] Picture { get; set; }
        public bool Pinned { get; set; }
	}
}