using Common.Interfaces;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.ProductSetup.ProductColumns
{
    public class GetProductColumns : Domain.Entities.ProductSetup.ProductColumns, IQueryable
    {
        public async Task<IEnumerable> QueryAsync()
        {
            var dyParam = new OracleDynamicParameters();
            dyParam.Add(ProductColumnSpParam.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ID ?? DBNull.Value);

            dyParam.Add(ProductColumnSpParam.PARAMETER_ST_PRD_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ProductID ?? DBNull.Value);
            dyParam.Add(ProductColumnSpParam.PARAMETER_ST_PRDT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ProductDetailID ?? DBNull.Value);
            dyParam.Add(ProductColumnSpParam.PARAMETER_COL_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)this.ColumnType ?? DBNull.Value);
            dyParam.Add(ProductColumnSpParam.PARAMETER_LINE_OF_BUSNIESS, OracleDbType.Int64, ParameterDirection.Input, (object)this.LineOfBusniess ?? DBNull.Value);
            dyParam.Add(ProductColumnSpParam.PARAMETER_SUB_LINE_OF_BUSNIESS, OracleDbType.Int64, ParameterDirection.Input, (object)this.SubLineOfBusniess ?? DBNull.Value);
            dyParam.Add(ProductColumnSpParam.PARAMETER_ST_CAT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.CategoryID ?? DBNull.Value);

            dyParam.Add(ProductColumnSpParam.PARAMETER_LANG_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.LangID ?? DBNull.Value);
            dyParam.Add(ProductColumnSpParam.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);

            return await QueryExecuter.ExecuteQueryAsync<Domain.Entities.ProductSetup.ProductColumns>(ProductColumnsSpName.SP_LOAD_COLUMN, dyParam);
        }
    }
}
