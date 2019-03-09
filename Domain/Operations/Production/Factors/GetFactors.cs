using System;
using System.Collections;
using System.Data;
using System.Threading.Tasks;
using Common.Interfaces;
using Domain.Entities.Production;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;

namespace Domain.Operations.Production.Factors
{
    public class GetFactors : Factor, IQueryable
    {
        public async Task<IEnumerable> QueryAsync()
        {
            var parameters = new OracleDynamicParameters();
            parameters.Add(FactorSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ID ?? DBNull.Value);
            parameters.Add(FactorSpParams.PARAMETER_ST_PRD_PRCD_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.PricingID ?? DBNull.Value);
            parameters.Add(FactorSpParams.PARAMETER_ST_DIC_COL_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.DictionaryID ?? DBNull.Value);
            parameters.Add(FactorSpParams.PARAMETER_ST_PRD_FACT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ProductFactorID ?? DBNull.Value);
            parameters.Add(FactorSpParams.PARAMETER_FACT_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)this.FactorType ?? DBNull.Value);
            parameters.Add(FactorSpParams.PARAMETER_LANG_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.LangID ?? DBNull.Value);
            parameters.Add(FactorSpParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);

            return await QueryExecuter.ExecuteQueryAsync<Factor>(FactorSpName.SP_LOAD_FACTOR, parameters);
        }
    }
}
