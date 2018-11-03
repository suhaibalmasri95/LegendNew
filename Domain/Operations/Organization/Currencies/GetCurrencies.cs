using Common.Interfaces;
using Domain.Organization.Entities;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Organization.Currencies
{
    public class GetCurrencies : Currency, IQueryable
    {
        public async Task<IEnumerable> Query()
        {
            var dyParam = new OracleDynamicParameters();
            dyParam.Add(CurrencySpParams.PARAMETER_CURRENCY_CODE, OracleDbType.Int64, ParameterDirection.Input, (object)this.Code ?? DBNull.Value);
            dyParam.Add(CurrencySpParams.PARAMETER_LANG_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.LangID ?? DBNull.Value);
            dyParam.Add(CurrencySpParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);

            return await QueryExecuter.ExecuteQueryAsync<Currency>(CurrencySPName.SP_LOAD_CURRENCY, dyParam);
        }
    }
}
