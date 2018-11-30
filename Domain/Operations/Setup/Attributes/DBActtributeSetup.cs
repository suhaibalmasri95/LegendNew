using Common.Interfaces;
using Common.Operations;
using Domain.Entities.Setup;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Setup.Attributes
{
    public static class DBActtributeSetup
    {
        public async static Task<IDTO> AddUpdateMode(Acttribute busnies)
        {
            string SPName = "";
            string message = "";
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (busnies.ID.HasValue)
            {
                oracleParams.Add(AttributesSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)busnies.ID ?? DBNull.Value);
                SPName = AttributesPName.SP_UPADTE_Attribute;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(AttributesSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = AttributesPName.SP_INSERT_Attribute;
                message = "Inserted Successfully";
            }
            oracleParams.Add(AttributesSpParams.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)busnies.Name ?? DBNull.Value, 1000);
            oracleParams.Add(AttributesSpParams.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)busnies.Name2 ?? DBNull.Value, 1000);
            oracleParams.Add(AttributesSpParams.PARAMETER_TYPE, OracleDbType.Long, ParameterDirection.Input, (object)busnies.Type ?? DBNull.Value, 1000);
            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)
                complate.message = message;
            else
                complate.message = "Operation Failed";

            return complate;
        }

    }
}
