using MVC_Northwind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Northwind.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        NorthwindEntities db = new NorthwindEntities();
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }
        public ActionResult Detail(int id)
        {
            var product = db.Products.Where(x => x.ProductID == id).FirstOrDefault();
            return View(product);
        }
    }
}