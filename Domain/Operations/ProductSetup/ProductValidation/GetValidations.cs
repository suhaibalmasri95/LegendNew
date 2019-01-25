using Common.Interfaces;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.ProductSetup.ProductValidation
{
   public class GetValidations : Domain.Entities.ProductSetup.ProductColumnValidation, IQueryable
    {
        public async Task<IEnumerable> QueryAsync()
        {
            var dyParam = new OracleDynamicParameters();
            dyParam.Add(ProductValidationSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ID ?? DBNull.Value);
            dyParam.Add(ProductValidationSpParams.PARAMETER_ST_COL_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ColumnID ?? DBNull.Value);
            dyParam.Add(ProductValidationSpParams.PARAMETER_ST_PRD_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ProductID ?? DBNull.Value);
            dyParam.Add(ProductValidationSpParams.PARAMETER_ST_PRDT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ProductDetailID ?? DBNull.Value);
            dyParam.Add(ProductValidationSpParams.PARAMETER_LOC_VALD_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)this.LocValidType ?? DBNull.Value);
            dyParam.Add(ProductValidationSpParams.PARAMETER_ST_CAT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.CategoryID ?? DBNull.Value);

            dyParam.Add(ProductValidationSpParams.PARAMETER_LANG_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.LangID ?? DBNull.Value);
            dyParam.Add(ProductValidationSpParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);

            return await QueryExecuter.ExecuteQueryAsync<Domain.Entities.ProductSetup.ProductColumnValidation>(ProductValidationSpName.SP_LOAD_VALIDATION, dyParam);
        }
    }
}
