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

namespace Domain.Operations.Organization.Areas
{
    public static class DBAreaSetup
    {
        public async static Task<IDTO> AddUpdateMode(Area area)
        {
            string SPName = "";
            string message = "";
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (area.ID.HasValue)
            {
                oracleParams.Add(AreaSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)area.ID ?? DBNull.Value);
                SPName = AreaSPName.SP_UPADTE_AREA;
                message = "Updated Successfully";
            }
            else { 
                oracleParams.Add(AreaSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = AreaSPName.SP_INSERT_AREA;
                message = "Inserted Successfully";
            }

            oracleParams.Add(AreaSpParams.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)area.Name ?? DBNull.Value, 500);
            oracleParams.Add(AreaSpParams.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)area.Name2 ?? DBNull.Value, 500);
            oracleParams.Add(AreaSpParams.PARAMETER_COUNTRY_ID, OracleDbType.Int64, ParameterDirection.Input, (object)area.CountryID ?? DBNull.Value);
            oracleParams.Add(AreaSpParams.PARAMETER_CITY_ID, OracleDbType.Int64, ParameterDirection.Input, (object)area.CityID ?? DBNull.Value);
            oracleParams.Add(AreaSpParams.PARAMETER_REFERNCE_NO, OracleDbType.Varchar2, ParameterDirection.Input, (object)area.ReferenceNo ?? DBNull.Value, 50);
            oracleParams.Add(AreaSpParams.PARAMETER_LOC_STATUS, OracleDbType.Int64, ParameterDirection.Input, (object)area.Status ?? DBNull.Value);
            oracleParams.Add(AreaSpParams.PARAMETER_STATUS_DATE, OracleDbType.Date, ParameterDirection.Input, (object)area.StatusDate ?? DBNull.Value);


            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)  
                complate.message = message;
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
