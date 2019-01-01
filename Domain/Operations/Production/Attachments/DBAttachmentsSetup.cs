using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using Common.Operations;
using Domain.Entities.Production;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;

namespace Domain.Operations.Production.Attachments
{
    class DBAttachmentsSetup
    {
        public async static Task<IDTO> AddUpdateMode(Attachment attachment)
        {
            string SPName = "";
            string message = "";
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (attachment.ID.HasValue)
            {
                oracleParams.Add(AttachmentsSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)attachment.ID ?? DBNull.Value);

                SPName = AttachmentsSpName.SP_UPADTE_ATTACHMENT;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(AttachmentsSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = AttachmentsSpName.SP_INSERT_ATTACHMENT;
                message = "Inserted Successfully";
            }

            oracleParams.Add(AttachmentsSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)attachment.ID ?? DBNull.Value);
            oracleParams.Add(AttachmentsSpParams.PARAMETER_SERIAL, OracleDbType.Int64, ParameterDirection.Input, (object)attachment.Serial ?? DBNull.Value);
            oracleParams.Add(AttachmentsSpParams.PARAMETER_ATTACHED_PATH, OracleDbType.Varchar2, ParameterDirection.Input, (object)attachment.AttachedPath ?? DBNull.Value);
            oracleParams.Add(AttachmentsSpParams.PARAMETER_CREATED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)attachment.CreatedBy ?? DBNull.Value);
            oracleParams.Add(AttachmentsSpParams.PARAMETER_CREATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)attachment.CreationDate ?? DBNull.Value);
            oracleParams.Add(AttachmentsSpParams.PARAMETER_MODIFIED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)attachment.ModifiedBy ?? DBNull.Value);
            oracleParams.Add(AttachmentsSpParams.PARAMETER_MODIFICATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)attachment.ModificationDate ?? DBNull.Value);
            oracleParams.Add(AttachmentsSpParams.PARAMETER_UW_DOC_ID, OracleDbType.Int64, ParameterDirection.Input, (object)attachment.DocumentID ?? DBNull.Value);
            oracleParams.Add(AttachmentsSpParams.PARAMETER_UW_RISK_ID, OracleDbType.Int64, ParameterDirection.Input, (object)attachment.RiskID ?? DBNull.Value);
            oracleParams.Add(AttachmentsSpParams.PARAMETER_IS_RECEIVED, OracleDbType.Int64, ParameterDirection.Input, (object)attachment.IsReceived ?? DBNull.Value);
            oracleParams.Add(AttachmentsSpParams.PARAMETER_RECEIVED_DATE, OracleDbType.Date, ParameterDirection.Input, (object)attachment.ReceivedDate ?? DBNull.Value);
            oracleParams.Add(AttachmentsSpParams.PARAMETER_REMARKS, OracleDbType.Varchar2, ParameterDirection.Input, (object)attachment.Remarks ?? DBNull.Value);
            oracleParams.Add(AttachmentsSpParams.PARAMETER_ST_PRD_ATT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)attachment.ProductAttachmentID ?? DBNull.Value);
            oracleParams.Add(AttachmentsSpParams.PARAMETER_CLM_ID, OracleDbType.Int64, ParameterDirection.Input, (object)attachment.ClaimID ?? DBNull.Value);
            oracleParams.Add(AttachmentsSpParams.PARAMETER_LOC_LEVEL, OracleDbType.Int64, ParameterDirection.Input, (object)attachment.Level ?? DBNull.Value);


            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)
            {
                complate.message = message;
                complate.ID = oracleParams.Get(0);
            }
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
