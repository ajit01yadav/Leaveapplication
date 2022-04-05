using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class LogsErrorEntity
{
    public int ErrorID { get; set; }
    public DateTime ErrorDate { get; set; }
    public DateTime? ErrorFromDate { get; set; }
    public DateTime? ErrorToDate { get; set; }
    public int UserID { get; set; }
    public string IPAddress { get; set; }
    public string ReffererPage { get; set; }
    public string ErrorPage { get; set; }
    public string ErrorTitle { get; set; }
    public string ErrorDescription { get; set; }
    public string ErrorSortBy { get; set; }
    public string Name { get; set; }
    public IEnumerable<string> PurgeLogID { get; set; }
}

public class LogsLoginEntity
{
    public int LoginLogID { get; set; }
    public int UserID { get; set; }
    public DateTime? LoginDate { get; set; }
    public string IPAddress { get; set; }
    public string Name { get; set; }
    public string SortBy { get; set; }
}


public class LogsDeleteEntity
{
    public int LogID { get; set; }
    public string LogName { get; set; }
    public string IPAddress { get; set; }
    public int CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string Name { get; set; }
    public string SortBy { get; set; }
    public string TableName { get; set; }
    public string ColumnName { get; set; }
    public int ColumnID { get; set; }
    public bool IsRestorable { get; set; }
}

public class LogsAuditEntity
{
    public string IPAddress { get; set; }
    public int CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string LogStatus { get; set; }
    public string TableName { get; set; }
    public string CreatedByName { get; set; }
    public string ColumnName { get; set; }
    public int ColumnID { get; set; }
}


