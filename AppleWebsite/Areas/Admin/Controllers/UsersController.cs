using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppleWebsite.Filter;
using AppleWebsite.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace AppleWebsite.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class UsersController : Controller
    {
        // GET: Admin/Users
        public ActionResult Index()
        {
            AppDbContext appDbContext = new AppDbContext();
            AppUserStore userStore = new AppUserStore(appDbContext);
            AppUserManager userManager = new AppUserManager(userStore);
            List<AppUser> appUsers = userManager.Users.Where(x=>x.UserName != "admin") .ToList();
			
            return View(appUsers);
        }
   
        public ActionResult Edit(string id)
        {
            var appDbContext = new AppDbContext();
            var userStore = new AppUserStore(appDbContext);
            var userManager = new AppUserManager(userStore);
            AppUser user = userManager.FindById(id);
            return View(user);
        }
		[HttpPost]
		public ActionResult Edit(AppUser update_user, HttpPostedFileBase imgURL)
		{
			var appDbContext = new AppDbContext();
			var userStore = new AppUserStore(appDbContext);
			var userManager = new AppUserManager(userStore);
			AppUser user = userManager.FindById(update_user.Id);
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
		public ActionResult Delete(string id)
        {
			var appDbContext = new AppDbContext();
			var userStore = new AppUserStore(appDbContext);
			var userManager = new AppUserManager(userStore);
			AppUser user = userManager.FindById(id);
			userManager.Delete(user);
			return RedirectToAction("Index","Users");
		}
		public ActionResult AddNewUser()
		{
			return View();
		}
        [HttpPost]
        public ActionResult AddNewUser(Model.NewUser user_register)
        {
			if (ModelState.IsValid)
			{
				var appDbContext = new AppDbContext();
				var userStore = new AppUserStore(appDbContext);
				var userManager = new AppUserManager(userStore);
				var user = new AppUser()
				{
					UserName = user_register.UserName,
					Fullname = user_register.FullName
				};
				IdentityResult identityResult = userManager.Create(user, user_register.Password);
				if (identityResult.Succeeded)
				{
					userManager.AddToRole(user.Id, "Customer");
				}
				return Redirect("Index");
			}
			else
			{
				ModelState.AddModelError("New error", "Invalid Data");
				return View();
			}
		}
    }
}