using BLL;
using Common.Entity;
using PagedList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
            Leaveentiy objUserlist = new Leaveentiy();
            var getleavecount = 0.00M;
            string fromdate = Convert.ToString(objUser.Fromdate);
            string todate = Convert.ToString(objUser.Todate);
            var upldateplleavebalance=0;
            decimal Previousplbalance = 0.00M;
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
              
           var totalcounts=   CalculateleaveDays(fromdate, todate);

                
                totalCount = strre.Count();

                 totalleavecount = Convert.ToDecimal(totalCount * 0.5);
                objUser.leavecount = totalcounts - totalleavecount;
               
            }
            objUser.EmpID = Convert.ToInt32(Session["Empid"]);
            objUser.EMPCode = Convert.ToString(Session["Empcode"]);
            if (objUser.leaveId != 0)
            {
               getleavecount = Getleavecount(objUser.EmpID, objUser.leaveId);
            }
            //Logic for edit Approve record
           
            if (objUser.leaveId != 0)
            {
                objUserlist = new LeaveBLL().DisplayUser(objUser.leaveId);
                DateTime oDate = Convert.ToDateTime(objUserlist.Todate);
                var todaysDate = DateTime.Today;

                if (oDate >= todaysDate)
                {
                    objUser.Status = 1;
                    objUserlist.Status = objUser.Status;
                    objUser.IsApproved = false;
                    objUser.IsRejected = false;

                }
                //logic for update leave type from pl to cl viceversa
               // if ( objUserlist.LeaveStatusID =="1" && objUser.LeaveStatusID=="2")
                //   if (objUserlist.LeaveStatusID != objUser.LeaveStatusID )
                //    {
                //     GetUpdatedCL(objUser.EmpID, objUser.LeaveStatusID,objUser.leaveId);
                //   // updateplbalances(objUser.EmpID, objUser.LeaveStatusID, objUser.leaveId);


                //}
                //if (objUserlist.LeaveStatusID == "2" && objUser.LeaveStatusID == "1")
                //{
                //   // GetUpdatedCL(objUser.EmpID, objUser.LeaveStatusID, objUser.leaveId);
                //    //updateplbalances(objUser.EmpID, objUser.LeaveStatusID, objUser.leaveId);

                //}
            }
           
            if (ModelState.IsValid)
            {
                
                Output = new LeaveBLL().InsertUpdateUsers(objUser, objhalfday);
                if (Output == "Insert")
                {
                    GetApprveRejectCLBalance(objUser.EmpID, objUser.LeaveStatusID);
                    
                }
                if (objUser.leavecount > getleavecount && Output== "Update")
                {
                    var leavecounts = objUser.leavecount;
                    var totaldiffcount =  leavecounts- getleavecount;

                    var updateplcount = totaldiffcount;
                    var empids = Convert.ToString(Session["Empid"]);
                  if (!string.IsNullOrEmpty(empids))
                    
                    {
                        if (objUser.LeaveStatusID == "1")
                        {
                            Previousplbalance = GetPLBalance(empids);
                        }
                        if (objUser.LeaveStatusID == "2")
                        {
                            Previousplbalance = GetCLBalance(empids);
                        }
                    }
                    updateplcount = Previousplbalance - totaldiffcount;

                     upldateplleavebalance = updateplbalance_Alppliedleave(objUser.EmpID, updateplcount, objUser.LeaveStatusID, objUser.leaveId);

                }
                if (objUser.leavecount < getleavecount && Output == "Update")
                {
                  
                    var leavecounts = objUser.leavecount;
                    var totaldiffcount = getleavecount- leavecounts;
                   
                    var updateplcount = totaldiffcount;
                    var empids = Convert.ToString(Session["Empid"]);
                    if (!string.IsNullOrEmpty(empids))
                    {
                        if (objUser.LeaveStatusID == "1")
                        {
                            Previousplbalance = GetPLBalance(empids);
                        }
                        if (objUser.LeaveStatusID == "2")
                        {
                            Previousplbalance = GetCLBalance(empids);
                        }
                    }

                   updateplcount = Previousplbalance + totaldiffcount;
                   

                    upldateplleavebalance = updateplbalance(objUser.EmpID, updateplcount, objUser.LeaveStatusID,objUser.leaveId);
                    
                }
              
            }
              bool result = false;
            if (objUserlist.leaveId != 0 && objUserlist.leaveId>0 && objUserlist.IsApproved == true)
            {
                result = EditleaveSendMail(objUser.Fromdate, objUser.Todate, objUser.leavecount, objUser.DynamicTextBox);
            }
            //if leave is more than 5 days 
            if (objUser.leavecount > 5)
            {
                result = MailtoMangerLineManager(objUser.Fromdate, objUser.Todate, objUser.leavecount, objUser.DynamicTextBox);
                result = SendMail(objUser.Fromdate, objUser.Todate, objUser.leavecount, objUser.DynamicTextBox);
            }
            else
            {
                result = SendMail(objUser.Fromdate, objUser.Todate, objUser.leavecount, objUser.DynamicTextBox);
            }
           
          
            return (Output == "Update" ? RedirectToAction("Manage", "Leave", new { Message = "Update" }) : RedirectToAction("Add", "Leave", new { Message = Output }));
         
        }
        
        public ActionResult Manage(Leaveentiy objUser, string Message, int? page)
        {

          
            //var todaysDate="";
            objUser.EmpID =Convert.ToInt32(Session["Empid"]);
            if (objUser.EmpID == 0)
            {
                return RedirectToAction("Login", "Account");
            }
                List<Leaveentiy> UserList = new LeaveBLL().ManageUser(objUser, objUser.EmpID);
           

            GetMessage(UserList.Count == 0 ? "NoRecord" : Message, "");
                CreatePager(page, UserList.Count);
            
                PagedList<Leaveentiy> model = new PagedList<Leaveentiy>(UserList, page.HasValue ? Convert.ToInt32(page) : 1, Pager.GetPageSize());
                ModelState.Clear();
            
                return View(model);
              
        }
        [HttpGet]
        public ActionResult ApproveReject(Leaveentiy objUser, string Message, int? page)
        {
            var empids = Convert.ToInt32(Session["Empid"]);
            if (empids== 0)
            {
                return RedirectToAction("Login", "Account");
            }
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
            Leaveentiy objUserlist = new Leaveentiy();
             bool result = false;
            result = SendMail(User);
            objUserlist = new LeaveBLL().DisplayUsers(DecryptToInt(User));
            objUserlist.IsApproved = true;
            objUserlist.IsRejected = false;
            int empid = objUserlist.EmpID;
            int leaveid = objUserlist.leaveId;
            string leavetype = objUserlist.LeaveStatusID;
            int status = objUserlist.Status;
            if (objUserlist.Status == 3)
            {
              
                AddApproveleavebalance(empid, leaveid, leavetype);
                string ApprovalType = new LeaveBLL().UpdateapproveType(DecryptToInt(User),empid);

            }
            else
            {
              GetApprveRejectCLBalance(empid, leaveid, leavetype, status);

            }
            
            string Message = new LeaveBLL().UpdateStatus(DecryptToInt(User));
            objUser = new LeaveBLL().DisplayUsers(DecryptToInt(User));
            objUser.IsApproved = true;
            objUser.IsRejected = false;
            string Messages = new LeaveBLL().IsApproved(objUser.leaveId, objUser.IsApproved, objUser.IsRejected);
         
            //  GetApprveRejectCLBalance(empid, leaveid, leavetype, status);
            return RedirectToAction("ApproveReject", "Leave", new { Message = Message });
       
        }

        [HttpGet]
        public decimal GetCLBalance(string empid)
        {
            decimal CL=0.00m;
            var empids = Convert.ToString(Session["Empid"]);
            if (empids != "0")
            {
                CL = new LeaveBLL().GetCLBalance(empids);
            }
          
            return CL;
        }
      
        [HttpGet]
        public decimal GetApprveRejectCLBalance(int empid,int leaveid,string leavetype, int status)
        {
            
            decimal CL = new LeaveBLL().GetApprveRejectCLBalance(empid, leaveid, leavetype, status);
            return CL;
        }
        //AddApproveleavebalance
        [HttpGet]
        public decimal AddApproveleavebalance(int empid, int leaveid, string leavetype)
        {

            decimal CL = new LeaveBLL().AddApproveleavebalance(empid, leaveid, leavetype);
            return CL;
        }
        [HttpGet]
        public decimal GetApprveRejectCLBalance(int empid, string leavetype, int leaveid)
        {

            decimal CL = new LeaveBLL().GetApprveRejectCLBalance(empid, leavetype, leaveid);
            return CL;
        }
        [HttpGet]
        public decimal GetApprveRejectCLBalance(int empid, string leavetype)
        {

            decimal CL = new LeaveBLL().GetApprveRejectCLBalance(empid, leavetype);
            return CL;
        }
        //GetUpdatedCL
       // public decimal GetUpdatedCL(int empid, string leavetype, int leaveid)
        public List<decimal> GetUpdatedCL(int empid, string leavetype, int leaveid)
        {
            List < decimal > CL = new LeaveBLL().GetUpdatedCL(empid, leavetype, leaveid);
            return CL;
        }
        //For getting leavecount
        [HttpGet]
        public decimal Getleavecount(int empid, int leaveid)
        {

            decimal CL = new LeaveBLL().Getleavecount(empid,  leaveid);
            return CL;
        }
        //Update balance leave if applied leave is greater than previous appllied leave
        public int updateplbalance(int empid,Decimal TotalPaidLeave,string leavetype, int leaveid)
        {
            string constr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("Sp_UpdateBalanceleave1", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = con;


                //  cmd.Parameters.AddWithValue("@option", "insert");
                cmd.Parameters.AddWithValue("@empid", empid);
                cmd.Parameters.AddWithValue("@TotalPaidLeave", TotalPaidLeave);
                cmd.Parameters.AddWithValue("@leavetype", leavetype);
                cmd.Parameters.AddWithValue("@leaveid", leaveid);

                con.Open();
              int i=  cmd.ExecuteNonQuery();
               
                con.Close();

                return i;
            }
        }
        //Update balance leave if applied leave is less than previous appllied leave
        public int updateplbalance_Alppliedleave(int empid, Decimal TotalPaidLeave, string leavetype, int leaveid)
        {
            string constr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_LA_Applyleavegreater", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@empid", empid);
                cmd.Parameters.AddWithValue("@TotalPaidLeave", TotalPaidLeave);
                cmd.Parameters.AddWithValue("@leavetype", leavetype);
                cmd.Parameters.AddWithValue("@leaveid", leaveid);

                con.Open();
                int i = cmd.ExecuteNonQuery();

                con.Close();

                return i;
            }
        }
        // For Edit leave type
        public DataSet updateplbalances(int empid, string leavetype, int leaveid)
        {
            DataSet ds = new DataSet();
            string constr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
              
                SqlCommand cmd = new SqlCommand("Sp_UpdateCLBalanceLeave", con);
                cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                cmd.Parameters.AddWithValue("@empid", empid);
               
                cmd.Parameters.AddWithValue("@leavetype", leavetype);
                cmd.Parameters.AddWithValue("@leaveid", leaveid);
                con.Open();
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(ds);
                    }
                con.Close();
            }
            
           return ds;

    }

  


    [HttpGet]
        public decimal GetPLBalance(string empid)
        {
            decimal PL = 0.00m;
            var empids = Convert.ToString(Session["Empid"]);
            if (empids != "0")
            {
                PL = new LeaveBLL().GetPLBalance(empids);
            }
            return PL;
        }
        [HttpGet]
        public decimal CalculateleaveDays(string Fromdate, string Todate)
       
        {
          
            
            decimal holiday = new LeaveBLL().GetCount(Fromdate, Todate); 
            return holiday;
            }
        [HttpPost]
        public ActionResult UserDetails(Leaveentiy objUser, string User, string Rejectionreason, int Leaveid)
      
        {
           // InsertRejectreason(Rejectionreason, Leaveid);
            string Rejection = new LeaveBLL().InsertRejectreason(Rejectionreason, Leaveid);
           
            bool result = false;
            Leaveentiy objUserlist = new Leaveentiy();
            result = SendRejectMail(Leaveid);

            objUser = new LeaveBLL().DisplayUser(Leaveid);
            int empid = objUser.EmpID;
            int leaveid = objUser.leaveId;
            if (objUser.Status == 2)
            {
                string ApprovalType = new LeaveBLL().UpdaterejectType(leaveid, empid);
            }
            string Message = new LeaveBLL().UpdateRejectStatus(Leaveid);
            objUserlist = new LeaveBLL().DisplayUser(Leaveid);

            string leavetype = objUserlist.LeaveStatusID;
            int status = objUserlist.Status;

            objUser.IsApproved = false;
            objUser.IsRejected = true;
            string Messages = new LeaveBLL().IsApproved(objUser.leaveId, objUser.IsApproved, objUser.IsRejected);
            GetApprveRejectCLBalance(empid, leaveid, leavetype, status);
            return RedirectToAction("","Leave", new { Message = Message });

        }

}
}
