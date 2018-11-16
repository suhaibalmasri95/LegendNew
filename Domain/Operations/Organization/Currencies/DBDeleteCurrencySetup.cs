using Common.Interfaces;
using Common.Operations;
using Domain.Entities.Organization;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Organization.Currencies
{
    public class DBDeleteCurrencySetup
    {
        public async static Task<IDTO> DeleteCurrencyAsync(Currency currency)
        {
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();
            var dyParam = new OracleDynamicParameters();
            dyParam.Add(CurrencySpParams.PARAMETER_CURRENCY_CODE, OracleDbType.Varchar2, ParameterDirection.Input, (object)currency.Code ?? DBNull.Value,30);

            if (await NonQueryExecuter.ExecuteNonQueryAsync(CurrencySPName.SP_DELETE_CURRENCY, dyParam) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";

            return complate;

        }

        public async static Task<IDTO> DeleteCurrenciesAsync(string[] Codes)
        {

            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (await NonQueryExecuter.ExecuteNonQueryAsync(MultiDeleteFormater.Format(typeof(Currency), Codes)) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
    }
