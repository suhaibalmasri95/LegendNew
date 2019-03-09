using System;
using System.Data;
using System.Threading.Tasks;
using Common.Interfaces;
using Common.Operations;
using Domain.Entities.Production;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;

namespace Domain.Operations.Production.FactorDetails
{
    public static class DeleteMode
    {
        public async static Task<IDTO> DeleteFactorDetail(FactorDetail factor)
        {
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();
            var dyParam = new OracleDynamicParameters();
            dyParam.Add(FactorDetailSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)factor.ID ?? DBNull.Value);
            if (await NonQueryExecuter.ExecuteNonQueryAsync(FactorDetailSpName.SP_DELETE_FACTOR_DETAIL, dyParam) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";
            return complate;
        }

        public async static Task<IDTO> DeleteFactorDetails(long[] IDs)
        {

            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (await NonQueryExecuter.ExecuteNonQueryAsync(MultiDeleteFormater.Format(typeof(FactorDetail), IDs)) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";

            return complate;
        }

    }
}
