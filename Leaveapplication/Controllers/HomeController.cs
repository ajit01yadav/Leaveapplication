using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Leaveapplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
       {
            var Empcode = Convert.ToString(Session["Empcode"]);
            var Getroles = new LeaveBLL().GetUserRoles(Empcode.ToString());
            TempData["Roles"] = Getroles;
            return View(TempData["Roles"]);
           // return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}