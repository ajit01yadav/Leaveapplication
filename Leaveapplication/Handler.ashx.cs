﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace UnlockFreshCMS
{
    //public class Handler : IHttpHandler
    //{
    //    public void ProcessRequest(HttpContext context)
    //    {
    //        if (HttpContext.Current.Request["FunctionName"] != null)
    //        {
    //            switch (HttpContext.Current.Request["FunctionName"])
    //            {
    //                case "UploadProductImage":
    //                    UploadProductImage();
    //                    break;
    //                case "UploadTextEditorImage":
    //                    UploadTextEditorImage();
    //                    break;
    //            }
    //        }
    //    }

    //    public void UploadTextEditorImage()
    //    {
    //        for (int j = 0; j < HttpContext.Current.Request.Files.Count; j++)
    //        {
    //            HttpPostedFile uploadfile = HttpContext.Current.Request.Files[j];
    //            string exttension = System.IO.Path.GetExtension(uploadfile.FileName).Trim().ToLower();
    //            string ImageName = "UnlockEditor_" + DateTime.Now.ToFileTimeUtc() + exttension;
    //            string localPath = "/imgcdn/CustomImages/";
    //            if (Directory.Exists(HttpContext.Current.Server.MapPath(localPath)).Equals(false))
    //                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(localPath));
    //            string OriginalImageFullPath = localPath + ImageName;
    //            uploadfile.SaveAs(HttpContext.Current.Server.MapPath(OriginalImageFullPath));
    //            string rtnPath = OriginalImageFullPath;
    //            System.Web.HttpContext.Current.Response.Write(rtnPath);
    //        }
    //    }

    //    public void UploadProductImage()
    //    {
    //        int ProductID = Convert.ToInt32(clsEncrypt.Decrypt(HttpContext.Current.Request["ProductID"]));
    //        //int ImgResizeOption = Convert.ToInt32(HttpContext.Current.Request["ImgResizeOption"]);
    //        string PhysicalFolderPath = "~/Images/Product/";

    //        //ImageResizeEntity objImageResize = new ImageResizeBLL().DisplayImageResize(ImgResizeOption);

    //        for (int j = 0; j < HttpContext.Current.Request.Files.Count; j++)
    //        {
    //            HttpPostedFile uploadFile = HttpContext.Current.Request.Files[j];
    //            string extention = System.IO.Path.GetExtension(uploadFile.FileName);
    //            UploadPic(uploadFile, j++, PhysicalFolderPath, ProductID); //objImageResize
    //        }
    //    }

      
    //    public bool IsReusable
    //    {
    //        get
    //        {
    //            return false;
    //        }
    //    }
    //}
}