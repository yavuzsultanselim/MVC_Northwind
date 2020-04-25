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
        public ActionResult AddToCart(int id)
        {
            Cart c = Session["scart"] == null ? new Cart() : Session["scart"] as Cart;
            Product eklenecek = db.Products.Find(id);
            CartItem ci = new CartItem();
            ci.ID = eklenecek.ProductID;
            ci.Price = eklenecek.UnitPrice;
            ci.Name = eklenecek.ProductName;
            c.AddItem(ci);
            Session["scart"] = c;
            TempData["cart"] = $"{eklenecek.ProductName} sepete eklendi";
            return RedirectToAction("Index");
        }

        public ActionResult MyCart()
        {
            if (Session["scart"] != null)
            {
                Cart cart = Session["scart"] as Cart;
                return View(cart);
            }
            else
            {
                TempData["emptyCart"] = "Sepetiniz Boş. Harika ürünlerimizden bir tanesini ekleyip tekrar gelebilirsiniz :p";
                return RedirectToAction("Index");
            }

        }
    }
}