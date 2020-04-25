using MVC_Northwind.Filters;
using MVC_Northwind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Northwind.Areas.Kullanıcı.Controllers
{
    [AuthFilter]
    public class HomeController : Controller
    {
        // GET: Kullanıcı/Home
        NorthwindEntities db = new NorthwindEntities();

        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }
    }
}