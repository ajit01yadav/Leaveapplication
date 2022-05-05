using Common.Entity;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class LeaveDAL
    {
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        public string InsertUpdateUsers(Leaveentiy objUsers,Halfdayentity objhalfday)
      {

                var parameters = new DynamicParameters(new
            {
                  
            objUsers.leaveId,
            objUsers.Fromdate,
                objUsers.Todate,
                objUsers.leavereason,
                objUsers.LeaveStatusID,
               // objUsers.Description,
                //objUsers.leavetype,
                // objUsers.leavebalance,
                objUsers.leavecount,
                    objUsers.Status,
                    objUsers.createdon,
                    // objUsers.DynamicTextBox,
                    objUsers.EmpID,
                    objUsers.EMPCode,
               //objUsers.halfdaythree,
                    objUsers.updatedby,
                    objUsers.IsHalfdaySelect
                   // objUsers.DataTags

                });
            //SPUsersInsertUpdate3
            parameters.Add("@Output", dbType: DbType.String, direction: ParameterDirection.Output, size: 50);
            this.db.Execute("SPUsersInsertUpdate3", parameters, commandType: CommandType.StoredProcedure);
            if (objUsers.DynamicTextBox != null && objUsers.IsHalfdaySelect == true)
            {

                foreach (string textboxValue in objUsers.DynamicTextBox )
                {

                    string constr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(constr))
                    //SP_HalfdayInsertUpdate
                    //SP_HalfdaydateInsertUpdate
                    {
                        SqlCommand cmd = new SqlCommand("SP_HalfdayInsertUpdate2", con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Connection = con;
                        if (objUsers.leaveId == 0)
                        {
                            cmd.Parameters.AddWithValue("@option", "insert");
                            cmd.Parameters.AddWithValue("@EMPId", objUsers.EmpID);
                            cmd.Parameters.AddWithValue("@leaveid", objUsers.leaveId);
                            cmd.Parameters.AddWithValue("@halfdayid", objUsers.halfdayid);
                            cmd.Parameters.AddWithValue("@Date", textboxValue);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@option", "update");
                            cmd.Parameters.AddWithValue("@EMPId", objUsers.EmpID);
                            cmd.Parameters.AddWithValue("@leaveid", objUsers.leaveId);
                            cmd.Parameters.AddWithValue("@halfdayid", objUsers.halfdayid);
                            cmd.Parameters.AddWithValue("@Date", textboxValue);

                        }
                        
                       
                        
                        con.Open();
                        cmd.ExecuteNonQuery();
                        // objUsers.halfdayid="";
                        con.Close();

                    }
                }
            }

            return parameters.Get<string>("@Output");

        }
       
      
        public List<Leaveentiy> ManageUser(Leaveentiy objUser, int EmpID)
        {
            var parameters = new DynamicParameters(new
            {
                EmpID

            });
            //SPMangeLeave2
            //SPLeaveManage3
            return this.db.Query<Leaveentiy>("SPMangeLeave2", new {  objUser.Fromdate, objUser.Todate, EmpID }, commandType: CommandType.StoredProcedure).ToList();
          
        }
        public List<Halfdayentity> HalfdayCount(int leaveid)
        {
            var parameters = new DynamicParameters(new
            {
                leaveid

            });
            return this.db.Query<Halfdayentity>("Select halfdayid,leaveid from T_halfdayLeave where leaveid=@leaveid", new { leaveid }, commandType: CommandType.Text).ToList();
        }
           
         
        public List<Leaveentiy> ManageUserByEmpcode(int EMPId)
        {
            //Sp_DisplayUserByEmpid_New
            //Sp_DisplayUserByEmpid
            var parameters = new DynamicParameters(new
            {
                EMPId

            });
            return this.db.Query<Leaveentiy>("Sp_DisplayUserByEmpid", new { EMPId }, commandType: CommandType.StoredProcedure).ToList();
        }
        public List<Leaveentiy> ManageApproveReject(string ReportingToId)
        {
            //SP_GetApproveRejectDataNew
            var parameters = new DynamicParameters(new
            {
                ReportingToId

            });
            return this.db.Query<Leaveentiy>("SP_GetApproveRejectDataNew", parameters, commandType: CommandType.StoredProcedure).ToList();
          
        }

        // //ManageApproveReject
        public List<Leaveentiy> ApproveRejectUser(Leaveentiy objUser, string ReportingToId)
        {
            var parameters = new DynamicParameters(new
            {
                ReportingToId


            });
            //SPMangeLeave2
            //SPLeaveManage3
            //SP_GetLeaveDetails2
            return this.db.Query<Leaveentiy>("SP_GetLeaveDetails2New", new { objUser.FirstName, objUser.Status, ReportingToId }, commandType: CommandType.StoredProcedure).ToList();
        }
        public string Getdata(string empid, string leavetype)
        {
            var parameters = new DynamicParameters(new
            {
                empid,
                 leavetype
               
            });
           
            parameters.Add("@Output", dbType: DbType.String, direction: ParameterDirection.Output, size: 50);
            this.db.Execute("Sp_TotalLeaveType", parameters, commandType: CommandType.StoredProcedure);
            return parameters.Get<string>("@Output");
        }
      
        public decimal GetCLBalance(string empid)
        {
            var parameters = new DynamicParameters(new
            {
                empid
               
            });
            return this.db.Query<decimal>("Sp_TotalCLBalance", new { empid }, commandType: CommandType.StoredProcedure).SingleOrDefault();

        }
        public decimal GetCount(string Fromdate, string Todate)
        {
            //Sp_TotlaBussinessdays
            var parameters = new DynamicParameters(new
            {
                Fromdate,
                Todate

            });
            return this.db.Query<decimal>("Sp_TotlaBussinessdays", new { Fromdate, Todate }, commandType: CommandType.StoredProcedure).SingleOrDefault();

        }
        public decimal GetPLBalance(string empid)
        {
            var parameters = new DynamicParameters(new
            {
                empid

            });
            return this.db.Query<decimal>("Sp_TotalPLBalance", new { empid }, commandType: CommandType.StoredProcedure).SingleOrDefault();
        }
        public Leaveentiy DisplayUsers(int leaveid)
        {
            var parameters = new DynamicParameters(new
            {
                leaveid

            });
            return this.db.Query<Leaveentiy>("Sp_DisplayUser", new { leaveid }, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }
        public Leaveentiy GetleaveDetialbyid(int leaveid)
        {
            var parameters = new DynamicParameters(new
            {
                leaveid

            });
            return this.db.Query<Leaveentiy>("Sp_DisplayUser", new { leaveid }, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }
       
        public string CheckAndDeleteUser(int leaveid)
        {
            var parameters = new DynamicParameters(new
            {
                leaveid
              
            });
             parameters.Add("@Output", dbType: DbType.String, direction: ParameterDirection.Output, size: 20);
            this.db.Execute("SPUserDelete", parameters, commandType: CommandType.StoredProcedure);
            return parameters.Get<string>("@Output");
        }
        public string ApproveLeave(int leaveid)
        {
            var parameters = new DynamicParameters(new
            {
                leaveid
               
            });
            parameters.Add("@Output", dbType: DbType.String, direction: ParameterDirection.Output, size: 20);
            this.db.Execute("SPUserApprove", parameters, commandType: CommandType.StoredProcedure);
            return parameters.Get<string>("@Output");
        }
        public List<Employeeentity> GetEmailId(int empid)
        {
            var parameters = new DynamicParameters(new
            {
                empid
                // IPAddress = HttpContext.Current.Request.UserHostAddress,
                //  CreatedBy = AuthenticateDAL.UserID()
            });
            //SPMangeLeave2
            //SPLeaveManage3
            // return this.db.Query<Employeeentity>("USP_Employee_GetManagerEmailIdNew", commandType: CommandType.StoredProcedure).ToList();
            return this.db.Query<Employeeentity>("USP_Employee_GetManagerEmailIdNew", new { empid }, commandType: CommandType.StoredProcedure).ToList();
        }
        public Employeeentity GetUserEmail(int empid)
        {
            var parameters = new DynamicParameters(new
            {
                empid
            });
            return this.db.Query<Employeeentity>("usp_Approval_email", new { empid }, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }
        public HRentity GetHREmail()
        {
            return this.db.Query<HRentity>("usp_GetHr_email", commandType: CommandType.StoredProcedure).FirstOrDefault();
        }
        //GetHREmail

        public string InsertRejectreason(string Rejectionreason, int Leaveid)
        {
            var parameters = new DynamicParameters(new
            {
                Rejectionreason,
                Leaveid
            });
            parameters.Add("@Output", dbType: DbType.String, direction: ParameterDirection.Output, size: 50);
            this.db.Execute("SP_InsertRejection", parameters, commandType: CommandType.StoredProcedure);
            return parameters.Get<string>("@Output");

        }
        public string UpdateStatus(int leaveid)
        {
            var parameters = new DynamicParameters(new
            {
                leaveid

            });
            parameters.Add("@Output", dbType: DbType.String, direction: ParameterDirection.Output, size: 20);
            this.db.Execute("Sp_UpdateStatus", parameters, commandType: CommandType.StoredProcedure);
            return parameters.Get<string>("@Output");
           
        }
        public string UpdateRejectStatus(int leaveid)
        {
            var parameters = new DynamicParameters(new
            {
                leaveid

            });
            parameters.Add("@Output", dbType: DbType.String, direction: ParameterDirection.Output, size: 20);
            this.db.Execute("Sp_UpdateRejectStatus", parameters, commandType: CommandType.StoredProcedure);
            return parameters.Get<string>("@Output");

        }
        public List<Leaveentiy> ManageApproveReject_Test(string ReportingToId)
        {
            var parameters = new DynamicParameters(new
            {
                ReportingToId,

            });

            return this.db.Query<Leaveentiy>("SP_GetApproveRejectDataNew", new { ReportingToId }, commandType: CommandType.StoredProcedure).ToList();
        }
        public List<ApproveRejectEntity> GetFilterdata_Test(string Reportingid, ApproveRejectEntity objleave)
        {
            var parameters = new DynamicParameters(new
            {
                Reportingid
               
            });

            return this.db.Query<ApproveRejectEntity>("SP_GetFilterData", new { Reportingid, objleave.Status, objleave.FirstName}, commandType: CommandType.StoredProcedure).ToList();
         
        }
        public string GetUserRoles(string EMPCode)
        {
            return this.db.Query<string>("Sp_GetUserRole", new { EMPCode }, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }
        public decimal GetApprveRejectCLBalance(int empid, int leaveid, string leavetype, int status)
        {
            //Sp_TotalCLBalance_New1
            var parameters = new DynamicParameters(new
            {
                empid,
                leaveid,
                leavetype,
                status

            });
            return this.db.Query<decimal>("Sp_TotalCLBalance_New1", new { empid, leaveid, leavetype, status }, commandType: CommandType.StoredProcedure).SingleOrDefault();

        }
        public decimal GetApprveRejectCLPLBalance(int empid, int leaveid, string leavetype, int status)
        {
            //Sp_TotalCLBalance_New1
            var parameters = new DynamicParameters(new
            {
                empid,
                leaveid,
                leavetype,
                status

            });
            return this.db.Query<decimal>("Sp_TotalCLPLleave", new { empid, leaveid, leavetype, status }, commandType: CommandType.StoredProcedure).SingleOrDefault();

        }
        public Leaveentiy DisplayUser(int leaveid)
        {
            var parameters = new DynamicParameters(new
            {
                leaveid

            });
            return this.db.Query<Leaveentiy>("Sp_DisplayUser", new { leaveid }, commandType: CommandType.StoredProcedure).FirstOrDefault();

        }
        public string IsDeletedRecord(int leaveid)
        {
            var parameters = new DynamicParameters(new
            {
                leaveid

            });
            return this.db.Query<string>("Sp_GetIsDeltedReocrd", new { leaveid }, commandType: CommandType.StoredProcedure).FirstOrDefault();

        }
       
        public string IsApproved(int leaveid, Boolean IsApproved, Boolean IsRejected)
        {
            var parameters = new DynamicParameters(new
            {
                leaveid

            });
            return this.db.Query<string>("Sp_IsApproved", new { leaveid, IsApproved, IsRejected }, commandType: CommandType.StoredProcedure).FirstOrDefault();

        }
        public List<ModuleEntity> GetMenu(ModuleEntity objUser, string EmpId)
        {
            return this.db.Query<ModuleEntity>("USP_GetMenuItemDataNew", new { EmpId }, commandType: CommandType.StoredProcedure).ToList();
        }
        public int GetHalfdaycount(int leaveid, Boolean IsDeleted)
        {
            var parameters = new DynamicParameters(new
            {
                leaveid

            });
            return this.db.Query<int>("Sp_GetHalfdaycount", new { leaveid, IsDeleted }, commandType: CommandType.StoredProcedure).FirstOrDefault();

        }
        //GetHalfdaycount

    }
}
