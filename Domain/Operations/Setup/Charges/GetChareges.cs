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

namespace Domain.Operations.Setup.Charges
{
   public class GetChareges : Charge, IQueryable
    {
        public async Task<IEnumerable> QueryAsync()
        {
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(ChargeSpParams.PARAMETER_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)ID ?? DBNull.Value);

            dyParam.Add(ChargeSpParams.PARAMETER_LOC_CHARG_TYPE, OracleDbType.Decimal, ParameterDirection.Input, (object)LockUpChargeType ?? DBNull.Value);
            dyParam.Add(ChargeSpParams.PARAMETER_LOB_CODE, OracleDbType.Decimal, ParameterDirection.Input, (object)LineOfBusinessCode ?? DBNull.Value);
            dyParam.Add(ChargeSpParams.PARAMETER_ST_TYPE, OracleDbType.Decimal, ParameterDirection.Input, (object)ChargeType ?? DBNull.Value);
            dyParam.Add(ChargeSpParams.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)Name ?? DBNull.Value);
            dyParam.Add(ChargeSpParams.PARAMETER_LANG_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)LangID ?? DBNull.Value);
            dyParam.Add(ChargeSpParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);

            return await QueryExecuter.ExecuteQueryAsync<Charge>(ChargeSPName.SP_LOAD_CHARGE, dyParam);
        }
    }
}
