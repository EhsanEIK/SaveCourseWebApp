using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using CourseDetailsWebApp.Gateway;
using CourseDetailsWebApp.Models;

namespace CourseDetailsWebApp.Manager
{
    public class LogInManager
    {
        LogInGateway logInGateway=new LogInGateway();
        public string Save(LogIn logIn)
        {
            bool isUserCodeIdExist = logInGateway.IsUserCodeIdExist(logIn.UserCodeId);
            if (isUserCodeIdExist)
            {
                return "Sorry,User Id is already exists";
            }
            else
            {
                int rowAffected = logInGateway.Save(logIn);
                if (rowAffected > 0)
                {
                    return "Registration Successful";
                }
                return "Please try again!";
            }     
        }
        public bool IsUserCodeIdPassExist(string UserCodeId, string Password)
        {
            return logInGateway.IsUserCodeIdPassExist(UserCodeId, Password);
        }
        
    }
}