using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InsparkWebApi.Models.GroupItems
{
    //This class contains the properties for the "Group" model.
    public class Group
    {
        public Group()
        {
            this.Users = new HashSet<ApplicationUser>();
            this.Result = new Result();
            this.GroupChat = new GroupChat();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsIntroGroup { get; set; }

        public byte[] GroupPic { get; set; }
        public virtual Result Result { get; set; }
        public int ResultId { get; set; }
        public virtual Section Section { get; set; }
        public int SectionId { get; set; }
        public virtual GroupChat GroupChat { get; set; }
		public int GroupChatId { get; set; }
		public virtual ICollection<ApplicationUser> Users { get; set; }

    }
    public class EditGroupModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsIntroGroup { get; set; }

        public int SectionId { get; set; }
    }
}