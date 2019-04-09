using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InsparkWebApi.Models
{
    public class AttendingEvent
    {
        [Key]
        public int Id { get; set; }
        public bool IsComing { get; set; }
        public string UserId { get; set; }
        public int EventId { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Event Event { get; set; }
    }
}