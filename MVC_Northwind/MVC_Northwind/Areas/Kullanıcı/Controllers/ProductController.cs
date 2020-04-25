using MVC_Northwind.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Northwind.Areas.Kullanıcı.Controllers
{
    [AuthFilter]
    public class ProductController : Controller
    {
        // GET: Kullanıcı/Product
        public ActionResult Index()
        {
            return View();
        }
    }
}