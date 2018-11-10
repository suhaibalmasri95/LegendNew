using Common.Interfaces;
using Common.Operations;
using Domain.Entities.Organization;
using Domain.Entities.Organization;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Organization.MenuDetails
{
    public class DBDeleteMenuSetup
    {
        public async static Task<IDTO> DeleteMenuAsync(Menu menu)
        {
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();
            var dyParam = new OracleDynamicParameters();
            dyParam.Add(MenuSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)menu.ID ?? DBNull.Value);
            if (await NonQueryExecuter.ExecuteNonQueryAsync(MenuSPName.SP_DELETE_Menu, dyParam) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
