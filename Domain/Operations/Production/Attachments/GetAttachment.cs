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

namespace Domain.Operations.Production.Attachments
{
    public class GetAttachment : Attachment, IQueryable
    {
        public async Task<IEnumerable> QueryAsync()
        {          
            var parameters = new OracleDynamicParameters();
            parameters.Add(AttachmentsSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ID ?? DBNull.Value);
            parameters.Add(AttachmentsSpParams.PARAMETER_UW_DOC_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.DocumentID ?? DBNull.Value);
            parameters.Add(AttachmentsSpParams.PARAMETER_UW_RISK_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.RiskID ?? DBNull.Value);
            parameters.Add(AttachmentsSpParams.PARAMETER_ST_PRD_ATT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ProductAttachmentID ?? DBNull.Value);
            parameters.Add(AttachmentsSpParams.PARAMETER_CLM_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ClaimID ?? DBNull.Value);
            parameters.Add(AttachmentsSpParams.PARAMETER_LOC_LEVEL, OracleDbType.Int64, ParameterDirection.Input, (object)this.Level ?? DBNull.Value);
            parameters.Add(AttachmentsSpParams.PARAMETER_LANG_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.LangID ?? DBNull.Value);
            parameters.Add(AttachmentsSpParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);

            return await QueryExecuter.ExecuteQueryAsync<Risk>(AttachmentsSpName.SP_LOAD_ATTACHMENT, parameters);
        }
    }
}
