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

namespace Domain.Operations.Setup.SubBusiness
{
    public static class DBDeleteSubBusinessSetup
    {
        public async static Task<IDTO> DeleteSubLineOfBusniessLineAsync(SubLineOfBusnies subLineOfBusnies)
        {
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();
            var dyParam = new OracleDynamicParameters();
            dyParam.Add(SubBusniesSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)subLineOfBusnies.ID ?? DBNull.Value);
            if (await NonQueryExecuter.ExecuteNonQueryAsync(SubBusniesSPName.SP_DELETE_SubBusnies, dyParam) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";
            return complate;
        }

        public async static Task<IDTO> DeleteSubLineOfBusniessesLinesAsync(long[] IDs)
        {

            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (await NonQueryExecuter.ExecuteNonQueryAsync(MultiDeleteFormater.Format(typeof(SubLineOfBusnies), IDs)) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}

