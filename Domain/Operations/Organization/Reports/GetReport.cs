using Common.Interfaces;
using Domain.Entities.Organization;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Organization.Reports
{
    public class GetReport : Report, IQueryable
    {
        public async Task<IEnumerable> QueryAsync()
        {
            var @params = new OracleDynamicParameters();

            @params.Add(ReportSpParams.PARAMETER_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)ID ?? DBNull.Value);
            @params.Add(ReportSpParams.PARAMETER_LANG, OracleDbType.Decimal, ParameterDirection.Input, (object)LangID ?? DBNull.Value);
            @params.Add(ReportSpParams.PARAMETER_GROUPID, OracleDbType.Decimal, ParameterDirection.Input, (object)ReportGroupID ?? DBNull.Value);
            @params.Add(ReportSpParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);
            return await QueryExecuter.ExecuteQueryAsync<Report>(ReportSPName.SP_LOAD_Report, @params);
        }
    }
}