﻿using Common.Entity;
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
        public string InsertUpdateUsers(Leaveentiy objUsers)
      {
            
  
           var parameters = new DynamicParameters(new
           {
               objUsers.leaveId,
               objUsers.Fromdate,
               objUsers.Todate,
               objUsers.leavereason,
               objUsers.LeaveStatusID,
               objUsers.Description,
               //objUsers.leavetype,
              // objUsers.leavebalance,
              objUsers.leavecount,
               objUsers.createdon,
              // objUsers.updatedon
              objUsers.updatedby
           });
        
            parameters.Add("@Output", dbType: DbType.String, direction: ParameterDirection.Output, size: 50);
            this.db.Execute("SPUsersInsertUpdate1", parameters, commandType: CommandType.StoredProcedure);
            return parameters.Get<string>("@Output");

        }
        public List<Leaveentiy> ManageUser(Leaveentiy objUser)
        {
            return this.db.Query<Leaveentiy>("SPMangeLeave",  commandType: CommandType.StoredProcedure).ToList();
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
      
        public int GetCLBalance(string empid)
        {
            var parameters = new DynamicParameters(new
            {
                empid
               
            });
            return this.db.Query<int>("Sp_TotalCLBalance", new { empid }, commandType: CommandType.Text).SingleOrDefault();

        }
        public int GetCount(string Fromdate, string Todate)
        {
            var parameters = new DynamicParameters(new
            {
                Fromdate,
                Todate

            });
            return this.db.Query<int>("Sp_TotlaBussinessdays", new { Fromdate, Todate }, commandType: CommandType.StoredProcedure).SingleOrDefault();

        }
        public int GetPLBalance(string empid)
        {
            var parameters = new DynamicParameters(new
            {
                empid

            });
            return this.db.Query<int>("Sp_TotalPLBalance", new { empid }, commandType: CommandType.Text).SingleOrDefault();
        }
        public Leaveentiy DisplayUsers(int leaveid)
        {
            var parameters = new DynamicParameters(new
            {
                leaveid

            });
            // return this.db.Query<Leaveentiy>("Select * from Tbl_leave1  where  leaveid=@leaveid order by createdon desc", new { leaveid }, commandType: CommandType.Text).SingleOrDefault();
            return this.db.Query<Leaveentiy>("Sp_DisplayUser", new { leaveid }, commandType: CommandType.StoredProcedure).SingleOrDefault();
        }
        public string CheckAndDeleteUser(int leaveid)
        {
            var parameters = new DynamicParameters(new
            {
                leaveid
               // IPAddress = HttpContext.Current.Request.UserHostAddress,
              //  CreatedBy = AuthenticateDAL.UserID()
            });
             parameters.Add("@Output", dbType: DbType.String, direction: ParameterDirection.Output, size: 20);
           // return this.db.Query<string>("Delete from Tbl_leave1 where leaveid=@leaveid", new { leaveid }, commandType: CommandType.Text).SingleOrDefault();
            this.db.Execute("SPUserDelete", parameters, commandType: CommandType.StoredProcedure);
            return parameters.Get<string>("@Output");
        }
    }
}
