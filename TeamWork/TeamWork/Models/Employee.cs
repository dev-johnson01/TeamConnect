using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace TeamWork.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "FirstName is Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is Required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ProfileeImageurl { get; set; }
        public Gender EmployeeGender { get; set; }

        [Required(ErrorMessage = "Department is Required")]
        public Department EmployeeDepartment { get; set; }
        public string JobRole { get; set; }
       

        [Required(ErrorMessage ="Address is Reqiure")]
        public string Address { get; set; }
       

    }
   public enum Gender
    {
        Gender,
        Male,
        Female
    }

    public enum Department
    {
        Department,
        Marketing,
        Account,
        ICT,
        Admin_Personel
    }

   
}