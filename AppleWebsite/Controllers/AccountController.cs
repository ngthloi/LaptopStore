using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppleWebsite.Identity;
using AppleWebsite.ViewModel;
using AppleWebsite.Models;
using System.Web.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using AppleWebsite.Filter;
using System.IO;

namespace AppleWebsite.Controllers
{
	public class AccountController : Controller
	{
		// GET: Account
		public ActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Register(RegisterVM user_register)
		{
			if (ModelState.IsValid) // validation hợp lệ
			{
				var appDbContext = new AppDbContext();
				var userStore = new AppUserStore(appDbContext); // lưu trữ db context
				var userManager = new AppUserManager(userStore); // lữu trữ các role và user
				var user = new AppUser()
				{
					Email = user_register.Email,
					UserName = user_register.UserName,
					Address = user_register.Address,
					PhoneNumber = user_register.Mobile,
					Birthday = user_register.Birthday,
					City = user_register.City,
					Fullname = user_register.FullName
				};
				IdentityResult identityResult = userManager.Create(user, user_register.Password);
				if (identityResult.Succeeded)
				{
					userManager.AddToRole(user.Id, "Customer");
					var authenManager = HttpContext.GetOwinContext().Authentication; // đã tạo vào cho phép đăng nhập luôn
					var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
					authenManager.SignIn(new AuthenticationProperties(), userIdentity); // dăng nhập user này ở cookies
				}
				return RedirectToAction("Index", "Home");

			}
			else
			{
				ModelState.AddModelError("New error", "Invalid Data");
				return View();
			}
		}
		public ActionResult Logout()
		{
			var authenManager = HttpContext.GetOwinContext().Authentication;
			authenManager.SignOut();
			return RedirectToAction("Login", "Account");

		}
		public ActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Login(LoginVM user_login)
		{
			var appDbContext = new AppDbContext();
			var userStore = new AppUserStore(appDbContext);
			var userManager = new AppUserManager(userStore);
			var user = userManager.Find(user_login.UserName, user_login.Password);// em thu find by name thi nó co trả về user nè thầy
			if (user != null)
			{
				var authenManager = HttpContext.GetOwinContext().Authentication;
				var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
				authenManager.SignIn(new AuthenticationProperties(), userIdentity);
				if(userManager.IsInRole(user.Id,"Admin")) // role của admin
				{
					return RedirectToAction("Index", "Home", new { area ="Admin"});

				}
				return RedirectToAction("Index", "Home");
			}
			else
			{
				ViewBag.Error = "Invalid username or password";
				return View();
			}
		}
		[AuthenFilterLogin]
		public ActionResult Information()
		{
			var appDbContext = new AppDbContext();
			var userStore = new AppUserStore(appDbContext);
			var userManager = new AppUserManager(userStore);
			AppUser user = userManager.FindById(User.Identity.GetUserId()); // đã đăng nhập thì lấy được user id dang dăng nhập
			return View(user);
		}

		[AuthenFilterLogin]
		[HttpPost]
		public ActionResult Information(AppUser update_user, HttpPostedFileBase imgURL)
		{
			var appDbContext = new AppDbContext();
			var userStore = new AppUserStore(appDbContext);
			var userManager = new AppUserManager(userStore);
			AppUser user = userManager.FindById(User.Identity.GetUserId());
			user.Fullname = update_user.Fullname;
			user.Birthday = update_user.Birthday;
			user.Email = update_user.Email;
			user.PhoneNumber = update_user.PhoneNumber;
			user.Address = update_user.Address;
			user.City = update_user.City;
			//Save as img 
			if (imgURL != null && imgURL.ContentLength > 0)
			{

				string _FileName = Path.GetFileName(imgURL.FileName);
				string _path = Path.Combine(Server.MapPath("~/Avatar"), _FileName);
				user.imgURL = _FileName;
				imgURL.SaveAs(_path);
			}
			//update user
			userManager.Update(user);
			return View(user);
		}

	}
}