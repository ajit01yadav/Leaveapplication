using Common.Entity;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
  public  class LeaveBLL
    {
        public string InsertUpdateUsers(Leaveentiy objUsers)
        {
            return new LeaveDAL().InsertUpdateUsers(objUsers);
        }
        //public string InsertUpdateHalfday(Halfdayentity objhalfday)
        //{
        //    return new LeaveDAL().InsertUpdateHalfday(objhalfday);
        //}
        //InsertUpdateHalfday
        public List<Leaveentiy> ManageUser(Leaveentiy objUser, int EmpID )
        {
            return new LeaveDAL().ManageUser( objUser, EmpID);
        }
        public List<Leaveentiy> ApproveRejectUser(Leaveentiy objUser, string ReportingToId)
        {
            return new LeaveDAL().ApproveRejectUser(objUser, ReportingToId);
        }
       
        public decimal GetCount(string Fromdate, string Todate)
        {
            return new LeaveDAL().GetCount(Fromdate, Todate);

        }
        public decimal GetCLBalance(string empid)
        {
            return new LeaveDAL().GetCLBalance(empid);
         
        }
        public decimal GetPLBalance(string empid)
        {
            return new LeaveDAL().GetPLBalance(empid);

        }
        public Leaveentiy DisplayUsers(int leaveid)
        {
            return new LeaveDAL().DisplayUsers(leaveid);
        }
        public Leaveentiy GetleaveDetialbyid(int leaveid)
        {
            return new LeaveDAL().GetleaveDetialbyid(leaveid);
        }
        
        public string CheckAndDeleteUser(int leaveid)
        {
            return new LeaveDAL().CheckAndDeleteUser(leaveid);
        }
        public string ApproveLeave(int leaveid)
        {
            return new LeaveDAL().ApproveLeave(leaveid);
        }
        //ApproveLeave
        public List<Employeeentity> GetEmailId(int empid)
        {
            return new LeaveDAL().GetEmailId(empid);

        }
        public Employeeentity GetUserEmail(int empid)
        {
            return new LeaveDAL().GetUserEmail(empid);

        }
        public HRentity GetHREmail()
        {
            return new LeaveDAL().GetHREmail();

        }
        //GetHREmail
        public string InsertRejectreason(string Rejectionreason, int Leaveid)
        {
            return new LeaveDAL().InsertRejectreason(Rejectionreason, Leaveid);
        }
        public string UpdateStatus(int leaveid)
        {
            return new LeaveDAL().UpdateStatus(leaveid);
        }
        public string UpdateRejectStatus(int leaveid)
        {
            return new LeaveDAL().UpdateRejectStatus(leaveid);
        }
        //ManageApproveReject
        public List<Leaveentiy> ManageUserByEmpcode(int EMPId)
        {
            return new LeaveDAL().ManageUserByEmpcode(EMPId);
        }
        public List<Leaveentiy> ManageApproveReject(string ReportingToId)
        {
            return new LeaveDAL().ManageApproveReject(ReportingToId);
        }
        public List<Leaveentiy> ManageApproveReject_Test(string ReportingToId)
        {
            return new LeaveDAL().ManageApproveReject_Test(ReportingToId);
        }
        public List<ApproveRejectEntity> GetFilterdata_Test(string Reportingid, ApproveRejectEntity objleave)
        {
            return new LeaveDAL().GetFilterdata_Test(Reportingid, objleave);
        }
        public String GetUserRoles(string Empcode)
        {
            return new LeaveDAL().GetUserRoles(Empcode);
        }
        public List<ModuleEntity> GetMenu(ModuleEntity objUser, string Empcode)
        {
            return new LeaveDAL().GetMenu(objUser, Empcode);
        }

        public decimal GetApprveRejectCLBalance(int empid, int leaveid, string leavetype, int status)
        {
            return new LeaveDAL().GetApprveRejectCLBalance(empid, leaveid, leavetype, status);

        }
        public Leaveentiy DisplayUser(int leaveid)
        {
            return new LeaveDAL().DisplayUser(leaveid);
        }
        public string IsDeletedRecord(int leaveid)
        {
            return new LeaveDAL().IsDeletedRecord(leaveid);
        }
        public string IsApproved(int leaveid,Boolean IsApproved, Boolean IsRejected)
        {
            return new LeaveDAL().IsApproved(leaveid, IsApproved, IsRejected);
        }

        //IsApproved


    }
}
