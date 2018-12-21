using Common.Interfaces;
using Common.Operations;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Operations.ProductSetup.ProductWordingDetails
{
    public static class DbDeleteProdWordDetailSetup
    {
        public async static Task<IDTO> DeleteProductWordingDetailAsync(Domain.Entities.ProductSetup.ProductWordingDetails wordingDetails)
        {
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();
            var dyParam = new OracleDynamicParameters();
            dyParam.Add(ProductWordDetailSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)wordingDetails.ID ?? DBNull.Value);
            if (await NonQueryExecuter.ExecuteNonQueryAsync(ProductWordDetailSpName.SP_DELETE_PRODUCT_WORDING_DETAIL, dyParam) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";
            return complate;
        }

        public async static Task<IDTO> DeleteProductWordingDetailsAsync(long[] IDs)
        {

            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (await NonQueryExecuter.ExecuteNonQueryAsync(MultiDeleteFormater.Format(typeof(Domain.Entities.ProductSetup.ProductWordingDetails), IDs)) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
