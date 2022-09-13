using BLL;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Leaveapplication.Controllers
{
    public class HomeController : Controller
    {
      
        public ActionResult Index(ModuleEntity objUser)
        {
          //  using (MenuMaster db = new MenuMaster())
           // {
                var Empcode = Convert.ToString(Session["Empcode"]);
                var Empid = Convert.ToString(Session["Empid"]);
                List<ModuleEntity> MenuList = new LeaveBLL().GetMenu(objUser, Empid.ToString());
                Session["MenuList"] = MenuList;
          //  }
            return View();
        }



        //public ActionResult GetMenuData(ModuleEntity objUser)
        //{
        //    var Empcode = Convert.ToString(Session["Empcode"]);
        //       var Empid = Convert.ToString(Session["Empid"]);
        //    List<ModuleEntity> MenuList = new LeaveBLL().GetMenu(objUser, Empid.ToString());
        //    return View("Menu", MenuList);
        //}


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}