using Common.Interfaces;
using Common.Operations;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.ProductSetup.ProductAttachments
{
   public class DbDeleteProdAttachment
    {
        public async static Task<IDTO> DeleteProductAttachmentAsync(Domain.Entities.ProductSetup.ProductAttachment attachment)
        {
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();
            var dyParam = new OracleDynamicParameters();
            dyParam.Add(ProductAttachmentSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)attachment.ID ?? DBNull.Value);
            if (await NonQueryExecuter.ExecuteNonQueryAsync(ProductAttachmentSpName.SP_DELETE_PRODUCT_ATTACHMENT, dyParam) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";
            return complate;
        }

        public async static Task<IDTO> DeleteProductAttachmentsAsync(long[] IDs)
        {

            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (await NonQueryExecuter.ExecuteNonQueryAsync(MultiDeleteFormater.Format(typeof(Domain.Entities.ProductSetup.ProductAttachment), IDs)) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}

