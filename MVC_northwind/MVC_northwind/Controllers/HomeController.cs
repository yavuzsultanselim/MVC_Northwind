using MVC_Northwind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Northwind.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        NorthwindEntities db = new NorthwindEntities();
        public ViewResult Index()
        {
            return View(db.Products.ToList());
        }
    }
}