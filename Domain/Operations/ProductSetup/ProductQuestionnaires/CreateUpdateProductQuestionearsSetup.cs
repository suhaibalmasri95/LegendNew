using Common.Interfaces;
using Common.Operations;
using Domain.Entities.ProductSetup;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.ProductSetup.ProductQuestionnaires
{
   public static class CreateUpdateProductQuestionearsSetup
    {
        public async static Task<IDTO> AddUpdate(ProductQuestionnaire Product)
        {
            var SPName = default(string);
            var message = default(string);
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (Product.ID.HasValue)
            {
                oracleParams.Add(ProductQuestionearsSPParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)Product.ID ?? DBNull.Value);
                SPName = ProductQuestionearsSPName.SP_UPADTE_PRODUCT_Question;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(ProductQuestionearsSPParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = ProductQuestionearsSPName.SP_INSERT_PRODUCT_Question;
                message = "Inserted Successfully";
            }
            oracleParams.Add(ProductQuestionearsSPParams.PARAMETER_STATUS, OracleDbType.Int64, ParameterDirection.Input, (object)Product.Status ?? DBNull.Value);
            oracleParams.Add(ProductQuestionearsSPParams.PARAMETER_STATUS_DATE, OracleDbType.Date, ParameterDirection.Input, (object)Product.StatusDate ?? DBNull.Value);
            oracleParams.Add(ProductQuestionearsSPParams.PARAMETER_PRODUCT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)Product.ProductID ?? DBNull.Value);
            oracleParams.Add(ProductQuestionearsSPParams.PARAMETER_PRODUCT_DETAILS_ID, OracleDbType.Int64, ParameterDirection.Input, (object)Product.ProductDetailedID ?? DBNull.Value);
            oracleParams.Add(ProductQuestionearsSPParams.PARAMETER_LINE_OF_BUSSNIESS, OracleDbType.Int64, ParameterDirection.Input, (object)Product.LineOfBusniess ?? DBNull.Value);
            oracleParams.Add(ProductQuestionearsSPParams.PARAMETER_SUB_LINE_OF_BUSSNIESS, OracleDbType.Int64, ParameterDirection.Input, (object)Product.SubLineOfBusniess ?? DBNull.Value);
            oracleParams.Add(ProductQuestionearsSPParams.PARAMETER_CREATED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)Product.CreateBy ?? DBNull.Value, 20);
            oracleParams.Add(ProductQuestionearsSPParams.PARAMETER_CREATATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)Product.CreationDate ?? DBNull.Value);
            oracleParams.Add(ProductQuestionearsSPParams.PARAMETER_MODIFIED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)Product.ModifiedBy ?? DBNull.Value, 20);
            oracleParams.Add(ProductQuestionearsSPParams.PARAMETER_MODIFICATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)Product.ModificationDate ?? DBNull.Value);

            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)
                complate.message = message;
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
