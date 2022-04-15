using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Dapper;

    public class ModuleDAL
    {
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);

        public List<ModuleEntity> Menu(string UserId, int LeftSideDisplay, int ModuleLevel)
        {
            return this.db.Query<ModuleEntity>("SPBackOfficeMenu", new { LeftSideDisplay = LeftSideDisplay, ModuleLevel = ModuleLevel, UserId = UserId }, commandType: CommandType.StoredProcedure).ToList();
        }
    }
