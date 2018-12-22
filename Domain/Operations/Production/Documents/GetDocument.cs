using Common.Interfaces;
using Domain.Entities.Production;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Production.Documents
{
   public class GetDocument : Document, IQueryable
    {
        public async Task<IEnumerable> QueryAsync()
    {
        var parameters = new OracleDynamicParameters();
        parameters.Add(DocumentSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ID ?? DBNull.Value);
       
            parameters.Add(DocumentSpParams.PARAMETER_LANG_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.LangID ?? DBNull.Value);
            parameters.Add(DocumentSpParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);
        return await QueryExecuter.ExecuteQueryAsync<Document>(DocumentSpName.SP_LOAD_DOCUMENT, parameters);
    }
}
}
