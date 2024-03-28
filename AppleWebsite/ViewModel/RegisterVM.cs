using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace AppleWebsite.ViewModel
{
	public class RegisterVM
	{
		[Required(ErrorMessage = "Full name can't be blank")]
		[RegularExpression(@"^([a-zA-Z 0-9ÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂưăạảấầẩẫậắằẳẵặẹẻẽềềểỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ]+)$", ErrorMessage = "Can't use special characters in fullname")]
		public string FullName { get; set; }
		[Required(ErrorMessage = "Username can't be blank")]
		[RegularExpression(@"^([a-zA-Z0-9]+)$", ErrorMessage = "Can't use special characters in username")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Forgot password")]
		[RegularExpression(@"^([a-zA-Z0-9]+)$",ErrorMessage ="Can't use special characters in password")]
		[MinLength(6,ErrorMessage = "Passwords must have at least 6 characters")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Forgot confirm password")]
		[Compare("Password",ErrorMessage ="Password and confirm password do not match.")]
		public string ConfirmPassword { get; set; }

		[Required(ErrorMessage = "Email can't be blank")]
		[EmailAddress(ErrorMessage ="Invalid email")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Phone number can't be blank")]
		[RegularExpression(@"^([0-9]+)$", ErrorMessage = "Please enter only number")]
		public string Mobile { get; set; }

		public string Address { get; set; }

		[Required(ErrorMessage ="Please pick your birthday")]
		public DateTime? Birthday { get; set; }

		public string City { get; set; }

	}
}