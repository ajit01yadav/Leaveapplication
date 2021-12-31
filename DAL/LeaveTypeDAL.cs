using Common.Entity;
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

        public List<Leaveentiy> CountryDropdown()
        {
            string str = "Select LeaveStatusID,Description from LeaveStatus where LeaveStatusID not in(3,6,7,8,9,10)";
            //string str = "Select * from LeaveStatus where LeaveStatusID not in(3,6,7,8,9,10)";
             return this.db.Query<Leaveentiy>(str, commandType: CommandType.Text).ToList();
        }
     

    }
}

