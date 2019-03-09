using System;
using System.Data;
using System.Threading.Tasks;
using Common.Interfaces;
using Common.Operations;
using Domain.Entities.Production;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;

namespace Domain.Operations.Production.PricingDetails
{
    public static class DeleteMode
    {
        public async static Task<IDTO> DeletePricingDetail(PricingDetail pricingDetail)
        {
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();
            var dyParam = new OracleDynamicParameters();
            dyParam.Add(PricingDetailsSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)pricingDetail.ID ?? DBNull.Value);
            if (await NonQueryExecuter.ExecuteNonQueryAsync(PricingDetailsSpName.SP_DELETE_PRICING_DETAIL, dyParam) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";
            return complate;
        }

        public async static Task<IDTO> DeletePricingDetails(long[] IDs)
        {

            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (await NonQueryExecuter.ExecuteNonQueryAsync(MultiDeleteFormater.Format(typeof(PricingDetail), IDs)) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";

            return complate;
        }
    
}
}
