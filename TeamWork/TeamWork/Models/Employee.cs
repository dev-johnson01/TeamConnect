using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TeamWork.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string JobRole { get; set; }
        public string Department { get; set; }
        public string Address { get; set; }

    }

    class EmployeeDbContext: DbContext
    {
        public EmployeeDbContext(): base("EmployeeDC"){}

        public DbSet<Employee> Employees { get; set; }

    }
}