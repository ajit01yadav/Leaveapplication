using Common.Entity;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BLL
{
  public  class LeaveTypeBLL
    {
        //public List<Leaveentiy> CountryDropdown()
        //{
        //    return new LeaveTypeDAL().CountryDropdown();
        //}
        //public List<SelectListItem> BindProductCategorySelectList()
        //{
        //    List<Leaveentiy> Contentlist = new LeaveTypeDAL().CountryDropdown();
        //    List<SelectListItem> items = new List<SelectListItem>();
        //    items.Add(new SelectListItem
        //    {
        //        Text = "Select",
        //        Value = "0",
        //    });
        //    return GetProductCategory(Contentlist, items);
        //}

        public List<SelectListItem> CountryDropdown()
        {
            List<Leaveentiy> Contentlist = new LeaveTypeDAL().CountryDropdown();
            List<SelectListItem> items = new List<SelectListItem>();
            return GetProductCategory(Contentlist, items);
        }
        private List<SelectListItem> GetProductCategory(List<Leaveentiy> Contentlist, List<SelectListItem> items)
        {
            foreach (Leaveentiy Leavetype in Contentlist)
            {
                items.Add(new SelectListItem
                {
                    Text = Leavetype.Description,
                    Value = Leavetype.LeaveStatusID.ToString()
                });
            }
            return items;
        }


    }
}
