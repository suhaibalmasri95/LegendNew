using Common.Interfaces;
using Domain.Organization.Entities;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Data;

using System.Threading.Tasks;

namespace Domain.Operations.Organization.Cities
{
    public class GetCities : City, IQueryable
    {
        public async Task<IEnumerable> Query()
        {
            var dyParam = new OracleDynamicParameters();
            dyParam.Add(CitySpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ID ?? DBNull.Value);
            dyParam.Add(CitySpParams.PARAMETER_COUNTRY_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.CountryID ?? DBNull.Value);
            dyParam.Add(CitySpParams.PARAMETER_LANG_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.LangID ?? DBNull.Value);
            dyParam.Add(CitySpParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);

            return await QueryExecuter.ExecuteQueryAsync<City>(CitySPName.SP_LOAD_CITY, dyParam);
        }
    }
}
