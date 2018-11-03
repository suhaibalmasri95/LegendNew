using Common.Interfaces;
using Domain.Organization.Entities;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Data;

using System.Threading.Tasks;

namespace Domain.Operations.Organization.BankBranches
{
    public class GetBankBranches : BankBranch, IQueryable
    {
        public async Task<IEnumerable> Query()
        {
            var dyParam = new OracleDynamicParameters();
            
            dyParam.Add(BankBranchSpParams.PARAMETER_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)ID ?? DBNull.Value);
            dyParam.Add(BankBranchSpParams.PARAMETER_BANK_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)BankID ?? DBNull.Value);
            dyParam.Add(BankBranchSpParams.PARAMETER_LANG_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)LangID ?? DBNull.Value);
            dyParam.Add(BankBranchSpParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);

            return await QueryExecuter.ExecuteQueryAsync<BankBranch>(BankBranchSPName.SP_LOAD_BANCK_BRANCH, dyParam);
        }
    }
}
