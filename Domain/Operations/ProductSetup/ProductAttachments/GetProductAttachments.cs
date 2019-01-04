using Common.Interfaces;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.ProductSetup.ProductAttachments
{
    public class GetProductAttachments : Domain.Entities.ProductSetup.ProductAttachment, IQueryable
    {
        public async Task<IEnumerable> QueryAsync()
        {
            var dyParam = new OracleDynamicParameters();
            dyParam.Add(ProductAttachmentSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ID ?? DBNull.Value);
            dyParam.Add(ProductAttachmentSpParams.PARAMETER_ST_PRD_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ProductId ?? DBNull.Value);
            dyParam.Add(ProductAttachmentSpParams.PARAMETER_ST_PRDT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ProductDetailId ?? DBNull.Value);
            dyParam.Add(ProductAttachmentSpParams.PARAMETER_ATT_LEVEL, OracleDbType.Int64, ParameterDirection.Input, (object)this.AttachmentLevel ?? DBNull.Value); 
            dyParam.Add(ProductAttachmentSpParams.PARAMETER_LANG_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.LangID ?? DBNull.Value);
            dyParam.Add(ProductAttachmentSpParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);

            return await QueryExecuter.ExecuteQueryAsync<Domain.Entities.ProductSetup.ProductAttachment>(ProductAttachmentSpName.SP_LOAD_PRODUCT_ATTACHMENT, dyParam);
        }
    }
}
