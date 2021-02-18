using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using CourseDetailsWebApp.Manager;
using CourseDetailsWebApp.Models;

namespace CourseDetailsWebApp.Controllers
{
    public class CourseDetailsController : Controller
    {
        LogInManager logInManager=new LogInManager();
        AssignManager assignManager=new AssignManager();
        CourseManager courseManager=new CourseManager();
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ReadFirst()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Assign()
        {
            ViewData["UserId"] = Session["UserCodeId"];
            ViewBag.UserCodeIds = assignManager.GetAllUserCodeId();
            ViewBag.Courses = courseManager.GetAllCourse();
            return View();
        }
        [HttpGet]
        public ActionResult ShowDetails()
        {
            ViewData["UserId"] = Session["UserCodeId"];
            ViewData["AuthId"] = Session["Auth"];
            if (ViewData["AuthId"] != null)
            {
                ViewBag.UserCodeIds = assignManager.GetAllUserCodeId();
                return View();
            }
            else
            {
                return View();
            }
        }
        
        [HttpGet]
        public ActionResult LogOut()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return Redirect("LogIn");
        }
        [HttpPost]
        public ActionResult LogIn(string userCodeId, string password)
        {
            LogIn logIn=new LogIn();
            logIn.UserCodeId = userCodeId;
            logIn.Password = password;
            bool message = logInManager.IsUserCodeIdPassExist(logIn.UserCodeId, logIn.Password);
            if (message)
            {
                Session["UserCodeId"] = userCodeId;
                Session["Auth"] = 1;
                return RedirectToAction("Assign");
            }
            else
            {
                ViewBag.Message = true;
                ViewBag.Message = "User Email or Password Not Matched";
                return LogIn();
            }
        }
        [HttpPost]
        public ActionResult Register(LogIn logIn)
        {
            string message = logInManager.Save(logIn);
            ViewBag.Message = message;
            return View();
        }
        [HttpPost]
        public ActionResult Assign(Assign assign)
        {
            ViewData["UserId"] = Session["UserCodeId"];
            string message = assignManager.Save(assign);
            ViewBag.Message = message;

            ViewBag.UserCodeIds = assignManager.GetAllUserCodeId();
            ViewBag.Courses = courseManager.GetAllCourse();
            return View(assign);
        }
        public JsonResult GetCourseCodeByCourseId(int id)
        {
            Course course = courseManager.GetCourseCodeByCourseId(id);

            Assign assign = new Assign();
            assign.CourseCode = course.CourseCode;
            return Json(assign);
        }

        public JsonResult ShowDetails(int id)
        {
            ViewData["UserId"] = Session["UserCodeId"];
            ViewData["AuthId"] = Session["Auth"];
            if (ViewData["AuthId"] != null)
            {
                ViewBag.UserCodeIds = assignManager.GetAllUserCodeId();
                List<Assign> assign = assignManager.Search(id);
                return Json(assign, JsonRequestBehavior.AllowGet);
            }
            return Json(JsonRequestBehavior.AllowGet);
        }
	}
}