using Common.Interfaces;
using Common.Operations;
using Domain.Entities.Organization;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Organization.Reports
{
    public class CreateUpdateReportDBSetup
    {
        public async static Task<IDTO> AddUpdateMode(Report report)
        {
            string SPName = "";
            string message = "";
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (report.ID.HasValue)
            {
                oracleParams.Add(ReportSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)report.ID ?? DBNull.Value);
                SPName = ReportSPName.SP_LOAD_Report;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(ReportSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = ReportSPName.SP_INSERT_Report;
                message = "Inserted Successfully";
            }

            oracleParams.Add(ReportSpParams.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)report.Name ?? DBNull.Value, 500);
            oracleParams.Add(ReportSpParams.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)report.Name2 ?? DBNull.Value, 500);
            oracleParams.Add(ReportSpParams.PARAMETER_ORDER_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)report.Order ?? DBNull.Value, 50);
            oracleParams.Add(ReportSpParams.PARAMETER_CODE, OracleDbType.Varchar2, ParameterDirection.Input, (object)report.Code ?? DBNull.Value, 50);
            oracleParams.Add(ReportSpParams.PARAMETER_GROUPID, OracleDbType.Varchar2, ParameterDirection.Input, (object)report.ReportGroupID ?? DBNull.Value, 50);

            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)
                complate.message = message;
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
