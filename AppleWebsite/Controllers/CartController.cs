using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppleWebsite.Models;
using AppleWebsite.Identity;
using AppleWebsite.Filter;
using Microsoft.AspNet.Identity;
using System.Threading;

namespace AppleWebsite.Controllers
{
    [AuthenFilterLogin]
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            MTDBContext db = new MTDBContext();
            string id_user = User.Identity.GetUserId();
            List<Cart> carts = db.Carts.Where(row=>row.id_user == id_user).ToList();
            // get current user 
            var appDbContext = new AppDbContext();
            var userStore = new AppUserStore(appDbContext);
            var userManager = new AppUserManager(userStore);
            AppUser user = userManager.FindById(User.Identity.GetUserId());
            ViewBag.User = user;
            return View(carts);

        }
        public ActionResult Buy(int id, string storage)
        {
            MTDBContext db = new MTDBContext();
            List<Cart> carts = db.Carts.ToList();
            string id_user = User.Identity.GetUserId();
            Cart item = db.Carts.Where(row => row.id_dev == id && row.storage==storage && row.id_user == id_user).FirstOrDefault();
            if(item == null)
			{
                item = new Cart();
                item.id_dev = id;
                item.quantity = 1;
                item.storage = storage;
                item.id_user = User.Identity.GetUserId();
                db.Carts.Add(item);
			}
            else// neu ton tai roi thi chi can tang so luong len
			{
                item.quantity++;
			}
                db.SaveChanges();
            Thread.Sleep(2500);
            return RedirectToAction("Details",new { id = id,controller="device"});
        }
        public ActionResult Delete(int id)
        {
            MTDBContext db = new MTDBContext();
            Cart cart = db.Carts.Where(row => row.id_cart == id).FirstOrDefault() ;
            db.Carts.Remove(cart);
           
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}