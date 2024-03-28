using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
namespace AppleWebsite.Identity
{
	public class AppUser:IdentityUser
	{
		public string Address { get; set; }

		[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
		public DateTime? Birthday { get; set; }
		public string City { get; set; }
		public string imgURL { get; set; }
		public string Fullname { get; set; }

	}
}