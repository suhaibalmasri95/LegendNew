using System;
using System.Data;
using System.Threading.Tasks;
using Common.Interfaces;
using Common.Operations;
using Domain.Entities.Production;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;

namespace Domain.Operations.Production.Factors
{
    public static class DeleteMode
    {
        public async static Task<IDTO> DeleteFactor(Factor factor)
        {
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();
            var dyParam = new OracleDynamicParameters();
            dyParam.Add(FactorSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)factor.ID ?? DBNull.Value);
            if (await NonQueryExecuter.ExecuteNonQueryAsync(FactorSpName.SP_DELETE_FACTOR, dyParam) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";
            return complate;
        }

        public async static Task<IDTO> DeleteFactors(long[] IDs)
        {

            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (await NonQueryExecuter.ExecuteNonQueryAsync(MultiDeleteFormater.Format(typeof(Factor), IDs)) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";

            return complate;
        }
    
}
}
