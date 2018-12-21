using Common.Interfaces;
using Common.Operations;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.ProductSetup.ProductWordingDetails
{
   public static class DbProdWordDetailSetup
    {
        public async static Task<IDTO> AddUpdateMode(Domain.Entities.ProductSetup.ProductWordingDetails wording)
        {
            string SPName = "";
            string message = "";
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (wording.ID.HasValue)
            {
                oracleParams.Add(ProductWordDetailSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)wording.ID ?? DBNull.Value);
                SPName = ProductWordDetailSpName.SP_UPADTE_PRODUCT_WORDING_DETAIL;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(ProductWordDetailSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = ProductWordDetailSpName.SP_INSERT_PRODUCT_WORDING_DETAIL;
                message = "Inserted Successfully";
            }

            oracleParams.Add(ProductWordDetailSpParams.PARAMETER_SERIAL, OracleDbType.Int64, ParameterDirection.Input, (object)wording.Serial ?? DBNull.Value, 500);
            oracleParams.Add(ProductWordDetailSpParams.PARAMETER_DESCRIPTION, OracleDbType.Varchar2, ParameterDirection.Input, (object)wording.Name ?? DBNull.Value, 4000);
            oracleParams.Add(ProductWordDetailSpParams.PARAMETER_DESCRIPTION2, OracleDbType.Varchar2, ParameterDirection.Input, (object)wording.Name2 ?? DBNull.Value, 4000);
            oracleParams.Add(ProductWordDetailSpParams.PARAMETER_WORD_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)wording.WordType ?? DBNull.Value);
            oracleParams.Add(ProductWordDetailSpParams.PARAMETER_STATUS, OracleDbType.Int64, ParameterDirection.Input, (object)wording.Status ?? DBNull.Value);
            oracleParams.Add(ProductWordDetailSpParams.PARAMETER_STATUS_DATE, OracleDbType.Date, ParameterDirection.Input, (object)wording.StatusDate ?? DBNull.Value);
            oracleParams.Add(ProductWordDetailSpParams.PARAMETER_ST_WORD_ID, OracleDbType.Int64, ParameterDirection.Input, (object)wording.WordId ?? DBNull.Value);
            oracleParams.Add(ProductWordDetailSpParams.PARAMETER_IS_AUTO_ADD, OracleDbType.Int64, ParameterDirection.Input, (object)wording.IsAutoAdd ?? DBNull.Value);
            oracleParams.Add(ProductWordDetailSpParams.PARAMETER_ST_PRD_ID, OracleDbType.Int64, ParameterDirection.Input, (object)wording.ProductId ?? DBNull.Value);
            oracleParams.Add(ProductWordDetailSpParams.PARAMETER_ST_PRDT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)wording.ProductDetailId ?? DBNull.Value);
            oracleParams.Add(ProductWordDetailSpParams.PARAMETER_ST_LOB, OracleDbType.Int64, ParameterDirection.Input, (object)wording.LineOfBusiness ?? DBNull.Value);
            oracleParams.Add(ProductWordDetailSpParams.PARAMETER_ST_SUB_LOB, OracleDbType.Int64, ParameterDirection.Input, (object)wording.SubLineOfBusiness ?? DBNull.Value);
            oracleParams.Add(ProductWordDetailSpParams.PARAMETER_ST_SRVCS_ID, OracleDbType.Int64, ParameterDirection.Input, (object)wording.ServiceID ?? DBNull.Value);
            oracleParams.Add(ProductWordDetailSpParams.PARAMETER_CREATED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)wording.CreateBy ?? DBNull.Value, 50);
            oracleParams.Add(ProductWordDetailSpParams.PARAMETER_CREATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)wording.CreationDate ?? DBNull.Value);
            oracleParams.Add(ProductWordDetailSpParams.PARAMETER_MODIFIED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)wording.ModifiedBy ?? DBNull.Value, 50);
            oracleParams.Add(ProductWordDetailSpParams.PARAMETER_MODIFICATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)wording.ModificationDate ?? DBNull.Value);

            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)
                complate.message = message;
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
