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

namespace Domain.Operations.Organization.Cities
{
    public static class DBCitySetup
    {
        public async static Task<IDTO> AddUpdateMode(City city)
        {
            string SPName = "";
            string message = "";
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (city.ID.HasValue)
            {
                oracleParams.Add(CitySpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)city.ID ?? DBNull.Value);
                SPName = CitySPName.SP_UPADTE_CITY;
                message = "Updated Successfully";
            }
            else { 
                oracleParams.Add(CitySpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = CitySPName.SP_INSERT_CITY;
                message = "Inserted Successfully";
            }

            oracleParams.Add(CitySpParams.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)city.Name ?? DBNull.Value, 500);
            oracleParams.Add(CitySpParams.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)city.Name2 ?? DBNull.Value, 500);
            oracleParams.Add(CitySpParams.PARAMETER_COUNTRY_ID, OracleDbType.Int64, ParameterDirection.Input, (object)city.CountryID ?? DBNull.Value);
            oracleParams.Add(CitySpParams.PARAMETER_REFERNCE_NO, OracleDbType.Varchar2, ParameterDirection.Input, (object)city.ReferenceNo ?? DBNull.Value, 50);
            oracleParams.Add(CitySpParams.PARAMETER_LOC_STATUS, OracleDbType.Int64, ParameterDirection.Input, (object)city.Status ?? DBNull.Value);
            oracleParams.Add(CitySpParams.PARAMETER_STATUS_DATE, OracleDbType.Date, ParameterDirection.Input, (object)city.StatusDate ?? DBNull.Value);


            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)  
                complate.message = message;
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
