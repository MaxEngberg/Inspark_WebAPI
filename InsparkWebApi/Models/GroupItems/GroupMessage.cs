using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsparkWebApi.Models.GroupItems
{
    //This class contains the properties for the "GroupMessage" model.
    public class GroupMessage
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }

        public virtual ApplicationUser Sender { get; set; }
        public virtual Group Group { get; set; }

        public string SenderId { get; set; }
        public int GroupId { get; set; }

    }
}