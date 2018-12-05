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

namespace Domain.Operations.Setup.Categories
{
    public static class CategoryCreateUpdateSetup
    {
        public async static Task<IDTO> AddUpdate(Category category)
        {
            var SPName = default(string);
            var message = default(string);
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (category.ID.HasValue)
            {
                oracleParams.Add(CategorySpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)category.ID ?? DBNull.Value);

                SPName = CategorySpName.SP_UPADTE_CATEGORY;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(CategorySpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = CategorySpName.SP_INSERT_CATEGORY;
                message = "Inserted Successfully";
            }
            oracleParams.Add(CategorySpParams.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)category.Name ?? DBNull.Value, 1000);
            oracleParams.Add(CategorySpParams.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)category.Name2 ?? DBNull.Value, 1000);
            oracleParams.Add(CategorySpParams.PARAMETER_LABLE, OracleDbType.Varchar2, ParameterDirection.Input, (object)category.Label ?? DBNull.Value, 1000);
            oracleParams.Add(CategorySpParams.PARAMETER_LABLE2, OracleDbType.Varchar2, ParameterDirection.Input, (object)category.Label2 ?? DBNull.Value, 1000);
            oracleParams.Add(CategorySpParams.PARAMETER_STATUS, OracleDbType.Int64, ParameterDirection.Input, (object)category.Status ?? DBNull.Value);
            oracleParams.Add(CategorySpParams.PARAMETER_STATUS_DATE, OracleDbType.Date, ParameterDirection.Input, (object)category.StatusDate ?? DBNull.Value);
            oracleParams.Add(CategorySpParams.PARAMETER_LINE_OF_BUSNIESS, OracleDbType.Int64, ParameterDirection.Input, (object)category.LineOfBusniess ?? DBNull.Value);
            oracleParams.Add(CategorySpParams.PARAMETER_SUB_LINE_OF_BUSNIESS, OracleDbType.Int64, ParameterDirection.Input, (object)category.SubLineOfBusniess ?? DBNull.Value);
            oracleParams.Add(CategorySpParams.PARAMETER_CREATED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)category.CreateBy ?? DBNull.Value, 20);
            oracleParams.Add(CategorySpParams.PARAMETER_CREATATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)category.CreationDate ?? DBNull.Value);
            oracleParams.Add(CategorySpParams.PARAMETER_MODIFIED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)category.ModifiedBy ?? DBNull.Value, 20);
            oracleParams.Add(CategorySpParams.PARAMETER_MODIFICATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)category.ModificationDate ?? DBNull.Value);
            oracleParams.Add(CategorySpParams.PARAMETER_CAT_LEVEL, OracleDbType.Int64, ParameterDirection.Input, (object)category.CategoryLevel ?? DBNull.Value);
            oracleParams.Add(CategorySpParams.PARAMETER_IS_MULTI_RECORDS, OracleDbType.Int16, ParameterDirection.Input, (object)category.MultiRecord ?? DBNull.Value);

            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)
                complate.message = message;
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
