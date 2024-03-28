using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppleWebsite.ViewModel
{
	public class LoginVM
	{
		[Required(ErrorMessage ="Username can't be blank")]
		[RegularExpression(@"^([a-zA-Z0-9]+)$",ErrorMessage ="Invalid username")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Password can't be blank")]
		[RegularExpression(@"^([a-zA-Z0-9]+)$",ErrorMessage ="Invalid password")]
		public string Password { get; set; }
	}
}