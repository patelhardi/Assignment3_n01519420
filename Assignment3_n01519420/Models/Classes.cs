using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment3_n01519420.Models
{
    //need classes model for adding or removing any teacher from the classes table
    public class Classes
    {
        public int classId { get; set; }
        public int teacherId { get; set; }
        public string classCode { get; set; }
        public string className { get; set; }
        public DateTime startDate { get; set; }
        public DateTime finishDate { get; set; }
    }
}