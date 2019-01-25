using Common.Interfaces;
using Common.Operations;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.ProductSetup.ProductColumns
{
    public static class AddUpdateMode
    {
        public async static Task<IDTO> AddUpdate(Domain.Entities.ProductSetup.ProductColumns productColumns)
        {
            string SPName = "";
            string message = "";
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (productColumns.ID.HasValue)
            {
                oracleParams.Add(ProductColumnSpParam.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)productColumns.ID ?? DBNull.Value);
                SPName = ProductColumnsSpName.SP_UPADTE_COLUMN;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(ProductColumnSpParam.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = ProductColumnsSpName.SP_INSERT_COLUMN;
                message = "Inserted Successfully";
            }


            oracleParams.Add(ProductColumnSpParam.PARAMETER_LABLE, OracleDbType.Varchar2, ParameterDirection.Input, (object)productColumns.Lable ?? DBNull.Value);
            oracleParams.Add(ProductColumnSpParam.PARAMETER_LABLE2, OracleDbType.Varchar2, ParameterDirection.Input, (object)productColumns.Lable2 ?? DBNull.Value);
            oracleParams.Add(ProductColumnSpParam.PARAMETER_COL_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)productColumns.ColumnType ?? DBNull.Value);
            oracleParams.Add(ProductColumnSpParam.PARAMETER_STATUS, OracleDbType.Int64, ParameterDirection.Input, (object)productColumns.Status ?? DBNull.Value);
            oracleParams.Add(ProductColumnSpParam.PARAMETER_STATUS_DATE, OracleDbType.Date, ParameterDirection.Input, (object)productColumns.StatusDate ?? DBNull.Value);
            oracleParams.Add(ProductColumnSpParam.PARAMETER_LINE_OF_BUSNIESS, OracleDbType.Int64, ParameterDirection.Input, (object)productColumns.LineOfBusniess ?? DBNull.Value);
            oracleParams.Add(ProductColumnSpParam.PARAMETER_SUB_LINE_OF_BUSNIESS, OracleDbType.Int64, ParameterDirection.Input, (object)productColumns.SubLineOfBusniess ?? DBNull.Value);
            oracleParams.Add(ProductColumnSpParam.PARAMETER_LOC_LEVEL, OracleDbType.Int64, ParameterDirection.Input, (object)productColumns.LocLevel ?? DBNull.Value);
            oracleParams.Add(ProductColumnSpParam.PARAMETER_ST_PRD_CLO_ID, OracleDbType.Int64, ParameterDirection.Input, (object)productColumns.PrdColumnID ?? DBNull.Value);
            oracleParams.Add(ProductColumnSpParam.PARAMETER_ST_PRD_CAT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)productColumns.ProductCategoryID ?? DBNull.Value);
            oracleParams.Add(ProductColumnSpParam.PARAMETER_ST_CAT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)productColumns.CategoryID ?? DBNull.Value);
            oracleParams.Add(ProductColumnSpParam.PARAMETER_ST_PRD_ID, OracleDbType.Int64, ParameterDirection.Input, (object)productColumns.ProductID ?? DBNull.Value);
            oracleParams.Add(ProductColumnSpParam.PARAMETER_ST_PRDT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)productColumns.ProductDetailID ?? DBNull.Value);
            oracleParams.Add(ProductColumnSpParam.PARAMETER_COL_ORDER, OracleDbType.Int64, ParameterDirection.Input, (object)productColumns.Order ?? DBNull.Value);
            oracleParams.Add(ProductColumnSpParam.PARAMETER_ST_COL_ID, OracleDbType.Int64, ParameterDirection.Input, (object)productColumns.ColumnID ?? DBNull.Value);
            oracleParams.Add(ProductColumnSpParam.PARAMETER_ST_DIC_ID, OracleDbType.Int64, ParameterDirection.Input, (object)productColumns.DictionaryID ?? DBNull.Value);
            oracleParams.Add(ProductColumnSpParam.PARAMETER_ST_DIC_COL_ID, OracleDbType.Int64, ParameterDirection.Input, (object)productColumns.DictionaryColumnID ?? DBNull.Value);
            oracleParams.Add(ProductColumnSpParam.PARAMETER_REF_TABLE, OracleDbType.Int64, ParameterDirection.Input, (object)productColumns.RefTable ?? DBNull.Value);
            oracleParams.Add(ProductColumnSpParam.PARAMETER_WHERE_COND, OracleDbType.Int64, ParameterDirection.Input, (object)productColumns.WhereCondition ?? DBNull.Value);
            oracleParams.Add(ProductColumnSpParam.PARAMETER_CREATED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)productColumns.CreateBy ?? DBNull.Value);
            oracleParams.Add(ProductColumnSpParam.PARAMETER_CREATATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)productColumns.CreationDate ?? DBNull.Value);
            oracleParams.Add(ProductColumnSpParam.PARAMETER_MODIFIED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)productColumns.ModifiedBy ?? DBNull.Value);
            oracleParams.Add(ProductColumnSpParam.PARAMETER_MODIFICATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)productColumns.ModificationDate ?? DBNull.Value);




            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)
                complate.message = message;
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
