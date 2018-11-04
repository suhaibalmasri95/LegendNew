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

namespace Domain.Operations.Organization.Business
{
    public static class DBBusniesSetup
    {
        public async static Task<IDTO> AddUpdateMode(BusinesLine busnies)
        {
            string SPName = "";
            string message = "";
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (busnies.ID.HasValue)
            {
                oracleParams.Add(BusniesSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)busnies.ID ?? DBNull.Value);
                oracleParams.Add(BusniesSpParams.PARAMETER_STATUS_DATE, OracleDbType.Varchar2, ParameterDirection.Input, DateTime.Now, 500);
                SPName = BusniesSPName.SP_UPADTE_Busnies;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(BusniesSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = BusniesSPName.SP_INSERT_Busnies;
                message = "Inserted Successfully";
            }

            oracleParams.Add(BusniesSpParams.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)busnies.Name ?? DBNull.Value, 500);
            oracleParams.Add(BusniesSpParams.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)busnies.Name2 ?? DBNull.Value, 500);
            oracleParams.Add(BusniesSpParams.PARAMETER_CODE, OracleDbType.Int64, ParameterDirection.Input, (object)busnies.Code ?? DBNull.Value);
            oracleParams.Add(BusniesSpParams.PARAMETER_CREATED_BY, OracleDbType.Int64, ParameterDirection.Input, "Admin");
            oracleParams.Add(BusniesSpParams.PARAMETER_CREATION_DATE, OracleDbType.Int64, ParameterDirection.Input, DateTime.Now);
            oracleParams.Add(BusniesSpParams.PARAMETER_STATUS, OracleDbType.Varchar2, ParameterDirection.Input, (object)busnies.Stastus ?? DBNull.Value, 50);
            oracleParams.Add(BusniesSpParams.PARAMETER_LOC_MODULE, OracleDbType.Int64, ParameterDirection.Input, (object)busnies.LineOfBusiness ?? DBNull.Value);
            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)
                complate.message = message;
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
