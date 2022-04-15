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
using System.Web.Services;

namespace Leaveapplication.Controllers
{
    public class LeaveController : CommonController
    {
      
        // GET: Leave
        [HttpGet]
      
        public ActionResult Add(string User, string Message)
        {
           // int DataTagCount;
          //  List<DataTags> DataTagList = new List<DataTags>();
            Leaveentiy objUser = new Leaveentiy();
            if (!String.IsNullOrEmpty(User))
                objUser = new LeaveBLL().DisplayUsers(DecryptToInt(User));
            ViewBag.leaveid = objUser.leaveId;
            ViewBag.halfdayid = objUser.halfdayid;
            Session["haldayid"] = ViewBag.halfdayid;
            GetMessage(Message, User);
            BindLeavetype();
            BindStatusSelectList(objUser.Status);
         //   BindDefaultDataTags(Convert.ToInt16(objUser.leaveId), (int)PageTypes.ContentPage, out DataTagCount, out DataTagList);
            // BindDefaultDataTags(Convert.ToInt16(objContent.ContentPageID), (int)PageTypes.ContentPage, out DataTagCount, out DataTagList);
           // objUser.DataTagList = DataTagList;
           // objUser.DatTagCount = DataTagCount;
            return View(objUser); 
      
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Leaveentiy objUser,Halfdayentity objhalfday, string Output)
        {
           objUser.halfdayid = Convert.ToInt32(Session["haldayid"]).ToString();
            // objUser.leaveId
            //if (objUser.halfdayid != "0")
            //{
                
            //    string Message = new LeaveBLL().IsDeletedRecord(objUser.leaveId);
            //}

            objUser.EmpID = Convert.ToInt32(Session["Empid"]);
            objUser.EMPCode = Convert.ToString(Session["Empcode"]);
           
            if (ModelState.IsValid)
            {
                Output = new LeaveBLL().InsertUpdateUsers(objUser);
              
            }
              bool result = false;
            result = SendMail(objUser.Fromdate, objUser.Todate, objUser.leavecount, objUser.DynamicTextBox);
           // ModelState.Clear();

            return (Output == "Update" ? RedirectToAction("Manage", "Leave", new { Message = "Update" }) : RedirectToAction("Add", "Leave", new { Message = Output }));

        }
        
        public ActionResult Manage(Leaveentiy objUser, string Message, int? page)
        {
           // ModelState.Clear();
            objUser.EmpID =Convert.ToInt32(Session["Empid"]);
            // var empids = Convert.ToInt32(Session["Empid"]);
            // List<Leaveentiy> UserList = new LeaveBLL().ManageUserByEmpcode(objUser.EmpID);
           
            List<Leaveentiy> UserList = new LeaveBLL().ManageUser(objUser, objUser.EmpID);
                GetMessage(UserList.Count == 0 ? "NoRecord" : Message, "");
                CreatePager(page, UserList.Count);
            // return View(UserList);
            //  BindCountryDropdown();
           // ModelState.Clear();
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
          // List<Leaveentiy> UserList = new LeaveBLL().ManageApproveReject(empids.ToString());
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
           // return RedirectToAction( Message );

        }

        [HttpGet]
        public decimal GetCLBalance(string empid)
        {
            var empids = Session["Empid"].ToString();
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
            var empids = Session["Empid"].ToString();
          //  decimal? a = null;
           // decimal PL = a.GetValueOrDefault(0m);

            decimal PL  = new LeaveBLL().GetPLBalance(empids);
            return PL;
        }
        [HttpGet]
        public decimal CalculateleaveDays(string Fromdate, string Todate)
       
        {
            decimal holiday = new LeaveBLL().GetCount(Fromdate, Todate); 
            return holiday;
            }

       
       // public string UserDetails(Leaveentiy objUser,string Rejectionreason, int Leaveid)
         //public ActionResult UserDetails(string User, string Rejectionreason, int Leaveid)
         public ActionResult UserDetails(Leaveentiy objUser, string User, string Rejectionreason, int Leaveid)

        {
            string Rejection = new LeaveBLL().InsertRejectreason(Rejectionreason, Leaveid);
            bool result = false;
            result = SendRejectMail(Leaveid);
            string Message = new LeaveBLL().UpdateRejectStatus(Leaveid);
            objUser = new LeaveBLL().DisplayUser(Leaveid);
            objUser.IsApproved = false;
            objUser.IsRejected = true;
            string Messages = new LeaveBLL().IsApproved(objUser.leaveId, objUser.IsApproved, objUser.IsRejected);
            int empid = objUser.EmpID;
            int leaveid = objUser.leaveId;
            string leavetype = objUser.LeaveStatusID;
            int status = objUser.Status;
            GetApprveRejectCLBalance(empid, leaveid, leavetype, status);
            return RedirectToAction("ApproveReject", "Leave", new { Message = Message });
           // return Rejection;

        }
      
    }
}
