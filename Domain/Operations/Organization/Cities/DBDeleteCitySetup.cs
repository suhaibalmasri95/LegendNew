using Common.Interfaces;
using Common.Operations;
using Domain.Entities.Organization;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Organization.Cities
{
    public class DBDeleteCitySetup
    {
        public async static Task<IDTO> DeleteCityAsync(City city)
        {
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();
            var dyParam = new OracleDynamicParameters();
            dyParam.Add(CitySpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)city.ID ?? DBNull.Value);

            if (await NonQueryExecuter.ExecuteNonQueryAsync(CitySPName.SP_DELETE_CITY, dyParam) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";

            return complate;

        }

        /*public async static Task<IDTO> DeleteCountriesAsync(List<Country> countries)
        {
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();
            var dyParam = new OracleDynamicParameters();
            dyParam.Add(CountrySpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)country.ID ?? DBNull.Value);

            if (await NonQueryExecuter.ExecuteNonQueryAsync(CountrySPName.SP_DELETE_COUNTRY, dyParam) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";

            return complate;

        }*/
    }
    }
