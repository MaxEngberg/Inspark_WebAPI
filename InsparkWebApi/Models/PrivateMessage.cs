using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InsparkWebApi.Models
{
    //This class contains the properties for the "PrivateMessage" model.
    public class PrivateMessage
    {
        [Key]
        public int MessageID { get; set; }
        public string Text { get; set; }

        public DateTime MessageDateTime { get; set; }
        public bool IsIncoming { get; set; }
        public Byte[] SenderPic { get; set; }

        public string SenderId { get; set; }


    }
}