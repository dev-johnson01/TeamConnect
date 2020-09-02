using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using TeamWork.Models;

namespace TeamWork.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article
        public ActionResult Index()
        {
            return View();
        }
       public ActionResult PostArticle() 
        {
            if (Session["Userid"] == null)
            {
                return RedirectToAction("Signin", "Employee");
            }
            return View();
        }
        [HttpPost]
        public ActionResult PostArticle(EmployeeArticle article, HttpPostedFileBase UploadImage)
        {
            if (ModelState.IsValid)
            {
                
                using (EmployeeDbContext db = new EmployeeDbContext())
                {
                    if (UploadImage != null)
                    {
                        if (UploadImage.ContentType == "image/jpg" || UploadImage.ContentType == "image/jpeg" || UploadImage.ContentType == "image/png")
                        {
                            UploadImage.SaveAs(Server.MapPath("/") + "Content/images/" + UploadImage.FileName);
                            article.Image = UploadImage.FileName;
                        }
                    }
                    article.DateCreated = DateTime.Now;
                    article.PostedBy = Session["Email"].ToString();
                    db.EmployeeArticles.Add(article);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("ViewArticles");
        }

      public  ActionResult ViewArticles()
        {
            if (Session["Userid"] == null)
            {
                return RedirectToAction("Signin", "Employee");
            }
            using (EmployeeDbContext db = new EmployeeDbContext())
            {
                var Articles = (from row in db.EmployeeArticles select row).ToList();
                
                return View(Articles);

            }
        }

        public ActionResult ViewEmployeeArticles()
        {
            string Email = Session["Email"].ToString();
            using (EmployeeDbContext db = new EmployeeDbContext())
            {
                var Articles = db.EmployeeArticles.Where(row => row.PostedBy == Email).ToList();
                if (Articles == null)
                {
                    ViewBag.NoArticle = "You Have not upload any Article";
                    return RedirectToAction("UserProfile", "Employee");
                }
                else
                {
                    return View(Articles);
                }

               

            }
        }

        public ActionResult EditArticle(int? id)
        {
            if(id== null)
            {
                return HttpNotFound();
            }

            using (EmployeeDbContext db = new EmployeeDbContext())
            {
                var article = db.EmployeeArticles.Single(row => row.ArticleId == id);
                return View(article);
            }
        }

        [HttpPost]
        public ActionResult EditArticle(EmployeeArticle article)
        {
            using (EmployeeDbContext db = new EmployeeDbContext())
            {

                if (article.ArticleId > 0)
                {
                    var EditedArticle = db.EmployeeArticles.Single(row => row.ArticleId == article.ArticleId);

                    if (article != null)
                    {
                        EditedArticle.DateCreated = DateTime.Now;
                        EditedArticle.ArticleTitle = article.ArticleTitle;
                        EditedArticle.ArticleBody = article.ArticleBody;
                        EditedArticle.Image = article.Image;
                    }
                }
                else
                {
                    db.EmployeeArticles.Add(article);
                }
                db.SaveChanges();
                return RedirectToAction("ViewEmployeeArticles");
            }
        }

       public ActionResult DeleteArticle(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            using (EmployeeDbContext db = new EmployeeDbContext())
            {
                var article = db.EmployeeArticles.Single(row => row.ArticleId == id);
                return View(article);
            }
         
        }
        [ActionName("DeleteArticle")]
        [HttpPost]
        public ActionResult ConfirmDeleteArticle(int?id)
        {
  

            using (EmployeeDbContext db = new EmployeeDbContext())
            {
                var article = db.EmployeeArticles.Single(row => row.ArticleId == id);
                db.EmployeeArticles.Remove(article);
                db.SaveChanges();
                return RedirectToAction("ViewEmployeeArticles");
            }

        }

    }

}