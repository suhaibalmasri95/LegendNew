using Common.Interfaces;
using Common.Operations;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.ProductSetup.ProductValidation
{
    public static class AddUpdateMode
    {
        public async static Task<IDTO> AddUpdate(Domain.Entities.ProductSetup.ProductColumnValidation productColumns)
        {
            string SPName = "";
            string message = "";
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (productColumns.ID.HasValue)
            {
                oracleParams.Add(ProductValidationSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)productColumns.ID ?? DBNull.Value);
                SPName = ProductValidationSpName.SP_UPADTE_VALIDATION;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(ProductValidationSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = ProductValidationSpName.SP_INSERT_VALIDATION;
                message = "Inserted Successfully";
            }


            oracleParams.Add(ProductValidationSpParams.PARAMETER_LABLE, OracleDbType.Varchar2, ParameterDirection.Input, (object)productColumns.Lable ?? DBNull.Value);
            oracleParams.Add(ProductValidationSpParams.PARAMETER_LABLE2, OracleDbType.Varchar2, ParameterDirection.Input, (object)productColumns.Lable2 ?? DBNull.Value);
            oracleParams.Add(ProductValidationSpParams.PARAMETER_DATA_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)productColumns.DataType ?? DBNull.Value);
            oracleParams.Add(ProductValidationSpParams.PARAMETER_LOC_VALD_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)productColumns.LocValidType ?? DBNull.Value);
            oracleParams.Add(ProductValidationSpParams.PARAMETER_IS_MANDETORY, OracleDbType.Int64, ParameterDirection.Input, (object)productColumns.IsMandetory ?? DBNull.Value);
            oracleParams.Add(ProductValidationSpParams.PARAMETER_MAX_VALUE, OracleDbType.Int64, ParameterDirection.Input, (object)productColumns.MaxValue ?? DBNull.Value);
            oracleParams.Add(ProductValidationSpParams.PARAMETER_MIN_VALUE, OracleDbType.Int64, ParameterDirection.Input, (object)productColumns.MinValue ?? DBNull.Value);
            oracleParams.Add(ProductValidationSpParams.PARAMETER_CHECK_DUPLICATION, OracleDbType.Int64, ParameterDirection.Input, (object)productColumns.CheckDuplication ?? DBNull.Value);
            oracleParams.Add(ProductValidationSpParams.PARAMETER_ST_CAT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)productColumns.CategoryID ?? DBNull.Value);
            oracleParams.Add(ProductValidationSpParams.PARAMETER_ST_PRD_ID, OracleDbType.Int64, ParameterDirection.Input, (object)productColumns.ProductID ?? DBNull.Value);
            oracleParams.Add(ProductValidationSpParams.PARAMETER_ST_PRDT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)productColumns.ProductDetailID ?? DBNull.Value);
            oracleParams.Add(ProductValidationSpParams.PARAMETER_ST_COL_ID, OracleDbType.Int64, ParameterDirection.Input, (object)productColumns.ColumnID ?? DBNull.Value);
        



            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)
                complate.message = message;
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
