using Common.Interfaces;
using Common.Operations;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.ProductSetup.ProductReports
{
    public static class DbDeleteProductReport
    {
        public async static Task<IDTO> DeleteProducReportAsync(Domain.Entities.ProductSetup.ProductReport report)
        {
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();
            var dyParam = new OracleDynamicParameters();
            dyParam.Add(ProductReportSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)report.ID ?? DBNull.Value);
            if (await NonQueryExecuter.ExecuteNonQueryAsync(ProductReportSpName.SP_DELETE_PRODUCT_REPORT, dyParam) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";
            return complate;
        }

        public async static Task<IDTO> DeleteProductReportsAsync(long[] IDs)
        {

            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (await NonQueryExecuter.ExecuteNonQueryAsync(MultiDeleteFormater.Format(typeof(Domain.Entities.ProductSetup.ProductReport), IDs)) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
