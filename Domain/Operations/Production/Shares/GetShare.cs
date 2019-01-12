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

namespace Domain.Operations.Production.Shares
{
    public class GetShare : Share, IQueryable
    {
        public async Task<IEnumerable> QueryAsync()
        {
            var parameters = new OracleDynamicParameters();
            parameters.Add(SharesSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ID ?? DBNull.Value);
            parameters.Add(SharesSpParams.PARAMETER_LOC_SHARE_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)this.ShareType ?? DBNull.Value);
            parameters.Add(SharesSpParams.PARAMETER_UW_DOC_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.DocumentID ?? DBNull.Value);
            parameters.Add(SharesSpParams.PARAMETER_FIN_CST_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.CustomerId ?? DBNull.Value);
            parameters.Add(SharesSpParams.PARAMETER_ST_LOB, OracleDbType.Int64, ParameterDirection.Input, (object)this.StLOB ?? DBNull.Value);
            parameters.Add(SharesSpParams.PARAMETER_ST_SUB_LOB, OracleDbType.Int64, ParameterDirection.Input, (object)this.StSubLOB ?? DBNull.Value);
            parameters.Add(SharesSpParams.PARAMETER_LANG_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.LangID ?? DBNull.Value);
            parameters.Add(SharesSpParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);

            return await QueryExecuter.ExecuteQueryAsync<Share>(SharesSpName.SP_LOAD_SHARE, parameters);
        }
    }
}
