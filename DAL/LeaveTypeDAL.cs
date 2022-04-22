﻿using Common.Entity;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LeaveTypeDAL
    {
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);

        public List<Leaveentiy> LeaveTypeDropdown()
        {
            string str = "Select LeaveStatusID,Description from LeaveStatus where LeaveStatusID not in(6,7,8,9,10)";
            //string str = "Select * from LeaveStatus where LeaveStatusID not in(3,6,7,8,9,10)";
             return this.db.Query<Leaveentiy>(str, commandType: CommandType.Text).ToList();
        }
        public List<ApproveStatusentity> ApproveStatusDropdown()
        {
            string str = "Select LeaveStatusID,Description from LeaveStatus where LeaveStatusID not in(6,7,8,9,10)";
            //string str = "Select * from LeaveStatus where LeaveStatusID not in(3,6,7,8,9,10)";
            return this.db.Query<ApproveStatusentity>(str, commandType: CommandType.Text).ToList();
        }


    }
}

