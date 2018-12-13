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

namespace Domain.Operations.Setup.Columns
{
   public static class DbDeleteCoulmnSetup
    {
        public async static Task<IDTO> DeleteColumnAsync(Column column)
        {
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();
            var dyParam = new OracleDynamicParameters();
            dyParam.Add(ColumnSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)column.ID ?? DBNull.Value);
            if (await NonQueryExecuter.ExecuteNonQueryAsync(ColumnSpName.SP_DELETE_COLUMN, dyParam) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";
            return complate;
        }

        public async static Task<IDTO> DeleteColumnsAsync(long[] IDs)
        {

            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (await NonQueryExecuter.ExecuteNonQueryAsync(MultiDeleteFormater.Format(typeof(Column), IDs)) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
