using Common.Interfaces;
using Common.Operations;
using Domain.Entities.Organization;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Organization.ReportGroups
{
    public class DBDeleteReportGroupSetup
    {
        public async static Task<IDTO> DeleteReportGroupAsync(ReportGroup reportGroup)
        {
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();
            var dyParam = new OracleDynamicParameters();
            dyParam.Add(ReportGroupSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)reportGroup.ID ?? DBNull.Value);
            if (await NonQueryExecuter.ExecuteNonQueryAsync(ReportGroupSPName.SP_DELETE_ReportGroup, dyParam) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";
            return complate;
        }

        public async static Task<IDTO> DeleteAReportGroupssAsync(long[] IDs)
        {

            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (await NonQueryExecuter.ExecuteNonQueryAsync(MultiDeleteFormater.Format(typeof(ReportGroup), IDs)) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
