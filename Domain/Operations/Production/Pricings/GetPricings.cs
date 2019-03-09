using System;
using System.Collections;
using System.Data;
using System.Threading.Tasks;
using Common.Interfaces;
using Domain.Entities.Production;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;

namespace Domain.Operations.Production.Pricings
{
    public class GetPricings : Pricing, IQueryable
    {
        public async Task<IEnumerable> QueryAsync()
        {
            var parameters = new OracleDynamicParameters();
            parameters.Add(PricingSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ID ?? DBNull.Value);
            parameters.Add(PricingSpParams.PARAMETER_ST_PRD_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ProductID ?? DBNull.Value);
            parameters.Add(PricingSpParams.PARAMETER_LOC_PRICE_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)this.PricingType ?? DBNull.Value);
            parameters.Add(PricingSpParams.PARAMETER_FIN_CST_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.CustomerID ?? DBNull.Value);
            parameters.Add(PricingSpParams.PARAMETER_LANG_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.LangID ?? DBNull.Value);
            parameters.Add(PricingSpParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);

            return await QueryExecuter.ExecuteQueryAsync<Pricing>(PricingSpName.SP_LOAD_PRICING, parameters);
        }
    }
    }
