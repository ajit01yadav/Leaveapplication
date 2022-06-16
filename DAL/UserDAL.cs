using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;

public class UserDAL
{
    private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);

    public string InsertUpdateUsers(UserEntity objUsers)
    {
        string LastLoginIP = HttpContext.Current.Request.UserHostAddress;
        var parameters = new DynamicParameters(new
        {
            objUsers.UserId,
            objUsers.Password,
            objUsers.FirstName,
            objUsers.LastName,
            objUsers.Email,
            objUsers.Status,
            objUsers.RoleID,
            objUsers.IsLockedOut,
            objUsers.UpdateBy,
            objUsers.UpdateOn,
            objUsers.FailedPasswordAttemptCount,
        });
        parameters.Add("@Output", dbType: DbType.String, direction: ParameterDirection.Output, size: 50);
        this.db.Execute("SPUsersInsertUpdate", parameters, commandType: CommandType.StoredProcedure);
       // new LogsDAL().InsertAuditLogsInsertUpdate("Users", "UserId", objUsers.UserId, Validations.LogsMessage(objUsers.UserId));
        return parameters.Get<string>("@Output");
    }

    public List<UserEntity> ManageUser(UserEntity objUser)
    {
        return this.db.Query<UserEntity>("SPUserManage", new { objUser.FirstName, objUser.LastName, objUser.Status }, commandType: CommandType.StoredProcedure).ToList();
    }

    public UserEntity DisplayUsers(int UserID)
    {
        return this.db.Query<UserEntity>("Select * from Users where UserId = @UserId", new { UserID }, commandType: CommandType.Text).SingleOrDefault();
    }

    public string CheckAndDeleteUser(int UserId)
    {
        var parameters = new DynamicParameters(new
        {
            UserId,
            IPAddress = HttpContext.Current.Request.UserHostAddress,
            CreatedBy = AuthenticateDAL.UserID()
        });
        parameters.Add("@Output", dbType: DbType.String, direction: ParameterDirection.Output, size: 20);
        this.db.Execute("sp_LA_UserDelete", parameters, commandType: CommandType.StoredProcedure);
        return parameters.Get<string>("@Output");
    }

    //public string UpdateUserPassword(int UserID, string CurrentPwd, string NewPwd)
    //{
    //    var parameters = new DynamicParameters(new { UserID, CurrentPwd, NewPwd });
    //    parameters.Add("@Output", dbType: DbType.String, direction: ParameterDirection.Output, size: 10);
    //    this.db.Execute("SPChangePassword", parameters, commandType: CommandType.StoredProcedure);
    //    return parameters.Get<string>("@Output");
    //}
}