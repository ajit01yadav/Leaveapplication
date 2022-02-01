using BLL;
using Common.Entity;
using PagedList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Leaveapplication.Controllers
{
    public class LeaveController : CommonController
    {
        // GET: Leave
        [HttpGet]
       // public ActionResult Add(string empid)
             public ActionResult Add(string User, string Message)
        {
            Leaveentiy objUser = new Leaveentiy();
            if (!String.IsNullOrEmpty(User))
                objUser = new LeaveBLL().DisplayUsers(DecryptToInt(User));
            ViewBag.leaveid = objUser.leaveId;
            GetMessage(Message, User);
            BindCountryDropdown();
            BindStatusSelectList(objUser.Status);
            return View(objUser); 
      
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Leaveentiy objUser, string Output)
        {
            if (ModelState.IsValid)
            {
                Output = new LeaveBLL().InsertUpdateUsers(objUser);
                
            }
              bool result = false;


          
            result = SendMail(objUser.EmpID, objUser.Fromdate,objUser.Todate,objUser.leavecount);

            // GetMessage(Output);

            return (Output == "Update" ? RedirectToAction("Manage", "Leave", new { Message = "Update" }) : RedirectToAction("", "Leave", new { Message = Output }));

            // return View(Output);
        }
       
        public ActionResult Manage(Leaveentiy objUser, string Message, int? page)
        {
            List<Leaveentiy> UserList = new LeaveBLL().ManageUser(objUser);
            GetMessage(UserList.Count == 0 ? "NoRecord" : Message, "");
            CreatePager(page, UserList.Count);
            //  BindCountryDropdown();
           // PagedList<Leaveentiy> model = new PagedList<Leaveentiy>(UserList, page.HasValue ? Convert.ToInt32(page) : 1, Pager.GetPageSize());
            return View(UserList);
        }
        public ActionResult Delete(string User)
        {
            string Message = new LeaveBLL().CheckAndDeleteUser(DecryptToInt(User));
           // GetMessage(Message);
            return RedirectToAction("Manage", "Leave", new { Message = Message });
          

        }

        [HttpGet]
        public decimal GetCLBalance(string empid)
        {
            decimal CL = new LeaveBLL().GetCLBalance(empid);
            return CL;
        }
        [HttpGet]
        public decimal GetPLBalance(string empid)
        {
            decimal PL = new LeaveBLL().GetPLBalance(empid);
            return PL;
        }
        [HttpGet]
        public int CalculateleaveDays(string Fromdate, string Todate)
       
        {
            int holiday = new LeaveBLL().GetCount(Fromdate, Todate); 
            return holiday;
            }

    }
}
