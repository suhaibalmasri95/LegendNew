using Common.Interfaces;
using Domain.Entities.Organization;
using Domain.Organization.Entities;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Data;

using System.Threading.Tasks;

namespace Domain.Operations.Organization.MenuDetails
{
    public class GetMenus : Menu, IQueryable
    {
        public async Task<IEnumerable> QueryAsync()
        {
            var dyParam = new OracleDynamicParameters();
            dyParam.Add(MenuSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ID ?? DBNull.Value);
            dyParam.Add(MenuSpParams.PARAMETER_MENU_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)this.Type ?? DBNull.Value);
            dyParam.Add(MenuSpParams.PARAMETER_ST_MENUE_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.SubMenuID ?? DBNull.Value);
            dyParam.Add(MenuSpParams.PARAMETER_LANG_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.LangID ?? DBNull.Value);
            dyParam.Add(MenuSpParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);
            return await QueryExecuter.ExecuteQueryAsync<Menu>(MenuSPName.SP_LOAD_Menu, dyParam);
        }
    }
}
