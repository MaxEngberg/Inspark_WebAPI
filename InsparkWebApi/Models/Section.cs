using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InsparkWebApi.Models
{
    //This class contains the properties for the "Section" model. 
    public class Section
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}