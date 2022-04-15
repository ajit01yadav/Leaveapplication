using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;

public class ModuleBLL
{
    public string BackOfficeMainMenu()
    {
        string UserID = AuthenticateBLL.UserID().ToString();
        StringBuilder sb = new StringBuilder();
        List<ModuleEntity> MenuItems = new ModuleDAL().Menu(UserID, 1, -1);

        string strCssClassSelected = "";

        int OriginalID = 0;

        //string urlAbsolutePath = "";// HttpContext.Current.Request.Url.AbsolutePath;

        string urlAbsolutePath = HttpContext.Current.Request.Url.AbsolutePath;

        FileInfo url = new FileInfo(urlAbsolutePath);
        string urlCurrent = url.Name.ToLower();

        List<ModuleEntity> results = MenuItems.FindAll(p => p.PageNameURL == urlCurrent);
        if (results.Count != 0)
        {
            OriginalID = results[0].PageID;
        }

        List<ModuleEntity> resultParent = MenuItems.FindAll(p => p.ParentID == 0);
      

        return sb.ToString();
    }


}
