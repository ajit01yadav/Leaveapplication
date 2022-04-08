using BLL;
using Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Leaveapplication.Controllers
{
    public class CommonController : Controller
    {
        // GET: Common
     
        public ActionResult GetMessage(string Output, string Type = "")
        {
            string Class;
            ViewBag.Message = Validations.AcknwledgementMsg(Output, out Class);
            ViewBag.Class = Class;
            ViewBag.Type = "Create ";
            if (!String.IsNullOrEmpty(Type))
                ViewBag.Type = "Edit ";
            return View();
        }

        public int DecryptToInt(string ID)
        {
            try
            {
                return Convert.ToInt32(clsEncrypt.Decrypt(ID));
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public void BindLeavetype(int SelectedValue = 0)
        {
            ViewData["LeavetypeDropdown"] = new SelectList(new LeaveTypeBLL().CountryDropdown(), "Value", "Text", SelectedValue);
        }
        public void BindStatusSelectList(int SelectedValue = 1)
        {
            ViewData["StatusSelect"] = new SelectList(new General().getStatus(), "Value", "Text", SelectedValue);
        }
        public void BindUserStatusSelectList(int SelectedValue = 1)
        {
            ViewData["StatusSelect"] = new SelectList(new General().GetUserStatus(), "Value", "Text", SelectedValue);
        }
        public void BindRoleSelectList(int SelectedValue = 0)
        {
            ViewData["Permission"] = new SelectList(new RoleBLL().BindRoleDropDown(), "Value", "Text", SelectedValue);
        }
        public void BindDefaultDataTags(int EntityID, int EntityType, out int DatTagCount, out List<DataTags> Datatag)
        {
            List<DataTags> DatatagList = new List<DataTags>();
            if (EntityID != 0)
                DatatagList = new ContentBLL().DisplayDatatags(EntityID, EntityType);
            DatTagCount = DatatagList.Count > 0 ? DatatagList.Count : 1;
            ViewBag.DatTagCount = DatatagList.Count > 0 ? DatatagList.Count : 1;
            if (DatatagList.Count == 0)
                DatatagList.Add(new DataTags() { TagName = "", TagValue = "" });
            Datatag = DatatagList;
        }
        public void CreatePager(int? PageNo, int TotalRowCount)
        {
            int pageSize = Pager.GetPageSize();
            int pageIndex = 1;
            pageIndex = PageNo.HasValue ? Convert.ToInt32(PageNo) : 1;
            var ItemsCount = Enumerable.Range(1, TotalRowCount).Select(x => "Item " + x);
            var pager = new Pager(ItemsCount.Count(), PageNo, pageSize, 6);
            var CreatePager = new Paging
            {
                Items = ItemsCount.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                Pager = pager
            };
            ViewBag.Paging = CreatePager;
        }
       // public bool SendMail(Leaveentiy objUser, string fromdate, string todate, decimal leavecount, string[] halfday)
       public bool SendMail(string fromdate, string todate, decimal leavecount, string[] halfday)
        {
            var empids = Convert.ToInt32(Session["Empid"]);
            var FromEmail = Session["Emial"];
            var FirstName = Session["FirstName"];
            var LastName = Session["LastName"];
           // List<Leaveentiy> Users = new LeaveBLL().ManageUserByEmpcode(objUser.EmpID);
            List<Employeeentity> objemp = new LeaveBLL().GetEmailId(empids);
           // Employeeentity objemp = new LeaveBLL().GetEmailId(empids);
            HRentity objhr = new LeaveBLL().GetHREmail();
            string strSubject = "", strMessage = "";
           // foreach (var reportingmail in objemp)
                foreach (var reportingmail in objemp)
                {
              
                    strSubject = "Application For Leave";
                    strMessage = "<table border='0' style=' font-family:Arial; font-size:13px;'><tr><td style='text-align:justify'>";
                    // strMessage += "Dear " + objemp.FirstName + " " + objemp.LastName + "," + "<br/><br/>";
                    strMessage += "Dear " + reportingmail.FirstName + " " + reportingmail.LastName + "," + "<br/><br/>";
                    strMessage += "Please approve my leave for " + leavecount + " day/s from" + fromdate + "  to " + todate + ". :" + "<br/><br/>";
                    strMessage += "Regards," + "<br/>";
                   // strMessage += "NEC Technologies.";
                   // strMessage += objemp[0].FirstName + " " + reportingmail.FirstName;
                   strMessage += FirstName + " " + LastName;
                new General().SendMail(reportingmail.EmailId.ToString(), objhr.Emailid.ToString(), "", strSubject, strMessage, 0, "", true, "", FromEmail.ToString());
               
            }

            return true;
        }
        public bool SendMail(string User )
        {
           // var empids = Convert.ToInt32(Session["Empid"]);
            Leaveentiy objUser = new Leaveentiy();
           // if (!String.IsNullOrEmpty(User))
             objUser = new LeaveBLL().DisplayUsers(DecryptToInt(User));
            decimal leavecount = objUser.leavecount;
            string todate = objUser.Todate;
            string fromdate= objUser.Fromdate;
            string approvalreason = objUser.leavereason;
            Employeeentity objemp = new LeaveBLL().GetUserEmail(objUser.EmpID);
            HRentity objhr = new LeaveBLL().GetHREmail();
            var FromEmail = Session["Emial"];
            string strSubject = "", strMessage = "";
            if (objemp != null)
            {
                strSubject = "Application For Leave";
                strMessage = "<table border='0' style=' font-family:Arial; font-size:13px;'><tr><td style='text-align:justify'>";
                strMessage += "Dear " + objemp.FirstName + " " + objemp.LastName + "," + "<br/><br/>";
                strMessage += "This is to inform you that your leave request has been approved for " + leavecount + " day/s from" + fromdate + "  to " + todate + ". :" + "<br/><br/>";
                strMessage += "Reason for leave is"  + approvalreason +  "<br/>";
                strMessage += "Regards," + "<br/>";
               // strMessage += "NEC Technologies.";
                strMessage += objemp.FirstName + " " + objemp.LastName;
                new General().SendMail(objemp.EmailId.ToString(), objhr.Emailid.ToString(), "", strSubject, strMessage, 0, "", true, "", FromEmail.ToString());
            }
            return true;
        }
        public bool SendRejectMail(int Leaveid)
        {
            // var empids = Convert.ToInt32(Session["Empid"]);
            Leaveentiy objUser = new Leaveentiy();
           // objUser = new LeaveBLL().DisplayUsers(DecryptToInt(User));
            objUser = new LeaveBLL().GetleaveDetialbyid(Leaveid);
            decimal leavecount = objUser.leavecount;
            string todate = objUser.Todate;
            string fromdate = objUser.Fromdate;
            string Rejectionreason = objUser.Rejectionreason;
            Employeeentity objemp = new LeaveBLL().GetUserEmail(objUser.EmpID);
            HRentity objhr = new LeaveBLL().GetHREmail();
            var FromEmail = Session["Emial"].ToString();
            string strSubject = "", strMessage = "";
            if (objemp != null)
            {
                strSubject = "Leave Rejected";
                strMessage = "<table border='0' style=' font-family:Arial; font-size:13px;'><tr><td style='text-align:justify'>";
                strMessage += "Dear " + objemp.FirstName + " " + objemp.LastName + "," + "<br/><br/>";
                strMessage += "This is informed  you that your leave has been rejected  for " + leavecount + " day/s i.e." + fromdate + "  to " + todate + ". :" + "<br/><br/>";
                strMessage += "" + Rejectionreason + ". :" + "<br/><br/>";
                strMessage += "Regards," + "<br/>";
                // strMessage += "NEC Technologies.";
                strMessage += objemp.FirstName + " " + objemp.LastName;
                new General().SendMail(objemp.EmailId.ToString(), objhr.Emailid.ToString(), "", strSubject, strMessage, 0, "", true, "", FromEmail.ToString());
            }
            return true;
        }

    }
}