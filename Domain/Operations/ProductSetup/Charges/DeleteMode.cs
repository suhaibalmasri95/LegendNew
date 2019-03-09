using System;
using System.Data;
using System.Threading.Tasks;
using Common.Interfaces;
using Common.Operations;
using Domain.Entities.ProductSetup;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;

namespace Domain.Operations.ProductSetup.Charges
{
    public static class DeleteMode
    {
        public async static Task<IDTO> DeleteProductCharge(ProductCharges pricing)
        {
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();
            var dyParam = new OracleDynamicParameters();
            dyParam.Add(ChargeSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)pricing.ID ?? DBNull.Value);
            if (await NonQueryExecuter.ExecuteNonQueryAsync(ChargeSpName.SP_DELETE_CHARGE, dyParam) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";
            return complate;
        }

        public async static Task<IDTO> DeleteProductCharges(long[] IDs)
        {

            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (await NonQueryExecuter.ExecuteNonQueryAsync(MultiDeleteFormater.Format(typeof(ProductCharges), IDs)) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
