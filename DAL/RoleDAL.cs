using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Net.Http;

public class RoleDAL
{
    private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);

    public string InsertUpdateRole(RoleEntity objRole)
    {
        var Parameters = new DynamicParameters(new { objRole.RoleID, objRole.RoleName, objRole.Status });
        Parameters.Add("@Output", dbType: DbType.String, direction: ParameterDirection.Output, size: 10);
        this.db.Execute("SPRoleInsertUpdate", Parameters, commandType: CommandType.StoredProcedure);
       // new LogsDAL().InsertAuditLogsInsertUpdate("Roles", "RoleID", objRole.RoleID, Validations.LogsMessage(objRole.RoleID));
        return Parameters.Get<string>("@Output");
    }

    public void InsertUpdateRoleRights(RoleRightsEntity objRoleRights)
    {
        this.db.Execute("SPRoleRightsInsertUpdate", new { objRoleRights.RoleRightsID, objRoleRights.RoleID, objRoleRights.ModuleID, objRoleRights.ViewRights, objRoleRights.EditRights, objRoleRights.DeleteRights }, commandType: CommandType.StoredProcedure);
    }

    public List<RoleEntity> ManageRoles()
    {
        return this.db.Query<RoleEntity>("SPRolesManage", commandType: CommandType.StoredProcedure).ToList();
    }

    public List<RoleEntity> DisplayRole(int RoleID)
    {
        return this.db.Query<RoleEntity>("SPRolesDisplayByID", new { RoleID }, commandType: CommandType.StoredProcedure).ToList();
    }

    public string CheckAndDeleteRole(int RoleID)
    {
        var Parameters = new DynamicParameters(new
        {
            RoleID,
         
        });
        Parameters.Add("@Output", dbType: DbType.String, direction: ParameterDirection.Output, size: 20);
        this.db.Execute("SPRoleDelete", Parameters, commandType: CommandType.StoredProcedure);
        return Parameters.Get<string>("@Output");
    }
}
