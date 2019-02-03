using Common.Interfaces;
using Common.Operations;
using Domain.Entities.Production;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Production.Attachments
{
    public static class AutoAddAttachment
    {

        public async static Task<IDTO> AutoAdd(Attachment attachment)
        {

       OracleDynamicParameters oracleParams = new OracleDynamicParameters();
        ComplateOperation<int> complate = new ComplateOperation<int>();
         

          
            oracleParams.Add(AttachmentsSpParams.PARAMETER_UW_DOC_ID, OracleDbType.Int64, ParameterDirection.Input, (object)attachment.DocumentID ?? DBNull.Value);
            oracleParams.Add(AttachmentsSpParams.PARAMETER_UW_RISK_ID, OracleDbType.Int64, ParameterDirection.Input, (object) attachment.RiskID ?? DBNull.Value);
            oracleParams.Add(AttachmentsSpParams.PARAMETER_CLM_ID, OracleDbType.Int64, ParameterDirection.Input, (object) attachment.ClaimID ?? DBNull.Value);
            oracleParams.Add(AttachmentsSpParams.PARAMETER_LOC_LEVEL, OracleDbType.Int64, ParameterDirection.Input, (object) attachment.Level ?? DBNull.Value);
            oracleParams.Add(AttachmentsSpParams.PARAMETER_CREATED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object) attachment.CreatedBy ?? DBNull.Value);
            oracleParams.Add(AttachmentsSpParams.PARAMETER_CREATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object) attachment.CreationDate ?? DBNull.Value);
     

            if (await NonQueryExecuter.ExecuteNonQueryAsync(AttachmentsSpName.SP_AUTO_INSERT_ATTACHMENT, oracleParams) == -1)
        complate.message = "Operation Success";
             else 
          complate.message = "Operation Failed";
    return  complate;
    }
}
}
