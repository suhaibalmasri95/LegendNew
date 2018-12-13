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

namespace Domain.Operations.Setup.Categories
{
    public static class DBCategoryDeletionSetup
    {
        public async static Task<IDTO> DeleteAnswerAsync(Category category)
        {
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();
            var dyParam = new OracleDynamicParameters();
            dyParam.Add(CategorySpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)category.ID ?? DBNull.Value);
            if (await NonQueryExecuter.ExecuteNonQueryAsync(CategorySpName.SP_DELETE_CATEGORY, dyParam) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";

            return complate;
        }

        public async static Task<IDTO> DeleteAnswersAsync(long[] IDs)
        {

            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (await NonQueryExecuter.ExecuteNonQueryAsync(MultiDeleteFormater.Format(typeof(Category), IDs)) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
