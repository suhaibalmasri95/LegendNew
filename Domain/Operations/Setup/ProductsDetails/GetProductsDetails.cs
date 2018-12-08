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

namespace Domain.Operations.Setup.ProductsDetails
{
    public class GetProductsDetails : ProductDetails, IQueryable
    {
        public async Task<IEnumerable> QueryAsync()
        {
            var parameters = new OracleDynamicParameters();
            parameters.Add(ProductDetailsSPParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ID ?? DBNull.Value);
            parameters.Add(ProductDetailsSPParams.PARAMETER_PRODUCT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ProductID ?? DBNull.Value);
            parameters.Add(ProductDetailsSPParams.PARAMETER_LANG_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.LangID ?? DBNull.Value);
            parameters.Add(ProductDetailsSPParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);
            return await QueryExecuter.ExecuteQueryAsync<ProductDetails>(ProductDetailsSPName.SP_LOAD_PRODUCT_DETAILS, parameters);
        }
    }
}
