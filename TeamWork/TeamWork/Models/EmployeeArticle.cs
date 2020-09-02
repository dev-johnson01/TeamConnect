using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeamWork.Models
{
    public class EmployeeArticle
    {
        [Key]
        public int ArticleId { get; set; }
        public string ArticleTitle { get; set; }
        public string PostedBy { get; set; }

        [AllowHtml]
        public string ArticleBody { get; set; }
        [DisplayName("AddImage")]
        public string Image { get; set; }
        public DateTime DateCreated { get; set; }
        

        public List<Comment>Comments { get; set; }
    }

    
}