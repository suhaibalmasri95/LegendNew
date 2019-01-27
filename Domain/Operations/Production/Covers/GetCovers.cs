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

namespace Domain.Operations.Production.Covers
{
    public class GetCovers : Cover, IQueryable
    {
        public async Task<IEnumerable> QueryAsync()
        {
            var parameters = new OracleDynamicParameters();
            parameters.Add(CoverSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ID ?? DBNull.Value);
            parameters.Add(CoverSpParams.PARAMETER_LOC_CHARG_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)this.ChargeType ?? DBNull.Value);
            parameters.Add(CoverSpParams.PARAMETER_UW_DOC_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.UwDocumentID ?? DBNull.Value);
            parameters.Add(CoverSpParams.PARAMETER_UW_RISK_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.UwRiskID ?? DBNull.Value);

            parameters.Add(CoverSpParams.PARAMETER_LANG_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.LangID ?? DBNull.Value);
            parameters.Add(CoverSpParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);

            return await QueryExecuter.ExecuteQueryAsync<Cover>(CoverSpName.SP_LOAD_COVER, parameters);
        }
    }
}
