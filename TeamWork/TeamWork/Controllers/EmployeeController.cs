using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using TeamWork.Models;

namespace TeamWork.Controllers
{
    public class EmployeeController : Controller
    {
        

        

     
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
       public ActionResult Registration()
        {
            ViewBag.Title = "Register";
            
            return View();
        }

        [HttpPost]
        public ActionResult Registration(Employee emp)
        {
            ViewBag.Title = "Register";

            using (var context = new EmployeeDbContext())
            {
                context.Employees.Add(emp);
                context.SaveChanges();
            }


            return RedirectToAction("EmployeeRecord");
        }

       public ActionResult EmployeeRecord()
        {
            ViewBag.title = "Employee Record";

            using (var context = new EmployeeDbContext())
            {
                var employees = (from row in context.Employees select row).ToList();
                return View(employees);
            }          

        }

        public ActionResult DeleteEmployee(int ? id)
        {
            if(id == null)
            {
                return HttpNotFound();
            }

            using (var context = new EmployeeDbContext())
            {
                var employee = context.Employees.Where(record => record.Id == id).FirstOrDefault();
                return View(employee);
            }
        }

        [HttpPost]
        [ActionName("DeleteEmployee")]
        public ActionResult ConfirmDeleteEmployee(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            using (var context = new EmployeeDbContext())
            {
                var employee = context.Employees.Where(record => record.Id == id).FirstOrDefault();
                context.Employees.Remove(employee);
                context.SaveChanges();

                return RedirectToAction("EmployeeRecord");
            }
        }
        //GET
        public ActionResult EditEmployee(int?id) 
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            using (var context= new EmployeeDbContext())
            {
                var employee = context.Employees.Where(record => record.Id == id).FirstOrDefault();

                return View(employee);
                
            }
        }
        [HttpPost]
        public ActionResult EditEmployee(Employee employee)

        {
            using (var context = new EmployeeDbContext())
            {
                if (employee.Id >0)
                {
                    var val = context.Employees.Where(record => record.Id == employee.Id).FirstOrDefault();

                    if(val != null)
                    {
                        val.FirstName = employee.FirstName;
                        val.LastName = employee.LastName;
                        val.JobRole = employee.JobRole;
                        val.Gender = employee.Gender;
                        val.Department = employee.Department;
                        val.Address = employee.Address;
                        val.Email = employee.Email;
                        val.Password = employee.Password;

                    }
                }
                else
                {
                    context.Employees.Add(employee);
                }
                context.SaveChanges();
                return RedirectToAction("EmployeeRecord");
                
            }
        }

       public  ActionResult EmployeeDetails(int ? id)
        {
            if(id == null)
            {
                return HttpNotFound();
            }
            using (var context = new EmployeeDbContext())
            {
                var employee = context.Employees.Where(record => record.Id == id).FirstOrDefault();

                return View(employee);

            }
        }
    }
}