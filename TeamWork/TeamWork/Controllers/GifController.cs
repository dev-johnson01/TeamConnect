using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamWork.Models;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace TeamWork.Controllers
{
    public class GifController : Controller
    {
        // GET: Gif
        public ActionResult Index()
        {
            return View();
        }
       public ActionResult PostGif()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PostGif(EmployeeGif gif, HttpPostedFileBase UploadGif)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Signin", "Employee");
            }

            if(Session["UserId"] != null)
            {
              
                    using (EmployeeDbContext db = new EmployeeDbContext())
                    {
                        if(UploadGif != null)
                        {
                            if (UploadGif.ContentType == "image/gif")
                            {
                                UploadGif.SaveAs(Server.MapPath("/") + "Content/images/gifs/" + UploadGif.FileName);
                                gif.GifUrl = UploadGif.FileName;

                            }
                        }
                        else
                        {
                        ModelState.AddModelError("", "gif is not caputure");
                        return RedirectToAction("index", "home");
                        }
                            gif.DateCreated = DateTime.Now;
                            gif.PostedBy = Session["Email"].ToString();
                            db.EmployeeGifs.Add(gif);
                            db.SaveChanges();
                            return RedirectToAction("DisplayGif");
                    }

            }
            return RedirectToAction("Signin", "Employee");
        }
        public ActionResult DisplayGif()
        {
            if (Session["Userid"] == null)
            {
                return RedirectToAction("Signin", "Employee");
            }
            using (EmployeeDbContext db = new EmployeeDbContext())
            {
                var gifs = (from row in db.EmployeeGifs select row).ToList();

                return View(gifs);

            }
        }

        public ActionResult DeleteGif(int? id)
        {

            if (id == null)
            {
                return HttpNotFound();
            }
            using(EmployeeDbContext db = new EmployeeDbContext())
            {
                var gif = db.EmployeeGifs.Single(row => row.EmployeeGifId == id);
                return View(gif);
            }
        }

        [ActionName("DeleteGif")]
        [HttpPost]
        public ActionResult ConfirmDeleteGif(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            else
            {
                using (EmployeeDbContext db = new EmployeeDbContext())
                {
                    var Del = db.EmployeeGifs.Single(row => row.EmployeeGifId == id);
                    db.EmployeeGifs.Remove(Del);
                    db.SaveChanges();

                    return RedirectToAction("DisplayGif");
                }
                
            }
            
        }
        public ActionResult EditGif(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            using (EmployeeDbContext db = new EmployeeDbContext())
            {
                var gif = db.EmployeeGifs.Single(row => row.EmployeeGifId == id);
                return View(gif);
            }
        }

        [HttpPost]
        public ActionResult EditGif(EmployeeGif gif)
        {
            using (EmployeeDbContext db = new EmployeeDbContext())
            {

                if (gif.EmployeeGifId > 0)
                {
                    var EditedGif = db.EmployeeGifs.Single(row => row.EmployeeGifId == gif.EmployeeGifId);

                    if (gif != null)
                    {
                        EditedGif.DateCreated = DateTime.Now;
                        EditedGif.GifTitle = EditedGif.GifTitle;
                        EditedGif.GifUrl = EditedGif.GifUrl;
                      
                    }
                }
                else
                {
                    db.EmployeeGifs.Add(gif);
                }

                db.SaveChanges();
                return RedirectToAction("ViewEmployeeGifs");
            }
        }

        public ActionResult ViewEmployeeGifs()
        {
            string Email = Session["Email"].ToString();
            using (EmployeeDbContext db = new EmployeeDbContext())
            {
                var gifs = db.EmployeeGifs.Where(row => row.PostedBy == Email).ToList();

                return View(gifs);

            }
        }

    }
}