using Common.Interfaces;
using Common.Operations;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.ProductSetup.Attachments
{
   public static class DbAttachmentSetup
    {
        public async static Task<IDTO> AddUpdateMode(Domain.Entities.ProductSetup.Attachment attachment)
        {
            string SPName = "";
            string message = "";
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (attachment.ID.HasValue)
            {
                oracleParams.Add(AttachmentParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)attachment.ID ?? DBNull.Value);
                SPName = AttachmentSpName.SP_UPADTE_ATTACHMENT;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(AttachmentParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = AttachmentSpName.SP_INSERT_ATTACHMENT;
                message = "Inserted Successfully";
            }

            oracleParams.Add(AttachmentParams.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)attachment.Name ?? DBNull.Value, 500);
            oracleParams.Add(AttachmentParams.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)attachment.Name2 ?? DBNull.Value, 500);
            oracleParams.Add(AttachmentParams.PARAMETER_CREATED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)attachment.CreateBy ?? DBNull.Value,50);
            oracleParams.Add(AttachmentParams.PARAMETER_CREATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)attachment.CreationDate ?? DBNull.Value);
            oracleParams.Add(AttachmentParams.PARAMETER_MODIFIED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)attachment.ModifiedBy ?? DBNull.Value, 50);
            oracleParams.Add(AttachmentParams.PARAMETER_MODIFICATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)attachment.ModificationDate ?? DBNull.Value);
         

            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)
                complate.message = message;
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
