using Common.Interfaces;
using Common.Operations;
using Domain.Entities.Setup;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Setup.Columns
{
    public static class DbColumnSetup
    {

        public async static Task<IDTO> AddUpdate(Column column)
        {
            var SPName = default(string);
            var message = default(string);
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (column.ID.HasValue)
            {
                oracleParams.Add(ColumnSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)column.ID ?? DBNull.Value);

                SPName = ColumnSpName.SP_UPADTE_COLUMN;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(ColumnSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = ColumnSpName.SP_INSERT_COLUMN;
                message = "Inserted Successfully";
            }
            oracleParams.Add(ColumnSpParams.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)column.Name ?? DBNull.Value, 1000);
            oracleParams.Add(ColumnSpParams.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)column.Name2 ?? DBNull.Value, 1000);
            oracleParams.Add(ColumnSpParams.PARAMETER_LABLE, OracleDbType.Varchar2, ParameterDirection.Input, (object)column.Lable ?? DBNull.Value, 1000);
            oracleParams.Add(ColumnSpParams.PARAMETER_LABLE2, OracleDbType.Varchar2, ParameterDirection.Input, (object)column.Lable2 ?? DBNull.Value, 1000);
            oracleParams.Add(ColumnSpParams.PARAMETER_STATUS, OracleDbType.Int64, ParameterDirection.Input, (object)column.Status ?? DBNull.Value);
            oracleParams.Add(ColumnSpParams.PARAMETER_STATUS_DATE, OracleDbType.Date, ParameterDirection.Input, (object)column.StatusDate ?? DBNull.Value);
            oracleParams.Add(ColumnSpParams.PARAMETER_COLUMN_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)column.ColumnType ?? DBNull.Value);
            oracleParams.Add(ColumnSpParams.PARAMETER_LINE_OF_BUSNIESS, OracleDbType.Int64, ParameterDirection.Input, (object)column.LineOfBusniess ?? DBNull.Value);
            oracleParams.Add(ColumnSpParams.PARAMETER_SUB_LINE_OF_BUSNIESS, OracleDbType.Int64, ParameterDirection.Input, (object)column.SubLineOfBusniess ?? DBNull.Value);
            oracleParams.Add(ColumnSpParams.PARAMETER_CREATED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)column.CreateBy ?? DBNull.Value, 20);
            oracleParams.Add(ColumnSpParams.PARAMETER_CREATATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)column.CreationDate ?? DBNull.Value);
            oracleParams.Add(ColumnSpParams.PARAMETER_MODIFIED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)column.ModifiedBy ?? DBNull.Value, 20);
            oracleParams.Add(ColumnSpParams.PARAMETER_MODIFICATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)column.ModificationDate ?? DBNull.Value);
            oracleParams.Add(ColumnSpParams.PARAMETER_CATEGORY_ID, OracleDbType.Int64, ParameterDirection.Input, (object)column.CategoryID ?? DBNull.Value);
            oracleParams.Add(ColumnSpParams.PARAMETER_REF_TABLE_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)column.RefTableName ?? DBNull.Value,1000);
            oracleParams.Add(ColumnSpParams.PARAMETER_REF_MAJOR_CODE, OracleDbType.Varchar2, ParameterDirection.Input, (object)column.RefMajorCode ?? DBNull.Value,1000);
            oracleParams.Add(ColumnSpParams.PARAMETER_REF_COL_DETAILS, OracleDbType.Varchar2, ParameterDirection.Input, (object)column.RefColDetailsID ?? DBNull.Value,1000);

            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)
                complate.message = message;
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
