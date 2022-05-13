using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

public class ModuleEntity
{
    public int PageID { get; set; }
    public int ParentID { get; set; }
   
    public string PageName { get; set; }

    public string ControllerName { get; set; }
    public string ActionName { get; set; }
    public string PageNameURL { get; set; }
    public bool IsActive { get; set; }
    public int CreatedBy { get; set; }
    public int MenuOrderID { get; set; }
    public int ModuleType { get; set; }
    public DateTime CreatedDate { get; set; }
    public List<ModuleEntity> SubMenu { get; set; }


}
public class Menu_List
{
    public int M_ID { get; set; }
    public int? M_P_ID { get; set; }
    public string M_NAME { get; set; }
    public string CONTROLLER_NAME { get; set; }
    public string ACTION_NAME { get; set; }
}
public class MenuModel
{
    public int MenuId { get; set; }
    public int? ParentMenuId { get; set; }
    public string Title { get; set; }
    public string Controller { get; set; }
    public string Action { get; set; }
}
public partial class MenuMaster
{
    public int MenuId { get; set; }
    public string MenuText { get; set; }
    public string Description { get; set; }
    public Nullable<int> ParentID { get; set; }
    public string ControllerName { get; set; }
    public string ActionName { get; set; }
    public int ParentId { get; set; }

    public bool IsChecked { get; set; }
    public List<MenuMaster> menus { get; set; }
    public IEnumerable<SelectListItem> users { get; set; }
}

public class MenuItem
{
    public string LinkName { get; set; }
    public string Link { get; set; }
}


