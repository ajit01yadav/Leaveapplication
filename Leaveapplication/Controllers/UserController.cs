using Leaveapplication.Controllers;
using PagedList;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Leaveapplication.Controllers
{
    public class UserController : CommonController
    {
        //
        // GET: /User/
       
        public ActionResult Index(string User, string Message)
        {
            UserEntity objUser = new UserEntity();
            if (!String.IsNullOrEmpty(User))
                objUser = new UserBLL().DisplayUsers(DecryptToInt(User));
            GetMessage(Message, User);
            BindStatusSelectList(objUser != null ? objUser.Status : 1);
          //  BindRoleSelectList(objUser != null ? objUser.RoleID : 0);
            return View(objUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
      
        public ActionResult Index(UserEntity objUser)
        {
            string Output = "";
            if (ModelState.IsValid)
                Output = new UserBLL().InsertUpdateUsers(objUser);
            return (Output == "Update" ? RedirectToAction("Manage", "User", new { Message = "Update" }) : RedirectToAction("", "User", new { Message = Output }));
        }

      
        public ActionResult Manage(UserEntity objUser, string Message, int? page)
        {
            List<UserEntity> UserList = new UserBLL().ManageUser(objUser);
            GetMessage(UserList.Count == 0 ? "NoRecord" : Message, "");
            CreatePager(page, UserList.Count);
            PagedList<UserEntity> model = new PagedList<UserEntity>(UserList, page.HasValue ? Convert.ToInt32(page) : 1, Pager.GetPageSize());
            return View(model);
        }

       
        public ActionResult Delete(string User)
        {
            string Message = new UserBLL().CheckAndDeleteUser(DecryptToInt(User));
            return RedirectToAction("Manage", "User", new { Message = Message });
        }
    }
}