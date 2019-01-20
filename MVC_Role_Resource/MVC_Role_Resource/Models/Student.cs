using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Role_Resource.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        [Display(Name = "Student Name")]
        public string StudentName { get; set; }
        [Display(Name = "Roll No.")]
        public string StudentRollNo { get; set; }
    }
}