using Common.Interfaces;
using Common.Operations;
using Domain.Entities.Organization;
using Domain.Entities.Organization;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Organization.MenuDetails
{
    public static class DBMenuSetup
    {
        public async static Task<IDTO> AddUpdateMode(Menu menu)
        {
            string SPName = "";
            string message = "";
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();
            if (menu.ID.HasValue)
            {
                oracleParams.Add(MenuSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)menu.ID ?? DBNull.Value);
                SPName = MenuSPName.SP_UPADTE_Menu;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(MenuSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = MenuSPName.SP_INSERT_Menu;
                message = "Inserted Successfully";
            }

            oracleParams.Add(MenuSpParams.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)menu.Name ?? DBNull.Value, 500);
            oracleParams.Add(MenuSpParams.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)menu.Name2 ?? DBNull.Value, 500);
            oracleParams.Add(MenuSpParams.PARAMETER_MENU_ORDER, OracleDbType.Int32, ParameterDirection.Input, (object)menu.Order ?? DBNull.Value);
            oracleParams.Add(MenuSpParams.PARAMETER_MENU_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)menu.Type ?? DBNull.Value);
            oracleParams.Add(MenuSpParams.PARAMETER_URL, OracleDbType.Varchar2, ParameterDirection.Input, (object)menu.Url ?? DBNull.Value,1000);
            oracleParams.Add(MenuSpParams.PARAMETER_ST_MENUE_ID, OracleDbType.Int64, ParameterDirection.Input, (object)menu.SubMenuID ?? DBNull.Value);

            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)
                complate.message = message;
            else
                complate.message = "Operation Failed";
            return complate;
        }
    }
}
