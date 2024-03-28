using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppleWebsite.Models;
using AppleWebsite.Filter;
namespace AppleWebsite.Controllers
{
	public class DeviceController : Controller
	{
		// GET: Device
		public ActionResult Index(int id, int page = 1)
		{
			MTDBContext db = new MTDBContext();
			if (id > db.Devices.Count() || id < 0)
			{
				return RedirectToAction("error404", "home");
			}
			List<Device> devices = db.Devices.Where(row => row.id_cate == id).ToList(); // lấy ra những sản phẩm thuộc category này
			//Paging 
			int NoOfRecordPerpage = 8;
			int NoOfPages = Convert.ToInt32(
				Math.Ceiling(
					Convert.ToDouble(devices.Count) / Convert.ToDouble(NoOfRecordPerpage)
					)
				);
			int NoOfRecordToSkip = (page - 1) * NoOfRecordPerpage;
			ViewBag.page = page;
			ViewBag.NoOfPages = NoOfPages;
			devices = devices.Skip(NoOfRecordToSkip).Take(NoOfRecordPerpage).ToList();
			return View(devices);
		}
		[AuthenFilterLogin]
		public ActionResult Details(int id)
		{
			MTDBContext db = new MTDBContext();
			Device device_matched = db.Devices.Where(row => row.id_dev == id).FirstOrDefault();
			return View(device_matched);
		}

		[HttpPost]
		public ActionResult Search(string search_name)
		{
			MTDBContext db = new MTDBContext();
			List<Device> devices = db.Devices.Where(row => row.name_dev.ToLower().Contains(search_name.ToLower())).ToList();
			if (devices.Count != 0)
			{
				ViewBag.name = search_name;
				return View(devices);
			}
			{
				ViewBag.name = search_name;
				return View("NotFound");
			}
		}
	}
}