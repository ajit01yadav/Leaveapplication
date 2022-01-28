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
        public void BindStatusSelectList(int SelectedValue = 1)
        {
            ViewData["StatusSelect"] = new SelectList(new General().getStatus(), "Value", "Text", SelectedValue);
        }
        public void CreatePager(int? PageNo, int TotalRowCount)
        {
            int pageSize = Pager.GetPageSize();
            int pageIndex = 1;
            pageIndex = PageNo.HasValue ? Convert.ToInt32(PageNo) : 1;
            var ItemsCount = Enumerable.Range(1, TotalRowCount).Select(x => "Item " + x);
            var pager = new Pager(ItemsCount.Count(), PageNo, pageSize, 6);
            var CreatePager = new Paging
            {
                Items = ItemsCount.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                Pager = pager
            };
            ViewBag.Paging = CreatePager;
        }

    }
}