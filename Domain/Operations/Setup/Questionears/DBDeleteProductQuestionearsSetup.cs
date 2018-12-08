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

namespace Domain.Operations.Setup.Questionears
{
   public static class DBDeleteProductQuestionearsSetup
    {
        public async static Task<IDTO> DeleteProductSubjectTypeAsync(ProductQuestion product)
        {
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(ProductQuestionearsSPParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)product.ID ?? DBNull.Value);
            if (await NonQueryExecuter.ExecuteNonQueryAsync(ProductQuestionearsSPName.SP_DELETE_PRODUCT_Question, dyParam) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";

            return complate;
        }

        public async static Task<IDTO> DeleteMultipleProductSubjectTypeAsync(long[] IDs)
        {
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (await NonQueryExecuter.ExecuteNonQueryAsync(MultiDeleteFormater.Format(typeof(ProductQuestion), IDs)) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
