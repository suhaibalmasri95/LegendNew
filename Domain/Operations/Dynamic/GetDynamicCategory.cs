using Common.Interfaces;
using Domain.Entities.ProductDynamic;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Dynamic
{
    public class GetDynamicCategory : ProductDynmicCategory,  IQueryable
    {
        public async Task<IEnumerable> QueryAsync()
        {
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(DynamicCategoryParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)ID ?? DBNull.Value);
            dyParam.Add(DynamicCategoryParams.PARAMETER_PRORDUCT_ST_CAT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)CategoryID ?? DBNull.Value);
            dyParam.Add(DynamicCategoryParams.PARAMETER_PRORDUCT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)ProductID ?? DBNull.Value);
            dyParam.Add(DynamicCategoryParams.PARAMETER_PRORDUCT_DETAILS_ID, OracleDbType.Int64, ParameterDirection.Input, (object)ProductDetailID ?? DBNull.Value);
            dyParam.Add(DynamicCategoryParams.PARAMETER_PRORDUCT_CAT_LEVEL, OracleDbType.Int64, ParameterDirection.Input, (object)CategoryLevel ?? DBNull.Value);
            dyParam.Add(DynamicCategoryParams.PARAMETER_PRORDUCT_ST_LOB, OracleDbType.Int64, ParameterDirection.Input, (object)LineOfBuisness ?? DBNull.Value);
            dyParam.Add(DynamicCategoryParams.PARAMETER_PRORDUCT_ST_SUB_LOB, OracleDbType.Int64, ParameterDirection.Input, (object)SubLineOfBuisness ?? DBNull.Value);
            dyParam.Add(DynamicCategoryParams.PARAMETER_LANG_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)LangID ?? DBNull.Value);
            dyParam.Add(DynamicCategoryParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);

            return await QueryExecuter.ExecuteQueryAsync<ProductDynmicCategory>(DynamicCategorySpName.SP_LOAD_CATEGORY_INSERT, dyParam);
        }



        public async Task<IEnumerable> QueryAsyncUpdate()
        {
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(DynamicCategoryParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)ID ?? DBNull.Value);
            dyParam.Add(DynamicCategoryParams.PARAMETER_ST_PRD_CAT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)CategoryID ?? DBNull.Value);
            dyParam.Add(DynamicCategoryParams.PARAMETER_UW_RISK_ID, OracleDbType.Int64, ParameterDirection.Input, (object)ProductID ?? DBNull.Value);
            dyParam.Add(DynamicCategoryParams.PARAMETER_UW_DOC_ID, OracleDbType.Int64, ParameterDirection.Input, (object)ProductDetailID ?? DBNull.Value);
            dyParam.Add(DynamicCategoryParams.PARAMETER_UW_MBR_ID, OracleDbType.Int64, ParameterDirection.Input, (object)CategoryLevel ?? DBNull.Value);
            dyParam.Add(DynamicCategoryParams.PARAMETER_PRORDUCT_ST_LOB, OracleDbType.Int64, ParameterDirection.Input, (object)LineOfBuisness ?? DBNull.Value);
            dyParam.Add(DynamicCategoryParams.PARAMETER_PRORDUCT_ST_SUB_LOB, OracleDbType.Int64, ParameterDirection.Input, (object)SubLineOfBuisness ?? DBNull.Value);
            dyParam.Add(DynamicCategoryParams.PARAMETER_LANG_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)LangID ?? DBNull.Value);
            dyParam.Add(DynamicCategoryParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);

            return await QueryExecuter.ExecuteQueryAsync<ProductDynmicCategory>(DynamicCategorySpName.SP_LOAD_CATEGORY_INSERT, dyParam);
        }


       
    }

}
