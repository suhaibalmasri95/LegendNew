using System;
using System.Collections;
using System.Data;
using System.Threading.Tasks;
using Common.Interfaces;
using Domain.Entities.Production;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;

namespace Domain.Operations.Production.FactorDetails
{
    public class GetFactorDetails : FactorDetail, IQueryable
    {
        public async Task<IEnumerable> QueryAsync()
        {
            var parameters = new OracleDynamicParameters();
            parameters.Add(FactorDetailSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ID ?? DBNull.Value);
            parameters.Add(FactorDetailSpParams.PARAMETER_ST_DIC_COL_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.DictionaryID ?? DBNull.Value);
            parameters.Add(FactorDetailSpParams.PARAMETER_ST_PRD_FACT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.FactorID ?? DBNull.Value);
            parameters.Add(FactorDetailSpParams.PARAMETER_ST_CHG_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ChargeID ?? DBNull.Value);
            parameters.Add(FactorDetailSpParams.PARAMETER_ST_PRD_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ProductID ?? DBNull.Value);
            parameters.Add(FactorDetailSpParams.PARAMETER_ST_PRDT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ProductDetailID ?? DBNull.Value);
            parameters.Add(FactorDetailSpParams.PARAMETER_ST_PRD_FACD_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ProductFacdID ?? DBNull.Value);
            parameters.Add(FactorDetailSpParams.PARAMETER_ENTRY_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)this.EntryType ?? DBNull.Value);
            parameters.Add(FactorDetailSpParams.PARAMETER_LANG_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.LangID ?? DBNull.Value);
            parameters.Add(FactorDetailSpParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);

            return await QueryExecuter.ExecuteQueryAsync<FactorDetail>(FactorDetailSpName.SP_LOAD_FACTOR_DETAIL, parameters);
        }
    }
}
