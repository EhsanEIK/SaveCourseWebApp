using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CourseDetailsWebApp.Gateway;
using CourseDetailsWebApp.Models;

namespace CourseDetailsWebApp.Manager
{
    public class AssignManager
    {
        AssignGateway assignGateway=new AssignGateway();

        public string Save(Assign assign)
        {
            int rowAffected = assignGateway.Save(assign);
            if (rowAffected > 0)
            {
                return "Data Saved";
            }
            return "Data is not Saved";
        }
        public List<Assign> Search(int id)
        {
            return assignGateway.Search(id);
        }

        public List<LogIn> GetAllUserCodeId()
        {
            return assignGateway.GetAllUserCodeId();
        }
    }
}