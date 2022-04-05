using BLL;
using Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Leaveapplication.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginEntity Login)
        {
            LoginEntity objLogin = new LoginBLL().CheckAndValidateUser(Login);
            if (objLogin != null)
            {
               // new LogsBLL().InsertLoginLogs(objLogin);
                Response.Cookies["User"]["UserID"] = clsEncrypt.Encrypt(Convert.ToString(objLogin.EMPId));
              
                Response.Cookies["User"]["username"] = objLogin.WindowsUsername;
                Response.Cookies["User"]["LogInTime"] = DateTime.Now.AddHours(4).ToString();
                Response.Cookies["User"].Expires = DateTime.Now.AddHours(4);
                Session["Empid"] = objLogin.EMPId;
                Session["Empcode"] = objLogin.EMPCode;
                Session["Emial"] = objLogin.EmailId;
                Session["ReportingToId"] = objLogin.ReportingToId;
                Session["FirstName"] = objLogin.FirstName;
                Session["LastName"] = objLogin.LastName;
                return RedirectToAction("Index", "Home");
            }
            else
            {
               // ViewBag.Message = "Sorry, Invalid Email / Password.";
                ViewBag.Message = "Sorry, Invalid User Name.";
                ViewBag.Class = "alert alert-danger alert-dismissable col-lg-12";
                return View();
            }
        }
        [HttpGet]
        public ActionResult LogOut()
        {
            if (Request.Cookies["User"] != null)
            {
                Response.Cookies.Clear();
                Response.Cookies["User"].Expires = DateTime.Now.AddDays(-1);
            }
            return RedirectToAction("Login", "Account");
        }
    }
}