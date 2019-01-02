using Common.Interfaces;
using Common.Operations;
using Domain.Entities.ProductDynamic;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Production.Columns
{
    public static class AddUpdateCoulmns
    {
        public async static Task<IDTO> AddUpdateMode(ProductDynamicColumn column)
        {
            string SPName = "";
            string message = "";
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (column.UwColID.HasValue)
            {
                oracleParams.Add(ColumnsSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)column.ID ?? DBNull.Value);
                SPName = ColumsSpName.SP_UPADTE_COLUMNS;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(ColumnsSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = ColumsSpName.SP_INSERT_COLUMNS;
                message = "Inserted Successfully";
            }


            oracleParams.Add(ColumnsSpParams.PARAMETER_LABLE, OracleDbType.Varchar2, ParameterDirection.Input, (object)column.Lable ?? DBNull.Value, 100);
            oracleParams.Add(ColumnsSpParams.PARAMETER_LABLE2, OracleDbType.Varchar2, ParameterDirection.Input, (object)column.Lable2 ?? DBNull.Value, 100);
            oracleParams.Add(ColumnsSpParams.PARAMETER_UW_COL_CAT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)column.UnderWritingColCatID ?? DBNull.Value);
            oracleParams.Add(ColumnsSpParams.PARAMETER_ST_PRD_CAT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)column.ProductCategoryID ?? DBNull.Value);
            oracleParams.Add(ColumnsSpParams.PARAMETER_ST_PRD_COL_ID, OracleDbType.Int64, ParameterDirection.Input, (object)column.ProductColumnID ?? DBNull.Value, 50);
            oracleParams.Add(ColumnsSpParams.PARAMETER_VALUE_DATE, OracleDbType.Date, ParameterDirection.Input, (object)column.ValueDate ?? DBNull.Value);
            oracleParams.Add(ColumnsSpParams.PARAMETER_VALUE_AMOUNT, OracleDbType.Int64, ParameterDirection.Input, (object)column.ValueAmount ?? DBNull.Value);
            oracleParams.Add(ColumnsSpParams.PARAMETER_VALUE_DESC, OracleDbType.Varchar2, ParameterDirection.Input, (object)column.ValueDesc ?? DBNull.Value);
            oracleParams.Add(ColumnsSpParams.PARAMETER_VAL_LOC_ID, OracleDbType.Int64, ParameterDirection.Input, (object)column.ValueLockUpID ?? DBNull.Value);
            oracleParams.Add(ColumnsSpParams.PARAMETER_UW_RISK_ID, OracleDbType.Int64, ParameterDirection.Input, (object)column.UnderWritingRiskID ?? DBNull.Value);
            oracleParams.Add(ColumnsSpParams.PARAMETER_UW_DOC_ID, OracleDbType.Int64, ParameterDirection.Input, (object)column.UnderWritingDocID ?? DBNull.Value);
            oracleParams.Add(ColumnsSpParams.PARAMETER_COL_ORDER, OracleDbType.Int64, ParameterDirection.Input, (object)column.ColumnOrder ?? DBNull.Value);
            oracleParams.Add(ColumnsSpParams.PARAMETER_ST_COL_ID, OracleDbType.Int64, ParameterDirection.Input, (object)column.ColumnID ?? DBNull.Value);
            oracleParams.Add(ColumnsSpParams.PARAMETER_ST_DIC_ID, OracleDbType.Int64, ParameterDirection.Input, (object)column.Dictionary ?? DBNull.Value);
            oracleParams.Add(ColumnsSpParams.PARAMETER_ST_DIC_COL_ID, OracleDbType.Int64, ParameterDirection.Input, (object)column.DictionaryColumnID ?? DBNull.Value);

            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)
                complate.message = message;
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
