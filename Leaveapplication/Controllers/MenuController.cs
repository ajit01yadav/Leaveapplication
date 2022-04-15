using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Text;
using System.Data;
using PagedList;
using Leaveapplication.Controllers;
using BLL;

namespace Leaveapplication.Controllers
{
    public class MenuController : CommonController
    {
       // public ActionResult AdminMenu()
        public ActionResult AdminMenu(ModuleEntity objUser)
        {
          //  string Menu = new ModuleBLL().BackOfficeMainMenu();
           // ModuleEntity objMainMenu = new ModuleEntity();
          //  objMainMenu.PageName = Menu;
           // return PartialView("~/Views/Menu/AdminMenu.cshtml", objMainMenu);


            var Empcode = Convert.ToString(Session["Empid"]);

            List<ModuleEntity> MenuList = new LeaveBLL().GetMenu(objUser, Empcode.ToString());
           
            //return View(MenuList);
           // return PartialView("~/Views/Menu/AdminMenu.cshtml", MenuList);
            return PartialView("_Menu.cshtml", MenuList);


            //string Menu = new ModuleBLL().BackOfficeMainMenu();
            //MainMenuEntity objMainMenu = new MainMenuEntity();
            //objMainMenu.ModuleName = Menu;
            //return PartialView("~/Views/Menu/AdminMenu.cshtml", objMainMenu);
        }

     

    }
}