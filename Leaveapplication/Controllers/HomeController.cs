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
        ////public ActionResult Index()
        //public ActionResult Index(ModuleEntity objUser, string Message, int? page)
        //{
        //    var Empcode = Convert.ToString(Session["Empcode"]);
        //    var Empid = Convert.ToString(Session["Empid"]);

        //    // var Getroles = new LeaveBLL().GetUserRoles(Empcode.ToString());
        //    List<ModuleEntity> MenuList = new LeaveBLL().GetMenu(objUser, Empid.ToString());
        //    // GetMessage(UserList.Count == 0 ? "NoRecord" : Message, "");
        //    // CreatePager(page, UserList.Count);
        //    Session["MenuList"] = MenuList;

        //    PagedList<ModuleEntity> model = new PagedList<ModuleEntity>(MenuList, page.HasValue ? Convert.ToInt32(page) : 1, Pager.GetPageSize());
        //    // TempData["Roles"] = Getroles;
        //   // return View();
        //    return View(model);
        //}
        //public ActionResult Index()
        //{
        //    return View();
        //}
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