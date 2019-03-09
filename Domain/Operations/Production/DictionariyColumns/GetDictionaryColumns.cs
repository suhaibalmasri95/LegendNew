using System;
using System.Collections;
using System.Data;
using System.Threading.Tasks;
using Common.Interfaces;
using Domain.Entities.Production;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;

namespace Domain.Operations.Production.DictionariyColumns
{
    public class GetDictionaryColumns : DictionaryColumn, IQueryable
    {
        public async Task<IEnumerable> QueryAsync()
        {
            var parameters = new OracleDynamicParameters();
            parameters.Add(DictionariyColumnSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ID ?? DBNull.Value);
            parameters.Add(DictionariyColumnSpParams.PARAMETER_DICTIONARY_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.DictionaryID ?? DBNull.Value);
            parameters.Add(DictionariyColumnSpParams.PARAMETER_LANG_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.LangID ?? DBNull.Value);
            parameters.Add(DictionariyColumnSpParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);

            return await QueryExecuter.ExecuteQueryAsync<DictionaryColumn>(DictionariyColumnSpNames.SP_LOAD_DICTIONARY_COL, parameters);
        }

    }
}
