using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;


public class PermissionsAttribute : ActionFilterAttribute
{
    private int ModuleID;
    private int ModuleRights;

    public PermissionsAttribute(int ModuleRights, int ModuleID)
    {
        this.ModuleID = ModuleID;
        this.ModuleRights = ModuleRights;
    }

    
}
