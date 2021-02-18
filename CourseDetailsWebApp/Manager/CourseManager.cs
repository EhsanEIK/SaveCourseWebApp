using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CourseDetailsWebApp.Gateway;
using CourseDetailsWebApp.Models;

namespace CourseDetailsWebApp.Manager
{
    public class CourseManager
    {
        CourseGateway courseGateway=new CourseGateway();
        public List<Course> GetAllCourse()
        {
            return courseGateway.GetAllCourse();
        }
        public Course GetCourseCodeByCourseId(int id)
        {
            return courseGateway.GetCourseCodeByCourseId(id);
        }
    }
}