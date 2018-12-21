using Common.Interfaces;
using Common.Operations;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Operations.ProductSetup.ProductWordings
{
   public static class DbProductWordingSetup
    {
        public async static Task<IDTO> AddUpdateMode(Domain.Entities.ProductSetup.ProductWording wording)
        {
            string SPName = "";
            string message = "";
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (wording.ID.HasValue)
            {
                oracleParams.Add(ProductWordingSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)wording.ID ?? DBNull.Value);
                SPName = ProductWordingSpNames.SP_UPADTE_PRODUCT_WORDING;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(ProductWordingSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = ProductWordingSpNames.SP_INSERT_PRODUCT_WORDING;
                message = "Inserted Successfully";
            }

            oracleParams.Add(ProductWordingSpParams.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)wording.Name ?? DBNull.Value, 500);
            oracleParams.Add(ProductWordingSpParams.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)wording.Name2 ?? DBNull.Value, 500);
            oracleParams.Add(ProductWordingSpParams.PARAMETER_DESCRIPTION, OracleDbType.Varchar2, ParameterDirection.Input, (object)wording.Name ?? DBNull.Value, 4000);
            oracleParams.Add(ProductWordingSpParams.PARAMETER_DESCRIPTION2, OracleDbType.Varchar2, ParameterDirection.Input, (object)wording.Name2 ?? DBNull.Value, 4000);
            oracleParams.Add(ProductWordingSpParams.PARAMETER_LOC_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)wording.LockUpType ?? DBNull.Value);
            oracleParams.Add(ProductWordingSpParams.PARAMETER_STATUS, OracleDbType.Int64, ParameterDirection.Input, (object)wording.Status ?? DBNull.Value);
            oracleParams.Add(ProductWordingSpParams.PARAMETER_STATUS_DATE, OracleDbType.Date, ParameterDirection.Input, (object)wording.StatusDate ?? DBNull.Value);
            oracleParams.Add(ProductWordingSpParams.PARAMETER_ATT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)wording.AttachmentID ?? DBNull.Value);
            oracleParams.Add(ProductWordingSpParams.PARAMETER_ST_PRD_ID, OracleDbType.Int64, ParameterDirection.Input, (object)wording.ProductId ?? DBNull.Value);
            oracleParams.Add(ProductWordingSpParams.PARAMETER_ST_PRDT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)wording.ProductDetailId ?? DBNull.Value);
            oracleParams.Add(ProductWordingSpParams.PARAMETER_ST_LOB, OracleDbType.Int64, ParameterDirection.Input, (object)wording.LineOfBusiness ?? DBNull.Value);
            oracleParams.Add(ProductWordingSpParams.PARAMETER_ST_SUB_LOB, OracleDbType.Int64, ParameterDirection.Input, (object)wording.SubLineOfBusiness ?? DBNull.Value);

            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)
                complate.message = message;
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
