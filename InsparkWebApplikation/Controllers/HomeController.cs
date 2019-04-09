using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsparkWebApplikation.Controllers
{
    public class HomeController : Controller
    {
        //Returns the "Index" view.
        public ActionResult Index()
        {
            return View();
        }
        //Returns the "Login" view.
        public ActionResult Login()
        {
            return View();
        }
        //Returns the "LoggedIn" view.
        public ActionResult LoggedIn()
        {
            return View();
        }
        //Returns the "CodeGenerator" view.
        public ActionResult CodeGenerator()
        {
            return View();
        }
        public ActionResult CreateGroup()
        {
            return View();
        }

        public ActionResult CreateUser()
        {
            return View();
        }
        public ActionResult AddUserToGroup()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}