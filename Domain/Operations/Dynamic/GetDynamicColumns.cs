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
    public class GetDynamicColumns : ProductDynamicColumn,  IQueryable
    {
        public async Task<IEnumerable> QueryAsync()
        {
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(DynamicColumnsParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)ID ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_PRORDUCT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)ProductID ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_PRORDUCT_DETAILS_ID, OracleDbType.Int64, ParameterDirection.Input, (object)ProductDetailID ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_COLUMN_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)ColumnType ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_ST_LOB, OracleDbType.Int64, ParameterDirection.Input, (object)LineOfBuisness ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_ST_SUB_LOB, OracleDbType.Int64, ParameterDirection.Input, (object)SubLineOfBuisness ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_ST_CAT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)CategoryID ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_EXECLUDE_COL_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)ExecludedColumn ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_EXECLUDE_UW_DOC_ID, OracleDbType.Int64, ParameterDirection.Input, (object)UnderWritingDocID ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_PARENT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)ParentID ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_LANG_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)LangID ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);

            return await QueryExecuter.ExecuteQueryAsync<ProductDynamicColumn>(DynamicColumnSpName.SP_LOAD_COLUMNS, dyParam);
        }
        public async Task<IEnumerable> QueryAsyncInsert()
        {
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(DynamicColumnsParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)ID ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_PRORDUCT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)ProductID ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_PRORDUCT_DETAILS_ID, OracleDbType.Int64, ParameterDirection.Input, (object)ProductDetailID ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_COLUMN_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)ColumnType ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_ST_LOB, OracleDbType.Int64, ParameterDirection.Input, (object)LineOfBuisness ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_ST_SUB_LOB, OracleDbType.Int64, ParameterDirection.Input, (object)SubLineOfBuisness ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_ST_CAT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)CategoryID ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_EXECLUDE_COL_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)ExecludedColumn ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_PARENT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)ParentID ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_LANG_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)LangID ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);

            return await QueryExecuter.ExecuteQueryAsync<DynamicDdl>(DynamicColumnSpName.SP_LOAD_COLUMNS, dyParam);
        }
        public async Task<IEnumerable> QueryAsyncUpdate()
        {
            var dyParam = new OracleDynamicParameters();
            dyParam.Add(DynamicColumnsParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)ID ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_PRORDUCT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)ProductID ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_PRORDUCT_DETAILS_ID, OracleDbType.Int64, ParameterDirection.Input, (object)ProductDetailID ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_COLUMN_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)ColumnType ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_ST_LOB, OracleDbType.Int64, ParameterDirection.Input, (object)LineOfBuisness ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_ST_SUB_LOB, OracleDbType.Int64, ParameterDirection.Input, (object)SubLineOfBuisness ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_ST_CAT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)CategoryID ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_EXECLUDE_COL_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)ExecludedColumn ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_EXECLUDE_UW_DOC_ID, OracleDbType.Int64, ParameterDirection.Input, (object)UnderWritingDocID ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_PARENT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)ParentID ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_LANG_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)LangID ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);
    
            return await QueryExecuter.ExecuteQueryAsync<ProductDynamicColumn>(DynamicColumnSpName.SP_LOAD_COLUMNS_UPDATE, dyParam);
        }
        public async Task<IEnumerable> QueryDllAsyncInsert()
        {
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(DynamicColumnsParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)ID ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_PRORDUCT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)ProductID ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_PRORDUCT_DETAILS_ID, OracleDbType.Int64, ParameterDirection.Input, (object)ProductDetailID ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_COLUMN_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)ColumnType ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_ST_LOB, OracleDbType.Int64, ParameterDirection.Input, (object)LineOfBuisness ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_ST_SUB_LOB, OracleDbType.Int64, ParameterDirection.Input, (object)SubLineOfBuisness ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_ST_CAT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)CategoryID ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_EXECLUDE_COL_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)ExecludedColumn ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_PARENT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)ParentID ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_LANG_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)LangID ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);

            return await QueryExecuter.ExecuteQueryAsync<DynamicDdl>(DynamicColumnSpName.SP_LOAD_COLUMNS, dyParam);
        }
        public async Task<IEnumerable> QueryDllAsyncUpdate()
        {
            var dyParam = new OracleDynamicParameters();
            dyParam.Add(DynamicColumnsParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)ID ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_PRORDUCT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)ProductID ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_PRORDUCT_DETAILS_ID, OracleDbType.Int64, ParameterDirection.Input, (object)ProductDetailID ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_COLUMN_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)ColumnType ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_ST_LOB, OracleDbType.Int64, ParameterDirection.Input, (object)LineOfBuisness ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_ST_SUB_LOB, OracleDbType.Int64, ParameterDirection.Input, (object)SubLineOfBuisness ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_ST_CAT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)CategoryID ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_EXECLUDE_COL_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)ExecludedColumn ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_EXECLUDE_UW_DOC_ID, OracleDbType.Int64, ParameterDirection.Input, (object)UnderWritingDocID ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_PARENT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)ParentID ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_UW_RISK_ID , OracleDbType.Int64, ParameterDirection.Input, (object)UnderWritingRiskID ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_LANG_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)LangID ?? DBNull.Value);
            dyParam.Add(DynamicColumnsParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);

            return await QueryExecuter.ExecuteQueryAsync<DynamicDdl>(DynamicColumnSpName.SP_LOAD_COLUMNS_UPDATE, dyParam);
          
        }
    }
}
