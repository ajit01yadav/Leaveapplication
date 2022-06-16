using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

public class LogsBLL
{
    public void InsertErrror(Exception ex, string ReffererPage)
    {
        LogsErrorEntity ErrorEnt = new LogsErrorEntity();
        string strErrorTitle = "", ErrorDescription = "", HTTP_REFERER = "";
        strErrorTitle = ex.Message;
        ErrorDescription = ex.StackTrace;

        if (HttpContext.Current.Request.ServerVariables["HTTP_REFERER"] != null)
            HTTP_REFERER = HttpContext.Current.Request.ServerVariables["HTTP_REFERER"].ToString();
            ErrorEnt.UserID = AuthenticateBLL.UserID();
       // ErrorEnt.UserID = HttpResponse.Cookies["User"]["UserID"].ToString();
        if (HttpContext.Current.Request.ServerVariables["HTTP_X_Forwarded_For"] != null)
            ErrorEnt.IPAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_Forwarded_For"].ToString();
        else
            ErrorEnt.IPAddress = HttpContext.Current.Request.UserHostAddress;
        ErrorEnt.ReffererPage = HTTP_REFERER;
        ErrorEnt.ErrorPage = HttpContext.Current.Request.RawUrl.ToString();
        ErrorEnt.ErrorTitle = ex.Message;
        ErrorEnt.ErrorDescription = ex.StackTrace;
        new LogsBLL().Insert(ErrorEnt);
      //  UnlockEntity UnlockSettings = new UnlockSettingBLL().Display();
        try
        {
            //GeneralBLL.SendErrorEmailUnlockCP(UnlockCP.ErrorNotificationsEmail, "", "", strErrorTitle, strMessage, 0);
        }
        catch (Exception Ex)
        {

        }
    }

    private void Insert(LogsErrorEntity ErrorEnt)
    {
        new LogsDAL().InsertErrorLogsInsert(ErrorEnt);
    }

    public List<LogsAuditEntity> ManageAuditLogs(LogsAuditEntity objLogsAudit)
    {
       return new LogsDAL().ManageAuditLogs(objLogsAudit);
    }

    public List<LogsErrorEntity> ManageErrorLogs(LogsErrorEntity objLogsError)
    {
        return new LogsDAL().ManageErrorLogs(objLogsError);
    }

    public List<LogsLoginEntity> ManageLogsLogin(LogsLoginEntity objLogsLogin)
    {
        return new LogsDAL().ManageLogsLogin(objLogsLogin);
    }

    public List<LogsDeleteEntity> ManageLogsDelete(LogsDeleteEntity objLogsDelete)
    {
        return new LogsDAL().ManageLogsDelete(objLogsDelete);
    }

    public void InsertLoginLogs(LoginEntity objLogin)
    {
        new LogsDAL().InsertLoginLogs(objLogin);
    }
}