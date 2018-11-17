using Common.Interfaces;
using Common.Operations;
using Domain.Entities.Setup;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Setup.SubBusiness
{
    public static class DBSubBusniesSetup
    {
        public async static Task<IDTO> AddUpdateMode(SubLineOfBusnies busnies)
        {
            string SPName = "";
            string message = "";
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (busnies.ID.HasValue)
            {
                oracleParams.Add(SubBusniesSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)busnies.ID ?? DBNull.Value);
   

                SPName = SubBusniesSPName.SP_UPADTE_SubBusnies;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(SubBusniesSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = SubBusniesSPName.SP_INSERT_SubBusnies;
                message = "Inserted Successfully";
            }
            oracleParams.Add(SubBusniesSpParams.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)busnies.Name ?? DBNull.Value, 500);
            oracleParams.Add(SubBusniesSpParams.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)busnies.Name2 ?? DBNull.Value, 500);
            oracleParams.Add(SubBusniesSpParams.PARAMETER_CODE, OracleDbType.Varchar2, ParameterDirection.Input, (object)busnies.Code ?? DBNull.Value,30);
            oracleParams.Add(SubBusniesSpParams.PARAMETER_CREATED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)busnies.CreatedBy,100);
            oracleParams.Add(SubBusniesSpParams.PARAMETER_CREATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)busnies.CreationDate);
            oracleParams.Add(SubBusniesSpParams.PARAMETER_MODIFIED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)busnies.ModifiedBy,100);
            oracleParams.Add(SubBusniesSpParams.PARAMETER_MODIFICATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)busnies.ModificationDate);
            oracleParams.Add(SubBusniesSpParams.PARAMETER_ST_LOB_ID, OracleDbType.Int64, ParameterDirection.Input, (object)busnies.LineOfBusniess ?? DBNull.Value);
            oracleParams.Add(SubBusniesSpParams.PARAMETER_SUB_LOB, OracleDbType.Int64, ParameterDirection.Input, (object)busnies.BasicLineOfBusniess ?? DBNull.Value);
            oracleParams.Add(SubBusniesSpParams.PARAMETER_RINS_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)busnies.ReinsType ?? DBNull.Value);
            oracleParams.Add(SubBusniesSpParams.PARAMETER_STATUS, OracleDbType.Int64, ParameterDirection.Input, (object)busnies.Status ?? DBNull.Value);
            oracleParams.Add(SubBusniesSpParams.PARAMETER_STATUS_DATE, OracleDbType.Date, ParameterDirection.Input, (object)busnies.StatusDate ?? DBNull.Value);
  
            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)
                complate.message = message;
            else
                complate.message = "Operation Failed";

            return complate;
        }

    }
}
