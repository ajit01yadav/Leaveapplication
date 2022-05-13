using BLL;
using Common.Entity;
using PagedList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

namespace Leaveapplication.Controllers
{
    public class LeaveController : CommonController
    {
      
        // GET: Leave
        [HttpGet]
      
        public ActionResult Add(string User, string Message)
        {
          

            Leaveentiy objUser = new Leaveentiy();
            if (!String.IsNullOrEmpty(User))
            objUser = new LeaveBLL().DisplayUsers(DecryptToInt(User));
            if (objUser.halfdayid != null && objUser.halfdayid != "0")
            {
                 string Deleted;
                Deleted = new LeaveBLL().IsDeletedRecord(objUser.leaveId);
                objUser.halfdayid = null;
            }
            ViewBag.leaveid = objUser.leaveId;
           ViewBag.halfdayid = objUser.halfdayid;
           Session["haldayid"] = ViewBag.halfdayid;
            GetMessage(Message, User);
            BindLeavetype();
            return View(objUser); 
      
        }
       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Leaveentiy objUser,Halfdayentity objhalfday, string Output)
        {
            var totalCount = 0;
            decimal Totalleave = objUser.leavecount;
            string[] strre = objUser.DynamicTextBox;
            Decimal totalleavecount = 0;
            if (strre != null && objUser.leaveId==0)
            {
                totalCount = strre.Count();

                 totalleavecount = Convert.ToDecimal(totalCount * 0.5);
                objUser.leavecount = Totalleave - totalleavecount;
            }
            if (strre != null && objUser.leaveId != 0)
            {
              
           var totalcounts=   CalculateleaveDays(objUser.Fromdate,objUser.Todate);

                
                totalCount = strre.Count();

                 totalleavecount = Convert.ToDecimal(totalCount * 0.5);
                objUser.leavecount = totalcounts - totalleavecount;
               
            }
            objUser.EmpID = Convert.ToInt32(Session["Empid"]);
            objUser.EMPCode = Convert.ToString(Session["Empcode"]);
          

                if (ModelState.IsValid)
            {
                
                Output = new LeaveBLL().InsertUpdateUsers(objUser, objhalfday);
              
            }
              bool result = false;
            result = SendMail(objUser.Fromdate, objUser.Todate, objUser.leavecount, objUser.DynamicTextBox);
           // ModelState.Clear();

            return (Output == "Update" ? RedirectToAction("Manage", "Leave", new { Message = "Update" }) : RedirectToAction("Add", "Leave", new { Message = Output }));

        }
        
        public ActionResult Manage(Leaveentiy objUser, string Message, int? page)
        {
        
            objUser.EmpID =Convert.ToInt32(Session["Empid"]);
          
            List<Leaveentiy> UserList = new LeaveBLL().ManageUser(objUser, objUser.EmpID);
                GetMessage(UserList.Count == 0 ? "NoRecord" : Message, "");
                CreatePager(page, UserList.Count);
           
            PagedList<Leaveentiy> model = new PagedList<Leaveentiy>(UserList, page.HasValue ? Convert.ToInt32(page) : 1, Pager.GetPageSize());
            ModelState.Clear();
            return View(model);
            
        }
        
        public ActionResult ApproveReject(Leaveentiy objUser, string Message, int? page)
        {
            var empids = Convert.ToInt32(Session["Empid"]);
            // Employeeentity objemp = new LeaveBLL().GetEmailId(empids);
           var Reportingid = Convert.ToString(Session["ReportingToId"]);
            List<Leaveentiy> UserList = new LeaveBLL().ApproveRejectUser(objUser, empids.ToString());
            GetMessage(UserList.Count == 0 ? "NoRecord" : Message, "");
                CreatePager(page, UserList.Count);
            PagedList<Leaveentiy> model = new PagedList<Leaveentiy>(UserList, page.HasValue ? Convert.ToInt32(page) : 1, Pager.GetPageSize());
            ModelState.Clear();
            return View(model);
        }
              
        public ActionResult Delete(string User)
        {
            string Message = new LeaveBLL().CheckAndDeleteUser(DecryptToInt(User));
            return RedirectToAction("Manage", "Leave", new { Message = Message });
          

        }
        public ActionResult Approve(Leaveentiy objUser, string User)
        {
            bool result = false;

            result = SendMail(User);
            string Message = new LeaveBLL().UpdateStatus(DecryptToInt(User));
            objUser = new LeaveBLL().DisplayUsers(DecryptToInt(User));
            objUser.IsApproved = true;
            objUser.IsRejected = false;
            string Messages = new LeaveBLL().IsApproved(objUser.leaveId, objUser.IsApproved, objUser.IsRejected);
            int empid = objUser.EmpID;
            int leaveid = objUser.leaveId;
            string leavetype = objUser.LeaveStatusID;
            int status = objUser.Status;
          
            GetApprveRejectCLBalance(empid, leaveid, leavetype, status);
           return RedirectToAction("ApproveReject", "Leave", new { Message = Message });
       
        }

        [HttpGet]
        public decimal GetCLBalance(string empid)
        {
            var empids = Convert.ToString(Session["Empid"]);
            decimal CL = new LeaveBLL().GetCLBalance(empids);
            return CL;
        }
        [HttpGet]
        public decimal GetApprveRejectCLBalance(int empid,int leaveid,string leavetype, int status)
        {
            
            decimal CL = new LeaveBLL().GetApprveRejectCLBalance(empid, leaveid, leavetype, status);
            return CL;
        }
        [HttpGet]
        public decimal GetPLBalance(string empid)
        {
            var empids = Convert.ToString(Session["Empid"]);
          
            decimal PL  = new LeaveBLL().GetPLBalance(empids);
            return PL;
        }
        [HttpGet]
        public decimal CalculateleaveDays(string Fromdate, string Todate)
       
        {
            decimal holiday = new LeaveBLL().GetCount(Fromdate, Todate); 
            return holiday;
            }

         public ActionResult UserDetails(Leaveentiy objUser, string User, string Rejectionreason, int Leaveid)

        {
            string Rejection = new LeaveBLL().InsertRejectreason(Rejectionreason, Leaveid);
            bool result = false;
            result = SendRejectMail(Leaveid);
            string Message = new LeaveBLL().UpdateRejectStatus(Leaveid);
            objUser = new LeaveBLL().DisplayUser(Leaveid);
            int empid = objUser.EmpID;
            int leaveid = objUser.leaveId;
            string leavetype = objUser.LeaveStatusID;
            int status = objUser.Status;
            if (objUser.IsApproved == true)
            {
                objUser.IsApproved = false;
                objUser.IsRejected = true;
              
                GetApprveRejectCLBalance(empid, leaveid, leavetype, status);
            }
           
            objUser.IsApproved = false;
            objUser.IsRejected = true;
            string Messages = new LeaveBLL().IsApproved(objUser.leaveId, objUser.IsApproved, objUser.IsRejected);

            return RedirectToAction("ApproveReject", "Leave", new { Message = Message });
           

        }
      
    }
}
