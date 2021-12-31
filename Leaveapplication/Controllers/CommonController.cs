using BLL;
using Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Leaveapplication.Controllers
{
    public class CommonController : Controller
    {
        // GET: Common
     
        public ActionResult GetMessage(string Output, string Type = "")
        {
            string Class;
            ViewBag.Message = Validations.AcknwledgementMsg(Output, out Class);
            ViewBag.Class = Class;
            ViewBag.Type = "Create ";
            if (!String.IsNullOrEmpty(Type))
                ViewBag.Type = "Edit ";
            return View();
        }

        public int DecryptToInt(string ID)
        {
            try
            {
                return Convert.ToInt32(clsEncrypt.Decrypt(ID));
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public void BindCountryDropdown(int SelectedValue = 0)
        {
            ViewData["LeavetypeDropdown"] = new SelectList(new LeaveTypeBLL().CountryDropdown(), "Value", "Text", SelectedValue);
        }
       
    }
}