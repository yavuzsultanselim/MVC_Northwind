using MVC_Northwind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Northwind.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        NorthwindEntities db = new NorthwindEntities();
       
     
        public ViewResult Index(int id)
        {
            List<Product> products = new List<Product>();
            foreach (var product in db.Products)
            {
                if (product.CategoryID== id)
                {
                    products.Add(product);

                }
            }
            return View(products);
        }

        public PartialViewResult _partialCategory()
        {
            return PartialView(db.Categories.ToList());
        }
    }
}