using Common.Interfaces;
using Common.Operations;
using Domain.Entities.ProductSetup;
using Domain.Entities.Setup;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.ProductSetup.ProductsSubjectstypies
{
   public static  class DBDeletionSetup
    {
        public async static Task<IDTO> DeleteProductSubjectTypeAsync(ProductSubjectType product)
        {
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(ProductSubjectsTypiesSPParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)product.ID ?? DBNull.Value);
            if (await NonQueryExecuter.ExecuteNonQueryAsync(ProductSubjectsTypiesSPName.SP_DELETE_PRODUCT_SUBJECT_TYPE, dyParam) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";

            return complate;
        }

        public async static Task<IDTO> DeleteMultipleProductSubjectTypeAsync(long[] IDs)
        {
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (await NonQueryExecuter.ExecuteNonQueryAsync(MultiDeleteFormater.Format(typeof(ProductSubjectType), IDs)) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
