using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;

public class ContentDAL
{
    private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);


    //public string InsertUpdateContent(ContentPageEntity objcontent)
    //{
    //    var parameters = new DynamicParameters(new
    //    {
    //        objcontent.ContentPageID,
    //        objcontent.PageTitle,
    //        objcontent.PageDescription,
    //        ImageFile = objcontent.PageImage,
    //        objcontent.ImageResizeID,
    //        objcontent.PageType,
    //        objcontent.Status,
    //        objcontent.PageName,
    //        objcontent.SEOPageTitle,
    //        objcontent.SEOMetaKeyword,
    //        objcontent.SEOMetaDescription,
    //        objcontent.EntityID,
    //        objcontent.EntityType,
    //        objcontent.DataTags

    //    });
    //    parameters.Add("@Output", dbType: DbType.String, direction: ParameterDirection.Output, size: 50);
    //    this.db.Execute("SPContentPageInsertOrUpdate", parameters, commandType: CommandType.StoredProcedure);
    //    new LogsDAL().InsertAuditLogsInsertUpdate("ContentPage", "ContentPageID", objcontent.ContentPageID, Validations.LogsMessage(objcontent.ContentPageID));
    //    return parameters.Get<string>("@Output");
    //}

   

    public List<DataTags> DisplayDatatags(int EntityID, int EntityType)
    {
      //  return this.db.Query<Halfdayentity>("Select halfdayid,Date,leaveid,IsDeleted from T_halfdayLeave1 where leaveid=@leaveid and halfdayid=@halfdayid", new { halfdayid, leaveid }, commandType: CommandType.Text).ToList();
        return this.db.Query<DataTags>("Select * from DataTag where EntityID = @EntityID and EntityType = @EntityType", new { EntityID, EntityType }, commandType: CommandType.Text).ToList();
    }
}