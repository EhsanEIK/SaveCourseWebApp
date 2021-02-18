using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using CourseDetailsWebApp.Models;

namespace CourseDetailsWebApp.Gateway
{
    public class AssignGateway
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["AssignCourseDBConString"].ConnectionString;

        public int Save(Assign assign)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO AssignTable(Assignment,ClassTest,LabReport,CourseId,UserId) VALUES ('" + assign.Assignment + "','" + assign.ClassTest + "','" + assign.LabReport + "','" + assign.CourseId + "','" + assign.UserId +"' )";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
        public List<Assign> Search(int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT l.UserCodeId,c.CourseTitle,c.CourseCode,a.Assignment,a.ClassTest,a.LabReport FROM AssignTable as a JOIN CourseTable as c on a.CourseId=c.Id JOIN LogInTable as l on a.UserId=l.Id WHERE UserId="+id;
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            List<Assign> assignList = new List<Assign>();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Assign assign = new Assign();
                assign.CourseTitle = reader["CourseTitle"].ToString();
                assign.CourseCode = reader["CourseCode"].ToString();
                assign.Assignment = reader["Assignment"].ToString();
                assign.ClassTest = reader["ClassTest"].ToString();
                assign.LabReport = reader["LabReport"].ToString();
                assign.UserCodeId = reader["UserCodeId"].ToString();

                assignList.Add(assign);
            }
            connection.Close();
            return assignList;
        }

        public List<LogIn> GetAllUserCodeId()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM LogInTable";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            List<LogIn> logIns = new List<LogIn>();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                LogIn logIn = new LogIn();
                logIn.Id = (int)reader["Id"];
                logIn.UserCodeId = reader["UserCodeId"].ToString();

                logIns.Add(logIn);
            }
            connection.Close();
            return logIns;
        }
    }
}