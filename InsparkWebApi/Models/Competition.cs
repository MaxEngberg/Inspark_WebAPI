using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsparkWebApi.Models
{
    //This class contains the properties for the "Competition" model.
    public class Competition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Section Section { get; set; }
        public int SectionId { get; set; }
        public int Test { get; set; }

    }
}