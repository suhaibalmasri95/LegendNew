using System;
using System.Collections;
using System.Data;
using System.Threading.Tasks;
using Common.Interfaces;
using Domain.Entities.ProductSetup;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;

namespace Domain.Operations.ProductSetup.Charges
{
    public class GetCharges : ProductCharges, IQueryable
    {
        public async Task<IEnumerable> QueryAsync()
        {
            var parameters = new OracleDynamicParameters();
            parameters.Add(ChargeSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ID ?? DBNull.Value);
            parameters.Add(ChargeSpParams.PARAMETER_ST_LOB, OracleDbType.Int64, ParameterDirection.Input, (object)this.LineOfBusiness ?? DBNull.Value);
            parameters.Add(ChargeSpParams.PARAMETER_ST_SUB_LOB, OracleDbType.Int64, ParameterDirection.Input, (object)this.SubLineOfBusiness ?? DBNull.Value);
            parameters.Add(ChargeSpParams.PARAMETER_ST_PRD_PRCD_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.PricingID ?? DBNull.Value);
            parameters.Add(ChargeSpParams.PARAMETER_LOC_CHARG_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)this.LocChargeType ?? DBNull.Value);
            parameters.Add(ChargeSpParams.PARAMETER_ST_CHG_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ChargeID ?? DBNull.Value);
            parameters.Add(ChargeSpParams.PARAMETER_ST_PRD_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ProductID ?? DBNull.Value);
            parameters.Add(ChargeSpParams.PARAMETER_ST_PRDT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ProductDetaiID ?? DBNull.Value);
            parameters.Add(ChargeSpParams.PARAMETER_ST_SBT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.SbtID ?? DBNull.Value);
            parameters.Add(ChargeSpParams.PARAMETER_ST_DIC_COL_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.Dictionary ?? DBNull.Value);
            parameters.Add(ChargeSpParams.PARAMETER_ST_PRD_FACT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ProductFactorID ?? DBNull.Value);
            parameters.Add(ChargeSpParams.PARAMETER_LANG_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.LangID ?? DBNull.Value);
            parameters.Add(ChargeSpParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);

            return await QueryExecuter.ExecuteQueryAsync<ProductCharges>(ChargeSpName.SP_LOAD_CHARGE, parameters);
        }
    }
}
