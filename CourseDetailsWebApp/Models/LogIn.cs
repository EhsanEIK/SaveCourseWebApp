using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseDetailsWebApp.Models
{
    public class LogIn
    {
        public int Id { get; set; }
        public string UserCodeId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}