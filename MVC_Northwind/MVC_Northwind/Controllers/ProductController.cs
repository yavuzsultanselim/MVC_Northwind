using MVC_Northwind.Filters;
using MVC_Northwind.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Northwind.Controllers
{
    [AuthFilter]
    public class ProductController : Controller
    {
        // GET: Product
        NorthwindEntities db = new NorthwindEntities();
        public ActionResult Index()
        {
            return View(db.Products.OrderByDescending(x=>x.ProductID).ToList());
        }
        public ActionResult Detail(int id)
        {
            var product = db.Products.Where(x => x.ProductID == id).FirstOrDefault();
            return View(product);
        }
        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct( Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
         
            return RedirectToAction("Index");
        }
      
        public ActionResult Delete(int id)
        {
            var product = db.Products.Where(x => x.ProductID == id).FirstOrDefault();
            return View(product);
        }
        [HttpPost]
        public ActionResult Delete(int id,string productname)
        {
            Product product = db.Products.Find(id );
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {
            var product = db.Products.Where(x => x.ProductID == id).FirstOrDefault();
            return View(product);
        }
        [HttpPost]
        public ActionResult Update(int id, string ProductName, decimal UnitPrice, short UnitsInStock)
        {
            Product product = db.Products.Find(id);
            product.ProductName = ProductName;
            product.UnitPrice = UnitPrice;
            product.UnitsInStock = UnitsInStock;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}