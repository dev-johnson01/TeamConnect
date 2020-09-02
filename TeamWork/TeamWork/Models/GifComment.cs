using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamWork.Models
{
    public class GifComment
    {
        public int GifCommentId { get; set; }
        [Required]
        public string EmployeeGifComment { get; set; }
        public string PostedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public int EmployeeGifId { get; set; }
        public EmployeeGif EmployeeGif { get; set; }
    }
}