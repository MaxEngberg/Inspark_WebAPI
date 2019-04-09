using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InsparkWebApi.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime TimeForEvent { get; set; }
        public string Location { get; set; }
        public Byte[] Picture { get; set; }

        public ApplicationUser Sender { get; set; }

        public string SenderId { get; set; }
    }
    public class EditEventModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public DateTime TimeForEvent { get; set; }
        public string Location { get; set; }
        public Byte[] Picture { get; set; }
    }
}