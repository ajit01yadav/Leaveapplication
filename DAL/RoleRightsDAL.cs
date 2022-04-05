using System;
using System.Web;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

public class RoleRightsDAL
{
    private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);

    public RoleRightsEntity ViewRightsForModule(int ModuleID)
    {
        return this.db.Query<RoleRightsEntity>("SPViewRightsForModule", new { ModuleID}, commandType: CommandType.StoredProcedure).SingleOrDefault();
    }
}
