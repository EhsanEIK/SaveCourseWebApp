using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseDetailsWebApp.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseTitle { get; set; }
        public string CourseCode { get; set; }
    }
}