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

namespace Domain.Operations.Organization.ReportGroups
{
    public class GetReportGroups : ReportGroup, IQueryable
    {
        public async Task<IEnumerable> Query()
        {
            var @params = new OracleDynamicParameters();

            @params.Add(ReportGroupSpParams.PARAMETER_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)ID ?? DBNull.Value);
            @params.Add(ReportGroupSpParams.PARAMETER_LANG, OracleDbType.Decimal, ParameterDirection.Input, (object)LangID ?? DBNull.Value);
            @params.Add(ReportGroupSpParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);

            return await QueryExecuter.ExecuteQueryAsync<ReportGroup>(ReportGroupSPName.SP_LOAD_ReportGroup, @params);
        }
    }
}