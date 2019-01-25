using Common.Interfaces;
using Common.Operations;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.ProductSetup.ProductCategory
{
   public static class AddUpdateMode
    {
        public async static Task<IDTO> AddUpdate(Domain.Entities.ProductSetup.ProductCategory productCategory)
        {
            string SPName = "";
            string message = "";
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (productCategory.ID.HasValue)
            {
                oracleParams.Add(ProductCategorySpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)productCategory.ID ?? DBNull.Value);
                SPName = ProductCategorySpName.SP_UPADTE_CATEGORY;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(ProductCategorySpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = ProductCategorySpName.SP_INSERT_CATEGORY;
                message = "Inserted Successfully";
            }

            oracleParams.Add(ProductCategorySpParams.PARAMETER_ST_CAT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)productCategory.CategoryID ?? DBNull.Value);
            oracleParams.Add(ProductCategorySpParams.PARAMETER_LABLE, OracleDbType.Varchar2, ParameterDirection.Input, (object)productCategory.Lable ?? DBNull.Value);
            oracleParams.Add(ProductCategorySpParams.PARAMETER_LABLE2, OracleDbType.Varchar2, ParameterDirection.Input, (object)productCategory.Lable2 ?? DBNull.Value);
            oracleParams.Add(ProductCategorySpParams.PARAMETER_STATUS, OracleDbType.Int64, ParameterDirection.Input, (object)productCategory.Status ?? DBNull.Value);
            oracleParams.Add(ProductCategorySpParams.PARAMETER_STATUS_DATE, OracleDbType.Date, ParameterDirection.Input, (object)productCategory.StatusDate ?? DBNull.Value);
            oracleParams.Add(ProductCategorySpParams.PARAMETER_LINE_OF_BUSNIESS, OracleDbType.Int64, ParameterDirection.Input, (object)productCategory.LineOfBusniess ?? DBNull.Value);
            oracleParams.Add(ProductCategorySpParams.PARAMETER_SUB_LINE_OF_BUSNIESS, OracleDbType.Int64, ParameterDirection.Input, (object)productCategory.SubLineOfBusniess ?? DBNull.Value);
            oracleParams.Add(ProductCategorySpParams.PARAMETER_CREATED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)productCategory.CreateBy ?? DBNull.Value);
            oracleParams.Add(ProductCategorySpParams.PARAMETER_CREATATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)productCategory.CreationDate ?? DBNull.Value);
            oracleParams.Add(ProductCategorySpParams.PARAMETER_MODIFIED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)productCategory.ModifiedBy ?? DBNull.Value);
            oracleParams.Add(ProductCategorySpParams.PARAMETER_MODIFICATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)productCategory.ModificationDate ?? DBNull.Value);
            oracleParams.Add(ProductCategorySpParams.PARAMETER_CAT_LEVEL, OracleDbType.Int64, ParameterDirection.Input, (object)productCategory.CategoryLevel ?? DBNull.Value);
            oracleParams.Add(ProductCategorySpParams.PARAMETER_IS_MULTI_RECORDS, OracleDbType.Int64, ParameterDirection.Input, (object)productCategory.MultiRecord ?? DBNull.Value);
            oracleParams.Add(ProductCategorySpParams.PARAMETER_ST_PRD_ID, OracleDbType.Int64, ParameterDirection.Input, (object)productCategory.ProductID ?? DBNull.Value);
            oracleParams.Add(ProductCategorySpParams.PARAMETER_ST_PRDT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)productCategory.ProductDetailID ?? DBNull.Value);
            oracleParams.Add(ProductCategorySpParams.PARAMETER_COL_ORDER, OracleDbType.Int64, ParameterDirection.Input, (object)productCategory.Order ?? DBNull.Value);
            oracleParams.Add(ProductCategorySpParams.PARAMETER_ST_DIC_ID, OracleDbType.Int64, ParameterDirection.Input, (object)productCategory.DictionaryID ?? DBNull.Value);

            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)
                complate.message = message;
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
