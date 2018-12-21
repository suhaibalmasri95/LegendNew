
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
    public static class DbProductReportSetup {

        public async static Task<IDTO> AddUpdateMode(Domain.Entities.ProductSetup.ProductReport report)
        {
            string SPName = "";
            string message = "";
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (report.ID.HasValue)
            {
                oracleParams.Add(ProductReportSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)report.ID ?? DBNull.Value);
                SPName = ProductReportSpName.SP_UPADTE_PRODUCT_REPORT;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(ProductReportSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = ProductReportSpName.SP_INSERT_PRODUCT_REPORT;
                message = "Inserted Successfully";
            }

            oracleParams.Add(ProductReportSpParams.PARAMETER_ST_REP_ID, OracleDbType.Int64, ParameterDirection.Input, (object)report.ReportId ?? DBNull.Value);
            oracleParams.Add(ProductReportSpParams.PARAMETER_STATUS, OracleDbType.Int64, ParameterDirection.Input, (object)report.Status ?? DBNull.Value);
            oracleParams.Add(ProductReportSpParams.PARAMETER_STATUS_DATE, OracleDbType.Date, ParameterDirection.Input, (object)report.StatusDate ?? DBNull.Value);
            oracleParams.Add(ProductReportSpParams.PARAMETER_REP_LEVEL, OracleDbType.Int64, ParameterDirection.Input, (object)report.ReportLevel ?? DBNull.Value);
            oracleParams.Add(ProductReportSpParams.PARAMETER_IS_REQUIRED, OracleDbType.Int64, ParameterDirection.Input, (object)report.IsRequired ?? DBNull.Value);
            oracleParams.Add(ProductReportSpParams.PARAMETER_ST_PRD_ID, OracleDbType.Int64, ParameterDirection.Input, (object)report.ProductId ?? DBNull.Value);
            oracleParams.Add(ProductReportSpParams.PARAMETER_ST_PRDT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)report.ProductDetailId ?? DBNull.Value);
            oracleParams.Add(ProductReportSpParams.PARAMETER_ST_LOB, OracleDbType.Int64, ParameterDirection.Input, (object)report.LineOfBusiness ?? DBNull.Value);
            oracleParams.Add(ProductReportSpParams.PARAMETER_ST_SUB_LOB, OracleDbType.Int64, ParameterDirection.Input, (object)report.SubLineOfBusiness ?? DBNull.Value);
            oracleParams.Add(ProductReportSpParams.PARAMETER_ST_REP_CODE, OracleDbType.Varchar2, ParameterDirection.Input, (object)report.ReportCode ?? DBNull.Value, 50);
            oracleParams.Add(ProductReportSpParams.PARAMETER_CREATED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)report.CreateBy ?? DBNull.Value, 50);
            oracleParams.Add(ProductReportSpParams.PARAMETER_CREATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)report.CreationDate ?? DBNull.Value);
            oracleParams.Add(ProductReportSpParams.PARAMETER_MODIFIED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)report.ModifiedBy ?? DBNull.Value, 50);
            oracleParams.Add(ProductReportSpParams.PARAMETER_MODIFICATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)report.ModificationDate ?? DBNull.Value);

            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)
                complate.message = message;
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}