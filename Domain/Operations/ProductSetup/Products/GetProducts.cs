using Common.Interfaces;
using Domain.Entities.ProductSetup;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.ProductSetup.Products
{
    public class GetProducts : Product, IQueryable
    {
        public async Task<IEnumerable> QueryAsync()
        {
            var parameters = new OracleDynamicParameters();
            parameters.Add(ProductSPParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ID ?? DBNull.Value);
            parameters.Add(ProductSPParams.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)this.Name ?? DBNull.Value);
            parameters.Add(ProductSPParams.PARAMETER_LANG_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.LangID ?? DBNull.Value);
            parameters.Add(ProductSPParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);
            return await QueryExecuter.ExecuteQueryAsync<Product>(ProductSPName.SP_LOAD_PRODUCT, parameters);
        }
    }
}
