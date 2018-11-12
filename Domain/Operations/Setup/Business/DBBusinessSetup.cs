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

namespace Domain.Operations.Setup.Business
{
    public static class DBBusinessSetup
    {
        public async static Task<IDTO> AddUpdateMode(BusinessLine busnies)
        {
            string SPName = "";
            string message = "";
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (busnies.ID.HasValue)
            {
                oracleParams.Add(BusinessSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)busnies.ID ?? DBNull.Value);
     
                SPName = BusinessSPName.SP_UPADTE_Busnies;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(BusinessSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = BusinessSPName.SP_INSERT_Busnies;
                message = "Inserted Successfully";
            }
            oracleParams.Add(BusinessSpParams.PARAMETER_CODE, OracleDbType.Varchar2, ParameterDirection.Input, (object)busnies.Code ?? DBNull.Value,30);
            oracleParams.Add(BusinessSpParams.PARAMETER_LOB_CODE, OracleDbType.Int64, ParameterDirection.Input, (object)busnies.LineOfBusiness ?? DBNull.Value);
            oracleParams.Add(BusinessSpParams.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)busnies.Name ?? DBNull.Value, 1000);
            oracleParams.Add(BusinessSpParams.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)busnies.Name2 ?? DBNull.Value, 1000);
   
            oracleParams.Add(BusinessSpParams.PARAMETER_CREATED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)busnies.CreatedBy ?? DBNull.Value , 30);
            oracleParams.Add(BusinessSpParams.PARAMETER_CREATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)busnies.CreationDate ?? DBNull.Value);
            oracleParams.Add(BusinessSpParams.PARAMETER_MODIFIED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)busnies.ModifiedBy ?? DBNull.Value, 30);
            oracleParams.Add(BusinessSpParams.PARAMETER_MODIFICATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)busnies.ModificationDate ?? DBNull.Value);
            oracleParams.Add(BusinessSpParams.PARAMETER_STATUS, OracleDbType.Int64, ParameterDirection.Input, (object)busnies.Status ?? DBNull.Value);
            oracleParams.Add(BusinessSpParams.PARAMETER_STATUS_DATE, OracleDbType.Date, ParameterDirection.Input, (object)busnies.StatusDate ?? DBNull.Value);
            oracleParams.Add(BusinessSpParams.PARAMETER_LOC_MODULE, OracleDbType.Int64, ParameterDirection.Input, (object)busnies.Module ?? DBNull.Value);
            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)
                complate.message = message;
            else
                complate.message = "Operation Failed";

            return complate;
        }

    }
}
