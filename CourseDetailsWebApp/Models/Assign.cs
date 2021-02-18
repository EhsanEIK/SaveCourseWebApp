using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseDetailsWebApp.Models
{
    public class Assign
    {
        public int Id { get; set; }
        public string CourseCode { get; set; }
        public string Assignment { get; set; }
        public string ClassTest { get; set; }
        public string LabReport { get; set; }
        public int CourseId { get; set; }
        public int UserId { get; set; }

        //Extra Property
        public string CourseTitle { get; set; }
        public string UserCodeId { get; set; }
    }
}