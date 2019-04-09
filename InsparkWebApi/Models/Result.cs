using InsparkWebApi.Models.GroupItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsparkWebApi.Models
{
    //This class contains the properties for the "Result" model.
    public class Result
    {
        public Result()
        {
            TotalPoints = 0;
        }

        public int Id { get; set; }
        public int TotalPoints { get; set; }
    }

    public class EditResultModel
    {
        public int Id { get; set; }
        public int TotalPoints { get; set; }
    }
}