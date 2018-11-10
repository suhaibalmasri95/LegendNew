using Common.Interfaces;
using Domain.Entities.Organization;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Data;

using System.Threading.Tasks;

namespace Domain.Operations.Organization.CompanyBranches
{
    public class GetCompanyBranches : CompanyBranch, IQueryable
    {
        public async Task<IEnumerable> QueryAsync()
        {
            var dyParam = new OracleDynamicParameters();
            
            dyParam.Add(CompanyBranchSpParams.PARAMETER_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)ID ?? DBNull.Value);
            dyParam.Add(CompanyBranchSpParams.PARAMETER_COMPANY_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)CompanyID ?? DBNull.Value);
            dyParam.Add(CompanyBranchSpParams.PARAMETER_LANG_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)LangID ?? DBNull.Value);
            dyParam.Add(CompanyBranchSpParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);

            return await QueryExecuter.ExecuteQueryAsync<CompanyBranch>(CompanyBranchSPName.SP_LOAD_COMPANY_BRANCH, dyParam);
        }
    }
}
