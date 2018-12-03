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

namespace Domain.Operations.Setup.Categories
{
    public class GetCategories : Category, IQueryable
    {
        public async Task<IEnumerable> QueryAsync()
        {
            var parameters = new OracleDynamicParameters();
            parameters.Add(CategorySpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ID ?? DBNull.Value);
            parameters.Add(CategorySpParams.PARAMETER_CAT_LEVEL, OracleDbType.Int64, ParameterDirection.Input, (object)this.CategoryLevel ?? DBNull.Value);
            parameters.Add(CategorySpParams.PARAMETER_LINE_OF_BUSNIESS, OracleDbType.Int64, ParameterDirection.Input, (object)this.LineOfBusniess ?? DBNull.Value);
            parameters.Add(CategorySpParams.PARAMETER_SUB_LINE_OF_BUSNIESS, OracleDbType.Int64, ParameterDirection.Input, (object)this.SubLineOfBusniess ?? DBNull.Value);
            parameters.Add(CategorySpParams.PARAMETER_LANG_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.LangID ?? DBNull.Value);
            parameters.Add(CategorySpParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);
            return await QueryExecuter.ExecuteQueryAsync<Answer>(CategorySpName.SP_LOAD_CATEGORY, parameters);
        }
    }
}
