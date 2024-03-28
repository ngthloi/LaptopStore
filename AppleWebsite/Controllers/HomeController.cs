using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppleWebsite.Models;
namespace AppleWebsite.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly] // chỉ cho phép render parital chứ không cho phép truy cập trên thanh url
        public ActionResult GetNavBar()
        {
            MTDBContext db = new MTDBContext();
            List<Category> categories = db.Categories.ToList();
            return View(categories);
        }
        public ActionResult Error404()
		{
            return View();
		}
    }
}