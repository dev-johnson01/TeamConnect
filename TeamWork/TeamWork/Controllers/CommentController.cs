using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamWork.Models;

namespace TeamWork.Controllers
{
    public class CommentController : Controller
    {
        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }

      public  ActionResult PostComment(int?id)
      {
            if (id == null)
            {
                return HttpNotFound();
            }
            return View();
            
      }
        [HttpPost]
        public ActionResult PostComment(Comment comment, int?id)
        {
           if (ModelState != null)
            {
                if(id > 0)
                {
                    using (EmployeeDbContext db = new EmployeeDbContext())
                    {
                        var blog = db.EmployeeArticles.Single(row => row.ArticleId == id);


                        comment.DateCreated = DateTime.Now;
                        comment.PostedBy = Session["Email"].ToString();
                        comment.ArticleId = blog.ArticleId;
                        db.Comments.Add(comment);
                        db.SaveChanges();

                    }
                    return RedirectToAction("ViewArticles", "Article");
                }
            }

            return View();

           
        }
    }
}