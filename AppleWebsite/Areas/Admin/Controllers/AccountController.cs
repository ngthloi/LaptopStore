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

namespace AppleWebsite.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class AccountController : Controller
    {
        // GET: Admin/Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Logout()
		{
            var authenManager = HttpContext.GetOwinContext().Authentication;
            authenManager.SignOut();
            return RedirectToAction("Login", "Account",new { area =""});
        }
    }
}