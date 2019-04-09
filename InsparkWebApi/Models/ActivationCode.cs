using InsparkWebApi.Models.GroupItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsparkWebApi.Models
{
    public class ActivationCode
    {
        Random codeGenerator = new Random();

        public ActivationCode()
        {
            Activated = false;
            Code = codeGenerator.Next(0, 999999).ToString("D6");
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public bool Activated { get; set; }
        public int GroupId { get; set; }

		public int MyProperty { get; set; }

		public Group Group { get; set; }

    }
}