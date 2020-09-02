using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TeamWork.Models
{
    public class EmployeeDbContext:DbContext
    {
        
            public EmployeeDbContext() : base("EmployeeDC") { }

            public DbSet<Employee> Employees { get; set; }
            public DbSet<EmployeeArticle> EmployeeArticles { get; set; }
            public DbSet<Comment> Comments { get; set; }
            public DbSet<EmployeeGif> EmployeeGifs { get; set; }
            public DbSet<GifComment> GifComments { get; set; }

    }
}