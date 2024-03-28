using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppleWebsite.Filter;
using AppleWebsite.Models;
namespace AppleWebsite.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class ProductsController : Controller
    {
        MTDBContext db = new MTDBContext();
        // GET: Admin/Products
        public ActionResult Index()
        {
            List<Device> devices = db.Devices.ToList();
            return View(devices);
        }
        public ActionResult Edit(int id)
        {
            ViewBag.Category = db.Categories.ToList(); 
            Device x = db.Devices.Find(id);
            return View(x);
        }
        [HttpPost]
        public ActionResult Edit(Device x, HttpPostedFileBase img)
        {
            Device match = db.Devices.Where(row=>row.id_dev == x.id_dev).FirstOrDefault();
            match.name_dev = x.name_dev;
            match.id_cate = x.id_cate;
            match.storage = x.storage;
            match.cost = x.cost;
            Category temp = db.Categories.Where(row => row.id_cate == x.id_cate).FirstOrDefault();
            //Save as img 
            if (img != null && img.ContentLength > 0)
            {
                string cate = temp.name_cate;
                string _FileName = Path.GetFileName(img.FileName);
                string map= cate + "/"+_FileName;
                string _path = Path.Combine(Server.MapPath("~/DeviceAppleImage"), map);
                match.img = _FileName;
                img.SaveAs(_path);
            }
            //update product
            ViewBag.Category = db.Categories.ToList();
            db.SaveChanges();
            return View(match);
        }
        public ActionResult Delete(int id)
        {
            Device x= db.Devices.Find(id);
            db.Devices.Remove(x);
            db.SaveChanges();
            return RedirectToAction("Index","Products");
        }
        public ActionResult Create()
        {
            ViewBag.Category = db.Categories.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Device x, HttpPostedFileBase img)
        {
            db.Devices.Add(x);
            Category temp = db.Categories.Where(row => row.id_cate == x.id_cate).FirstOrDefault();
            ViewBag.Category = db.Categories.ToList();
            if (img != null && img.ContentLength > 0)
            {
                string cate = temp.name_cate;
                string _FileName = Path.GetFileName(img.FileName);
                string map = cate + "/" + _FileName;
                string _path = Path.Combine(Server.MapPath("~/DeviceAppleImage"), map);
                x.img = _FileName;
                img.SaveAs(_path);
            }
            db.SaveChanges();
            return RedirectToAction("Index","Products");
        }
    }
}