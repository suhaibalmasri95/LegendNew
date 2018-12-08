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

namespace Domain.Operations.Setup.Products
{
   public static class DBProductDeletionSetup
    {
        public async static Task<IDTO> DeleteProductAsync(Product product)
        {
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(ProductSPParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)product.ID ?? DBNull.Value);
            if (await NonQueryExecuter.ExecuteNonQueryAsync(ProductSPName.SP_DELETE_PRODUCT, dyParam) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";

            return complate;
        }

        public async static Task<IDTO> DeleteProductsAsync(long[] IDs)
        {
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (await NonQueryExecuter.ExecuteNonQueryAsync(MultiDeleteFormater.Format(typeof(Product), IDs)) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
