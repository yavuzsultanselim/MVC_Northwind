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
        public ViewResult Beverages()
        {
            return View();
        }
        public ViewResult Condiments()
        {
            return View();
        }
        public ViewResult Confections()
        {
            return View();
        }
        public ViewResult DairyProducts()
        {
            return View();
        }
        public ViewResult GrainsCereals()
        {
            return View();
        }
        public ViewResult MeatPoultry()
        {
            return View();
        }
        public ViewResult Produce()
        {
            return View();
        }
        public ViewResult Seafood()
        {
            return View();
        }
     

        public PartialViewResult _partialCategory()
        {
            return PartialView(db.Categories.ToList());
        }
    }
}