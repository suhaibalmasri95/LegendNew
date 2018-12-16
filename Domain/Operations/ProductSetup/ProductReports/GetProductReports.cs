using Common.Interfaces;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Operations.ProductSetup.ProductReports
{
  public class GetProductReports : Domain.Entities.ProductSetup.ProductReport, IQueryable
    {
        public async Task<IEnumerable> QueryAsync()
        {
            var dyParam = new OracleDynamicParameters();
            dyParam.Add(ProductReportSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ID ?? DBNull.Value);
            dyParam.Add(ProductReportSpParams.PARAMETER_ST_PRD_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ProductId ?? DBNull.Value);
            dyParam.Add(ProductReportSpParams.PARAMETER_ST_PRDT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ProductDetailId ?? DBNull.Value);
            dyParam.Add(ProductReportSpParams.PARAMETER_LANG_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.LangID ?? DBNull.Value);
            dyParam.Add(ProductReportSpParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);

            return await QueryExecuter.ExecuteQueryAsync<Domain.Entities.ProductSetup.ProductReport>(ProductReportSpName.SP_LOAD_PRODUCT_REPORT, dyParam);
        }
    }
}
