using MVC_Northwind.Filters;
using MVC_Northwind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Northwind.Controllers
{
    
    public class EmployeeController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
        // GET: Employee
        
        public ActionResult Index()
        {
            
            return View(db.Employees.ToList());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
           var employee= db.Employees.Where(x => x.EmployeeID == id).FirstOrDefault();
            return View(employee);
        }

        // GET: Employee/Create
        public ActionResult AddEmployee()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            try
            {
                db.Employees.Add(employee);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Update(int id)
        {
            var employee = db.Employees.Where(x => x.EmployeeID == id).FirstOrDefault();
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Update(int id, string Title,string FirstName,string LastName,DateTime BirthDate,string HomePhone,string PhotoPath)
        {
            try
            {
                Employee employee = db.Employees.Find(id);
                employee.Title = Title;
                employee.FirstName = FirstName;
                employee.LastName = LastName;
                employee.BirthDate = BirthDate;
                employee.HomePhone = HomePhone;
                employee.PhotoPath = PhotoPath;
                db.SaveChanges();
                return RedirectToAction("Details/", new {id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult _partialDelete(int id)
        {
            var employee = db.Employees.Where(x => x.EmployeeID == id).FirstOrDefault();
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult _partialDelete(int id,Employee employee)
        {
            try
            {
                Employee employee1 = db.Employees.Find(id);
                db.Employees.Remove(employee1);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
