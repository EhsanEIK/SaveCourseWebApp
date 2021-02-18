using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using CourseDetailsWebApp.Models;

namespace CourseDetailsWebApp.Gateway
{
    public class LogInGateway
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["AssignCourseDBConString"].ConnectionString;
        public int Save(LogIn logIn)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO LogInTable(UserCodeId,UserName,Password) VALUES ('" + logIn.UserCodeId + "','" + logIn.UserName + "','" + logIn.Password + "')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
        public bool IsUserCodeIdExist(string UserCodeId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT UserCodeId FROM LogInTable WHERE UserCodeId= '" + UserCodeId + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            bool isUserCodeIdExist = reader.HasRows;
            connection.Close();
            return isUserCodeIdExist;
        }
        //Check UserId and Pass for LogIn
        public bool IsUserCodeIdPassExist(string UserCodeId, string Password)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM LogInTable WHERE UserCodeId= '" + UserCodeId + "' AND Password= '" + Password + "' ";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            bool isUserCodeIdPassExist = reader.HasRows;
            connection.Close();
            return isUserCodeIdPassExist;
        }
    }
}