using MVC_Northwind.Areas.Kullanıcı;
using MVC_Northwind.Filters;
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
            return View();
        }
        [HttpPost]
        public ActionResult Index(Accesss model)
        {
            if (ModelState.IsValid)
            {
                Accesss user = db.Accessses.FirstOrDefault(x => x.UserName == model.UserName && x.Passwword == model.Passwword);
                Admin admin = db.Admins.FirstOrDefault(x => x.UserName == model.UserName && x.Password == model.Passwword);
                if (user!=null)
                {
                    Session["login"] = user;
                    return RedirectToAction("Index","Home",new {area="Kullanıcı" });
                }
                else if (admin != null)
                {
                    Session["adminlogin"] = user;
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else
                {
                    TempData["eror"] = "Böyle bir kullanıcı bulunamadı";
                    return View();
                }

            }
            else
            {
                return View();
            }
        }
        
        public ViewResult HomePage()
        {
            return View(db.Products.ToList());
        }

    }
}