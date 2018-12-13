using Common.Interfaces;
using Domain.Entities.Setup;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Setup.Columns
{
    public class GetColumns : Column, IQueryable
    {
        public async Task<IEnumerable> QueryAsync()
        {
            var parameters = new OracleDynamicParameters();
            parameters.Add(ColumnSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ID ?? DBNull.Value);
            parameters.Add(ColumnSpParams.PARAMETER_COLUMN_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)this.ColumnType ?? DBNull.Value);
            parameters.Add(ColumnSpParams.PARAMETER_LINE_OF_BUSNIESS, OracleDbType.Int64, ParameterDirection.Input, (object)this.LineOfBusniess ?? DBNull.Value);
            parameters.Add(ColumnSpParams.PARAMETER_SUB_LINE_OF_BUSNIESS, OracleDbType.Int64, ParameterDirection.Input, (object)this.SubLineOfBusniess ?? DBNull.Value);
            parameters.Add(ColumnSpParams.PARAMETER_CATEGORY_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.CategoryID ?? DBNull.Value);
            parameters.Add(ColumnSpParams.PARAMETER_LANG_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.LangID ?? DBNull.Value);
            parameters.Add(ColumnSpParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);
            return await QueryExecuter.ExecuteQueryAsync<Column>(ColumnSpName.SP_LOAD_COLUMNS, parameters);
        }
    }
}
