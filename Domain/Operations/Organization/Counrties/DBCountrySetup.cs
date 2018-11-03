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

namespace Domain.Operations.Organization.Counrties
{
    public static class DBCountrySetup
    {
        public async static Task<IDTO> AddUpdateMode(Country country)
        {
            string SPName = "";
            string message = "";
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (country.ID.HasValue)
            {
                oracleParams.Add(CountrySpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)country.ID ?? DBNull.Value);
                SPName = CountrySPName.SP_UPADTE_COUNTRY;
                message = "Updated Successfully";
            }
            else { 
                oracleParams.Add(CountrySpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = CountrySPName.SP_INSER_COUNTRY;
                message = "Inserted Successfully";
            }

            oracleParams.Add(CountrySpParams.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)country.Name ?? DBNull.Value, 500);
            oracleParams.Add(CountrySpParams.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)country.Name2 ?? DBNull.Value, 500);
            oracleParams.Add(CountrySpParams.PARAMETER_COUNTRY_NATIONALITY, OracleDbType.Varchar2, ParameterDirection.Input, (object)country.Nationality ?? DBNull.Value, 100);
            oracleParams.Add(CountrySpParams.PARAMETER_COUNTRY_CURRENCY_CODE, OracleDbType.Varchar2, ParameterDirection.Input, (object)country.CurrencyCode ?? DBNull.Value, 30);
            oracleParams.Add(CountrySpParams.PARAMETER_REFERNCE_NO, OracleDbType.Varchar2, ParameterDirection.Input, (object)country.ReferenceNo ?? DBNull.Value, 500);
            oracleParams.Add(CountrySpParams.PARAMETER_LOC_STATUS, OracleDbType.Int64, ParameterDirection.Input, (object)country.Status ?? DBNull.Value);
            oracleParams.Add(CountrySpParams.PARAMETER_STATUS_DATE, OracleDbType.Date, ParameterDirection.Input, (object)country.StatusDate ?? DBNull.Value);
            oracleParams.Add(CountrySpParams.PARAMETER_PHONE_CODE, OracleDbType.Varchar2, ParameterDirection.Input, (object)country.PhoneCode ?? DBNull.Value, 50);
            oracleParams.Add(CountrySpParams.PARAMETER_COUNTRY_FLAG, OracleDbType.Varchar2, ParameterDirection.Input, (object)country.Flag ?? DBNull.Value, 500);

            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)  
                complate.message = message;
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
