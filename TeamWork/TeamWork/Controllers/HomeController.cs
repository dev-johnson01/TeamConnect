using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamWork.Models;

namespace TeamWork.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Signin", "Employee");
            }
            else
            {
                ViewBag.Message = "welcome "+Session["Email"].ToString();
                return View();
                
            }
            
        }

        public ActionResult About()

        {
            if(Session["UserId"]!=null)
            {
                ViewBag.heading = "Why Team Connect";


                return View();
            }
            else
            {
                return RedirectToAction("Signin", "Employee");
            }
            
        }

        public ActionResult Contact()
        {
            if (Session["UserId"] != null)
            {
                ViewBag.heading = "Why Team Connect";


                return View();
            }
            else
            {
                return RedirectToAction("Signin", "Employee");
            }
        }
        
       
       

    }
}