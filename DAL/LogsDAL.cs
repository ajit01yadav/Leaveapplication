using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Web;

public class LogsDAL
{
    private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);

    public void InsertErrorLogsInsert(LogsErrorEntity Error)
    {
        this.db.Execute("SPLogsErrorInsert", new { Error.UserID, Error.IPAddress, Error.ReffererPage, Error.ErrorPage, Error.ErrorTitle, Error.ErrorDescription }, commandType: CommandType.StoredProcedure);
    }

    //public void InsertAuditLogsInsertUpdate(string TableName, string ColumnName, int? ColumnID, string LogStatus, string LogMessage = null)
    //{
    //    this.db.Execute("SPLogsAuditInsert", new { IPAddress = HttpContext.Current.Request.UserHostAddress, CreatedBy = AuthenticateDAL.UserID(), CreatedByName = AuthenticateDAL.FirstName() + " " + AuthenticateDAL.LastName(), LogStatus, TableName, ColumnName, ColumnID, LogMessage }, commandType: CommandType.StoredProcedure);
    //}

    public List<LogsAuditEntity> ManageAuditLogs(LogsAuditEntity objLogsAudit)
    {
        return this.db.Query<LogsAuditEntity>("SPLogsAuditManage", new { objLogsAudit.TableName, objLogsAudit.ColumnName, objLogsAudit.ColumnID, objLogsAudit.CreatedBy, objLogsAudit.CreatedOn }, commandType: CommandType.StoredProcedure).ToList();
    }

    public List<LogsErrorEntity> ManageErrorLogs(LogsErrorEntity objLogsError)
    {
        return this.db.Query<LogsErrorEntity>("SPLogsErrorManage", new { FromDate = objLogsError.ErrorFromDate, ToDate = objLogsError.ErrorToDate, SortBy = objLogsError.ErrorSortBy }, commandType: CommandType.StoredProcedure).ToList();
    }

    public List<LogsLoginEntity> ManageLogsLogin(LogsLoginEntity objLogsLogin)
    {
        return this.db.Query<LogsLoginEntity>("SPLogsLoginManage", new { objLogsLogin.Name, objLogsLogin.LoginDate, objLogsLogin.IPAddress, objLogsLogin.SortBy }, commandType: CommandType.StoredProcedure).ToList();
    }

    public List<LogsDeleteEntity> ManageLogsDelete(LogsDeleteEntity objLogsDelete)
    {
        return this.db.Query<LogsDeleteEntity>("SPLogsDeleteManage", new { objLogsDelete.Name, objLogsDelete.LogName, objLogsDelete.TableName, objLogsDelete.CreatedOn, objLogsDelete.SortBy }, commandType: CommandType.StoredProcedure).ToList();
    }

    public void InsertLoginLogs(LoginEntity objLogin)
    {
        this.db.Execute("SPLogsLoginInsert", new { objLogin.EMPId, IPAddress = HttpContext.Current.Request.UserHostAddress }, commandType: CommandType.StoredProcedure);
    }

    public string DeleteErrorLogs(string PurgeLogID)
    {
        var Parameters = new DynamicParameters(new { PurgeLogID });
        Parameters.Add("@Output", dbType: DbType.String, direction: ParameterDirection.Output, size: 15);
        this.db.Execute("SPLogsErrorPurge", Parameters, commandType: CommandType.StoredProcedure);
        return Parameters.Get<string>("@Output");
    }


    //public string CheckAndRestoreDeletedLog(int LogID)
    //{
    //    var Parameters = new DynamicParameters(new {LogID , UserID =  AuthenticateDAL.UserID(), UserName = AuthenticateDAL.FirstName() + ' ' + AuthenticateDAL.LastName(), IPAddress = HttpContext.Current.Request.UserHostAddress});
    //    Parameters.Add("@Output", dbType: DbType.String, direction: ParameterDirection.Output, size: 15);
    //    this.db.Query<LogsDeleteEntity>("SPLogCheckAndRestore", Parameters, commandType: CommandType.StoredProcedure);
    //    return Parameters.Get<string>("@Output");
    //}
}
