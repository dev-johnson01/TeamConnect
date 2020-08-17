using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamWork.Models;

namespace TeamWork.Controllers
{
    public class AccountController : Controller
    {
        
        // GET: Account
        public ActionResult Signin()
        {
            return View();
        }
        
    }
}