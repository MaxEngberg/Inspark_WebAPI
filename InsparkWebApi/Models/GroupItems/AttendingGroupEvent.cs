using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InsparkWebApi.Models.GroupItems
{
    //This class contains the properties for the "Attending" model.
    public class AttendingGroupEvent
    {
        [Key]
        public int Id { get; set; }
        public bool IsComing { get; set; }
        public string UserId { get; set; }
        public int GroupEventId { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual GroupEvent GroupEvent { get; set; }
    }
}