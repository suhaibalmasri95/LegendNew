using Common.Interfaces;
using Domain.Organization.Entities;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Data;

using System.Threading.Tasks;

namespace Domain.Operations.Organization.Banks
{
    public class GetBanks : Bank, IQueryable
    {
        public async Task<IEnumerable> Query()
        {
            var dyParam = new OracleDynamicParameters();
            
            dyParam.Add(BankSpParams.PARAMETER_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)ID ?? DBNull.Value);
            
            dyParam.Add(BankSpParams.PARAMETER_LANG_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)LangID ?? DBNull.Value);
            dyParam.Add(BankSpParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);

            return await QueryExecuter.ExecuteQueryAsync<Bank>(BankSPName.SP_LOAD_BANCK, dyParam);
        }
    }
}
