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
  public  class LoginDAL
    {
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        public LoginEntity CheckAndValidateUser(LoginEntity Login)
        {
            return this.db.Query<LoginEntity>("Select EMPCode,EMPId,FirstName,MiddleName,LastName,EmailId,JoiningDate,ReportingToId from T_Employees where WindowsUsername= @WindowsUsername", new { Login.WindowsUsername}, commandType: CommandType.Text).SingleOrDefault();
        }
    }
}
