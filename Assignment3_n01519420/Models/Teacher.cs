using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Assignment3_n01519420.Models
{
    //add model validation 
    public class Teacher
    {
        public int TeacherId { get; set; }
        [Required(ErrorMessage="Require FirstName")]
        public string TeacherFName { get; set; }
        [Required(ErrorMessage = "Require LastName")]
        public string TeacherLName { get; set; }
        [Required(ErrorMessage = "Require Employee Number")]
        public string TEmpNumber { get; set; }
        [Required(ErrorMessage = "Require Date")]
        public DateTime HireDate { get; set; }
        [Required(ErrorMessage = "Require Salary")]
        public decimal Salary;

        public Teacher() { }
    }
}