using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace AppleWebsite.Areas.Admin.Model
{
	public class NewUser
	{
		[Required(ErrorMessage = "Tên đầy đủ không được để trống")]
		[RegularExpression(@"^([a-zA-Z 0-9ÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂưăạảấầẩẫậắằẳẵặẹẻẽềềểỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ]+)$", ErrorMessage = "Can't use special characters in fullname")]
		public string FullName { get; set; }
		[Required(ErrorMessage = "Tên người dùng không được để trống")]
		[RegularExpression(@"^([a-zA-Z0-9]+)$", ErrorMessage = "Không thể sử dụng các ký tự đặc biệt tài khoản")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Quên mật khẩu")]
		[RegularExpression(@"^([a-zA-Z0-9]+)$",ErrorMessage = "Không thể sử dụng các ký tự đặc biệt trong mật khẩu")]
		[MinLength(6,ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Quên mật khẩu xác nhận")]
		[Compare("Password",ErrorMessage = "Mật khẩu và mật khẩu xác nhận không khớp.")]
		public string ConfirmPassword { get; set; }
	}
}