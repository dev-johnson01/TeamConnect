using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamWork.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        [Required]
        public string EmployeeComment { get; set; }
        public string PostedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public int ArticleId { get; set; }
        public EmployeeArticle EmployeeArticle { get; set; }
        
    }
}