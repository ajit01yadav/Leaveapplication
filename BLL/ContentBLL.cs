using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

public class ContentBLL
{
    //public string InsertUpdateContent(ContentPageEntity objcontent)
    //{
    //    return new ContentDAL().InsertUpdateContent(objcontent);
    //}

    //public List<ContentPageEntity> Manage(ContentPageEntity objcontent)
    //{
    //    return new ContentDAL().Manage(objcontent);
    //}

    //public ContentPageEntity DisplayContent(int ContentPageID)
    //{
    //    return new ContentDAL().DisplayContent(ContentPageID);
    //}

    //public string CheckAndDeleteContent(int ContentPageID)
    //{
    //    return new ContentDAL().CheckAndDeleteContent(ContentPageID);
    //}

    //public string RemoveImage(int ContentPageID, string ImageName)
    //{
    //    string PhysicalFolderPath = "~/Images/Content/";
    //    string Updated = "";
    //    if (System.IO.File.Exists(HttpContext.Current.Server.MapPath(PhysicalFolderPath + "Original/" + ImageName)) == true)
    //    {
    //        System.IO.File.Delete(HttpContext.Current.Server.MapPath(PhysicalFolderPath + "Original/" + ImageName));
    //    }
    //    if (System.IO.File.Exists(HttpContext.Current.Server.MapPath(PhysicalFolderPath + ImageName)) == true)
    //    {
    //        System.IO.File.Delete(HttpContext.Current.Server.MapPath(PhysicalFolderPath + ImageName));
    //    }
    //    try
    //    {
    //        new ContentDAL().RemoveImage(ContentPageID);
    //        Updated = "ImageDeleted";
    //    }
    //    catch (Exception ex)
    //    {
    //        Updated = "Error";
    //    }
    //    return Updated;
    //}

    

    public List<DataTags> DisplayDatatags(int EntityID, int EntityType)
    {
        return new ContentDAL().DisplayDatatags(EntityID, EntityType);
    }
}
