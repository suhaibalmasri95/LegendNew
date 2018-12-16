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
    public static class DbProdAttachmentSetup
    {
        public async static Task<IDTO> AddUpdateMode(Domain.Entities.ProductSetup.ProductAttachment productAttachment)
        {
            string SPName = "";
            string message = "";
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (productAttachment.ID.HasValue)
            {
                oracleParams.Add(ProductAttachmentSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)productAttachment.ID ?? DBNull.Value);
                SPName = ProductAttachmentSpName.SP_UPADTE_PRODUCT_ATTACHMENT;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(ProductAttachmentSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = ProductAttachmentSpName.SP_INSERT_PRODUCT_ATTACHMENT;
                message = "Inserted Successfully";
            }

            oracleParams.Add(ProductAttachmentSpParams.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)productAttachment.Name ?? DBNull.Value, 500);
            oracleParams.Add(ProductAttachmentSpParams.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)productAttachment.Name2 ?? DBNull.Value, 500);
            oracleParams.Add(ProductAttachmentSpParams.PARAMETER_STATUS, OracleDbType.Int64, ParameterDirection.Input, (object)productAttachment.Status ?? DBNull.Value);
            oracleParams.Add(ProductAttachmentSpParams.PARAMETER_STATUS_DATE, OracleDbType.Date, ParameterDirection.Input, (object)productAttachment.StatusDate ?? DBNull.Value);
            oracleParams.Add(ProductAttachmentSpParams.PARAMETER_ATT_LEVEL, OracleDbType.Int64, ParameterDirection.Input, (object)productAttachment.AttachmentLevel ?? DBNull.Value, 50);
            oracleParams.Add(ProductAttachmentSpParams.PARAMETER_IS_REQUIRED, OracleDbType.Int64, ParameterDirection.Input, (object)productAttachment.IsRequired ?? DBNull.Value);
            oracleParams.Add(ProductAttachmentSpParams.PARAMETER_ATT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)productAttachment.AttachmentID ?? DBNull.Value);
            oracleParams.Add(ProductAttachmentSpParams.PARAMETER_ST_PRD_ID, OracleDbType.Int64, ParameterDirection.Input, (object)productAttachment.ProductId ?? DBNull.Value);
            oracleParams.Add(ProductAttachmentSpParams.PARAMETER_ST_PRDT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)productAttachment.ProductDetailId ?? DBNull.Value);
            oracleParams.Add(ProductAttachmentSpParams.PARAMETER_ST_LOB, OracleDbType.Int64, ParameterDirection.Input, (object)productAttachment.LineOfBusiness ?? DBNull.Value);
            oracleParams.Add(ProductAttachmentSpParams.PARAMETER_ST_SUB_LOB, OracleDbType.Int64, ParameterDirection.Input, (object)productAttachment.SubLineOfBusiness ?? DBNull.Value);

            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)
                complate.message = message;
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
