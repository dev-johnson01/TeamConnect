using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamWork.Models
{
    public class EmployeeGif
    {
        public int EmployeeGifId { get; set; }
        public string GifTitle { get; set; }
        public string PostedBy { get; set; }
        public DateTime  DateCreated { get; set; }
        public string GifUrl { get; set; }
        public List<GifComment> GifComments { get; set; }
    }
}