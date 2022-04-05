using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RoleEntity
{
    [Required(ErrorMessage = "Please enter role name.")]
    public string RoleName { get; set; }

    [Required(ErrorMessage = "Please select status.")]
    public int Status { get; set; }
   // public string RoleRights { get; set; }
   // public bool IsSelectAll { get; set; }
    public int RoleID { get; set; }
}

public class RoleRightsEntity
{
    public int RoleRightsID { get; set; }
    public int RoleID { get; set; }
    public string RoleName { get; set; }
    public int ModuleID { get; set; }
    public string ModuleType { get; set; }
    public string ModuleName { get; set; }
    public string SubModuleName { get; set; }
    public string SubSubModuleName { get; set; }
    public int ViewRights { get; set; }
    public int EditRights { get; set; }
    public int DeleteRights { get; set; }
    public bool View { get; set; }
    public bool Edit { get; set; }
    public bool Delete { get; set; }
    public int Status { get; set; }
}
