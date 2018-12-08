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

namespace Domain.Operations.Setup.ProductsSubjectstypies
{
    public class GetProductSubjectTypies : ProductSubjectType, IQueryable
    {
        public async Task<IEnumerable> QueryAsync()
        {
            var parameters = new OracleDynamicParameters();
            parameters.Add(ProductSubjectsTypiesSPParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ID ?? DBNull.Value);
            parameters.Add(ProductSubjectsTypiesSPParams.PARAMETER_PRODUCT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ProductID ?? DBNull.Value);
            parameters.Add(ProductSubjectsTypiesSPParams.PARAMETER_PRODUCT_DETAILS_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ProductDetailsID ?? DBNull.Value);
            parameters.Add(ProductSubjectsTypiesSPParams.PARAMETER_LANG_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.LangID ?? DBNull.Value);
            parameters.Add(ProductSubjectsTypiesSPParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);
            return await QueryExecuter.ExecuteQueryAsync<ProductSubjectType>(ProductSubjectsTypiesSPName.SP_LOAD_PRODUCT_SUBJECT_TYPE, parameters);
        }
    }
}
