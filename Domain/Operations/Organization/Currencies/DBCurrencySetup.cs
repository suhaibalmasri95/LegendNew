using Common.Interfaces;
using Common.Operations;
using Domain.Organization.Entities;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Organization.Currencies
{
    public static class DBCurrencySetup
    {
        public async static Task<IDTO> AddMode(Currency currency)
        {
         
            OracleDynamicParameters dyParam = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            dyParam.Add(CurrencySpParams.PARAMETER_CURRENCY_CODE, OracleDbType.Varchar2, ParameterDirection.Input, (object)currency.Code ?? DBNull.Value, 30);
            dyParam.Add(CurrencySpParams.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)currency.Name ?? DBNull.Value, 500);
            dyParam.Add(CurrencySpParams.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)currency.Name2 ?? DBNull.Value, 500);
            dyParam.Add(CurrencySpParams.PARAMETER_DECIMAL_PLACES, OracleDbType.Int32, ParameterDirection.Input, (object)currency.DecimalPlaces ?? DBNull.Value, 5);
            dyParam.Add(CurrencySpParams.PARAMETER_SIGN, OracleDbType.Varchar2, ParameterDirection.Input, (object)currency.Sign ?? DBNull.Value, 200);
            dyParam.Add(CurrencySpParams.PARAMETER_STATUS, OracleDbType.Int64, ParameterDirection.Input, (object)currency.Status ?? DBNull.Value);
            dyParam.Add(CurrencySpParams.PARAMETER_STATUS_DATE, OracleDbType.Date, ParameterDirection.Input, (object)currency.StatusDate ?? DBNull.Value);
            dyParam.Add(CurrencySpParams.PARAMETER_FRACT, OracleDbType.Varchar2, ParameterDirection.Input, (object)currency.FractName ?? DBNull.Value, 500);
            dyParam.Add(CurrencySpParams.PARAMETER_FRACT2, OracleDbType.Varchar2, ParameterDirection.Input, (object)currency.FractName2 ?? DBNull.Value, 500);

            if (await NonQueryExecuter.ExecuteNonQueryAsync(CurrencySPName.SP_INSERT_CURRENCY, dyParam) == -1)  
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";

            return complate;
        }
        public async static Task<IDTO> UpdateMode(Currency currency)
        {

            OracleDynamicParameters dyParam = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            dyParam.Add(CurrencySpParams.PARAMETER_CURRENCY_CODE, OracleDbType.Varchar2, ParameterDirection.Input, (object)currency.Code ?? DBNull.Value, 30);
            dyParam.Add(CurrencySpParams.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)currency.Name ?? DBNull.Value, 500);
            dyParam.Add(CurrencySpParams.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)currency.Name2 ?? DBNull.Value, 500);
            dyParam.Add(CurrencySpParams.PARAMETER_DECIMAL_PLACES, OracleDbType.Int32, ParameterDirection.Input, (object)currency.DecimalPlaces ?? DBNull.Value, 5);
            dyParam.Add(CurrencySpParams.PARAMETER_SIGN, OracleDbType.Varchar2, ParameterDirection.Input, (object)currency.Sign ?? DBNull.Value, 200);
            dyParam.Add(CurrencySpParams.PARAMETER_STATUS, OracleDbType.Int64, ParameterDirection.Input, (object)currency.Status ?? DBNull.Value);
            dyParam.Add(CurrencySpParams.PARAMETER_STATUS_DATE, OracleDbType.Date, ParameterDirection.Input, (object)currency.StatusDate ?? DBNull.Value);
            dyParam.Add(CurrencySpParams.PARAMETER_FRACT, OracleDbType.Varchar2, ParameterDirection.Input, (object)currency.FractName ?? DBNull.Value, 500);
            dyParam.Add(CurrencySpParams.PARAMETER_FRACT2, OracleDbType.Varchar2, ParameterDirection.Input, (object)currency.FractName2 ?? DBNull.Value, 500);

            if (await NonQueryExecuter.ExecuteNonQueryAsync(CurrencySPName.SP_UPDATE_CURRENCY, dyParam) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";

            return complate;
        }

    }
}
