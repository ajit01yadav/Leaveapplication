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
       // public ActionResult AdminMenu(ModuleEntity objUser, int? page)
       // {
          //  string Menu = new ModuleBLL().BackOfficeMainMenu();
           // ModuleEntity objMainMenu = new ModuleEntity();
          //  objMainMenu.PageName = Menu;
           // return PartialView("~/Views/Menu/AdminMenu.cshtml", objMainMenu);


           // var Empcode = Convert.ToString(Session["Empid"]);

          //  List<ModuleEntity> MenuList = new LeaveBLL().GetMenu(objUser, Empcode.ToString());
          //  CreatePager(page, MenuList.Count);
           // PagedList<ModuleEntity> model = new PagedList<ModuleEntity>(MenuList, page.HasValue ? Convert.ToInt32(page) : 1, Pager.GetPageSize());

            //return View(MenuList);
            // return PartialView("~/Views/Menu/AdminMenu.cshtml", MenuList);
          //  return PartialView("_Menu.cshtml", model);


            //string Menu = new ModuleBLL().BackOfficeMainMenu();
            //MainMenuEntity objMainMenu = new MainMenuEntity();
            //objMainMenu.ModuleName = Menu;
            //return PartialView("~/Views/Menu/AdminMenu.cshtml", objMainMenu);
      //  }
        public ActionResult Computer_Action()
        {
            return View();
        }
        public ActionResult Maths_Action()
        {
            return View();
        }
        public ActionResult Marketing_Action()
        {
            return View();
        }
        public ActionResult Finiance_Action()
        {
            return View();
        }



    }
}