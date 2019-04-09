using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsparkWebApi.Models
{
    //This class contains the properties for the "Challenges" model.
    public class Challenges
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public int CompetitionId { get; set; }
        public string test { get; set; }

        public Competition Competition { get; set; }

    }
}