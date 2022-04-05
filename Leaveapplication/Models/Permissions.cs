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

    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        bool HasRight = false;
        RoleRightsEntity rightsEntity = new RoleRightsBLL().ViewRightsForModule(ModuleID);
        if (rightsEntity != null)
        {
            var ViewBag = filterContext.Controller.ViewBag;
            switch (ModuleRights)
            {
                case 0: //Create Rights
                    ViewBag.SaveRights = rightsEntity.EditRights;
                    ViewBag.DeleteRights = rightsEntity.DeleteRights;
                    HasRight = rightsEntity.ViewRights == 1 ? true : false;
                    break;
                case 1: //Manage Rights
                    ViewBag.SaveRights = rightsEntity.EditRights;
                    ViewBag.DeleteRights = rightsEntity.DeleteRights;
                    HasRight = rightsEntity.ViewRights == 1 ? true : false;
                    break;
                case 2: //Delete Rights
                    ViewBag.SaveRights = rightsEntity.EditRights;
                    ViewBag.DeleteRights = rightsEntity.DeleteRights;
                    HasRight = rightsEntity.ViewRights == 1 && rightsEntity.DeleteRights == 1 ? true : false;
                    break;
            }
        }
        if (!HasRight)
        {
            RouteValueDictionary routeValues = new RouteValueDictionary(new
            {
                action = "",
                controller = "RestrictedAccess",
            });
            filterContext.Result = new RedirectToRouteResult(routeValues);
        }
    }
}
