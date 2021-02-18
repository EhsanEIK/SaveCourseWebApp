using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using CourseDetailsWebApp.Models;

namespace CourseDetailsWebApp.Gateway
{
    public class CourseGateway
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["AssignCourseDBConString"].ConnectionString;
        public List<Course> GetAllCourse()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM CourseTable";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            List<Course> courses = new List<Course>();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Course course = new Course();
                course.Id = (int)reader["Id"];
                course.CourseTitle = reader["CourseTitle"].ToString();

                courses.Add(course);
            }
            connection.Close();
            return courses;
        }
        public Course GetCourseCodeByCourseId(int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT CourseCode FROM CourseTable WHERE Id=" +id;
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            Course course = new Course();
            if (reader.Read())
            {
                course.CourseCode = reader["CourseCode"].ToString();
            }
            connection.Close();
            return course;
        }
    }
}