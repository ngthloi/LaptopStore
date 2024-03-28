using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppleWebsite.Filter;
using AppleWebsite.Identity;
using Microsoft.AspNet.Identity;

namespace AppleWebsite.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
        
            return View();
        }
    }
}