using Leaveapplication.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UnlockFreshCMS.Controllers
{
    public class RoleController : CommonController
    {
        [HttpGet]
        public ActionResult Index(string Role, string Message)
        {
            GetMessage(Message, Role);
           // List<RoleRightsEntity> RoleList = new RoleBLL().DisplayRole(DecryptToInt(Role));
            List<RoleEntity> RoleList = new RoleBLL().DisplayRole(DecryptToInt(Role));
            RoleEntity objRole = new RoleEntity();
            if (!String.IsNullOrEmpty(Role))
            {
                objRole.RoleID = RoleList[0].RoleID;
                objRole.RoleName = RoleList[0].RoleName;
                objRole.Status = RoleList[0].Status;
            }
            ViewBag.SubModule = RoleList;
            BindUserStatusSelectList();
            return View(objRole);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(RoleEntity objRole)
        {
            string Message = "", Output = "";
            if (ModelState.IsValid)
            {
                try
                {
                    Output = new RoleBLL().InsertUpdateRole(objRole);
                    
                        Message = Output;
                }
                catch (Exception ex)
                {
                    Message = "Error";
                }
            }
            return RedirectToAction("Manage", "Role", new { Message });
        }

      
        public ActionResult Manage(string Message)
        {
            List<RoleEntity> RoleList = new RoleBLL().ManageRoles();
            GetMessage(RoleList.Count == 0 ? "NoRecord" : Message, "");
            return View(RoleList);
        }

        [HttpGet]
        //[Permissions((int)ModuleRights.DeleteRights, GetModuleID.Role)]
        public ActionResult Delete(string Role)
        {
            string Message = new RoleBLL().CheckAndDeleteRole(DecryptToInt(Role));
            return RedirectToAction("List", "Role", new { Message });
        }
    }
}