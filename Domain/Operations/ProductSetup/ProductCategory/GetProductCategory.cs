using Common.Interfaces;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.ProductSetup.ProductCategory
{
   public class GetProductCategory : Domain.Entities.ProductSetup.ProductCategory, IQueryable
    {
        public async Task<IEnumerable> QueryAsync()
        {
            var dyParam = new OracleDynamicParameters();
            dyParam.Add(ProductCategorySpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ID ?? DBNull.Value);

            dyParam.Add(ProductCategorySpParams.PARAMETER_ST_CAT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.CategoryID ?? DBNull.Value);
            dyParam.Add(ProductCategorySpParams.PARAMETER_ST_PRDT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ProductID ?? DBNull.Value);
            dyParam.Add(ProductCategorySpParams.PARAMETER_ST_PRDT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ProductDetailID ?? DBNull.Value);
            dyParam.Add(ProductCategorySpParams.PARAMETER_CAT_LEVEL, OracleDbType.Int64, ParameterDirection.Input, (object)this.CategoryLevel ?? DBNull.Value);
            dyParam.Add(ProductCategorySpParams.PARAMETER_LINE_OF_BUSNIESS, OracleDbType.Int64, ParameterDirection.Input, (object)this.LineOfBusniess ?? DBNull.Value);
            dyParam.Add(ProductCategorySpParams.PARAMETER_SUB_LINE_OF_BUSNIESS, OracleDbType.Int64, ParameterDirection.Input, (object)this.SubLineOfBusniess ?? DBNull.Value);
            dyParam.Add(ProductCategorySpParams.PARAMETER_LANG_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.LangID ?? DBNull.Value);
            dyParam.Add(ProductCategorySpParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);

            return await QueryExecuter.ExecuteQueryAsync<Domain.Entities.ProductSetup.ProductCategory>(ProductCategorySpName.SP_LOAD_CATEGORY, dyParam);
        }
    }
}
