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

namespace Domain.Operations.Production.Shares
{
   public static class DBSharesSetup
    {
        public async static Task<IDTO> AddUpdateMode(Share share)
        {
            string SPName = "";
            string message = "";
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (share.ID.HasValue)
            {
                oracleParams.Add(SharesSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)share.ID ?? DBNull.Value);

                SPName = SharesSpName.SP_UPADTE_SHARE;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(SharesSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = SharesSpName.SP_INSERT_SHARE;
                message = "Inserted Successfully";
            }

            oracleParams.Add(SharesSpParams.PARAMETER_LOC_SHARE_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)share.ShareType ?? DBNull.Value);
            oracleParams.Add(SharesSpParams.PARAMETER_PRCNT, OracleDbType.Decimal, ParameterDirection.Input, (object)share.Percent ?? DBNull.Value);
            oracleParams.Add(SharesSpParams.PARAMETER_SHARE_PER, OracleDbType.Decimal, ParameterDirection.Input, (object)share.SharePercent ?? DBNull.Value);
            oracleParams.Add(SharesSpParams.PARAMETER_AMOUNT, OracleDbType.Decimal, ParameterDirection.Input, (object)share.Amount ?? DBNull.Value);
            oracleParams.Add(SharesSpParams.PARAMETER_AMOUNT_LC, OracleDbType.Decimal, ParameterDirection.Input, (object)share.AmountLC ?? DBNull.Value);
            oracleParams.Add(SharesSpParams.PARAMETER_NOTES, OracleDbType.Varchar2, ParameterDirection.Input, (object)share.Notes ?? DBNull.Value);
            oracleParams.Add(SharesSpParams.PARAMETER_CREATED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)share.CreatedBy ?? DBNull.Value);
            oracleParams.Add(SharesSpParams.PARAMETER_CREATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)share.CreationDate ?? DBNull.Value);
            oracleParams.Add(SharesSpParams.PARAMETER_MODIFIED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)share.ModifiedBy ?? DBNull.Value);
            oracleParams.Add(SharesSpParams.PARAMETER_MODIFICATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)share.ModificationDate ?? DBNull.Value);
            oracleParams.Add(SharesSpParams.PARAMETER_UW_DOC_ID, OracleDbType.Int64, ParameterDirection.Input, (object)share.DocumentID ?? DBNull.Value);
            oracleParams.Add(SharesSpParams.PARAMETER_FIN_CST_ID, OracleDbType.Int64, ParameterDirection.Input, (object)share.CustomerId ?? DBNull.Value);
            oracleParams.Add(SharesSpParams.PARAMETER_ST_LOB, OracleDbType.Int64, ParameterDirection.Input, (object)share.StLOB ?? DBNull.Value);
            oracleParams.Add(SharesSpParams.PARAMETER_ST_SUB_LOB, OracleDbType.Int64, ParameterDirection.Input, (object)share.StSubLOB ?? DBNull.Value);
            oracleParams.Add(SharesSpParams.PARAMETER_DR_CR, OracleDbType.Int64, ParameterDirection.Input, (object)share.DrCr ?? DBNull.Value);


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
