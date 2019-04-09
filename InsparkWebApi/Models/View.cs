using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InsparkWebApi.Models
{
	public class View
	{
		[Key]
		public int Id { get; set; }
		public string UserId { get; set; }
	}
}