using MVC_Northwind.Filters;
using MVC_Northwind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Northwind.Controllers
{
   
    public class ShipperController : Controller
    {
        // GET: Shipper
        NorthwindEntities db = new NorthwindEntities();

        public ActionResult Index()
        {
            
            return View(db.Shippers.ToList());
        }

        public ActionResult Update(int id)
        {
            var shipper = db.Shippers.Find(id);
            return View(shipper);
        }
        [HttpPost]
        public ActionResult Update(Shipper shipper)
        {
            db.Entry(shipper).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            TempData["success"] = $"{shipper.CompanyName} başarılı bir şekilde güncellendi";

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var shipper = db.Shippers.Find(id);
            return View(shipper);
        }
        [HttpPost]
        public ActionResult Delete(Shipper shipper)
        {
            db.Entry(shipper).State = System.Data.Entity.EntityState.Deleted;

            //db.Shippers.Find(shipper);
            //db.Shippers.Remove(shipper);
            db.SaveChanges();
            TempData["success"] = $"{shipper.CompanyName} Başarılı bir şekilde silindi";
            return RedirectToAction("Index");
        }
        public ActionResult AddShipper()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddShipper(Shipper shipper)
        {
            db.Shippers.Add(shipper);
            db.SaveChanges();
            TempData["success"] = $"{shipper.CompanyName} başarılı bir şekilde eklendi";
            return RedirectToAction("Index");
        }
    }
}