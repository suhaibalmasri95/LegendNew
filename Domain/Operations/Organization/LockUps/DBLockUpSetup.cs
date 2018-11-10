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

namespace Domain.Operations.Organization.LockUps
{
    public static class DBLockUpSetup
    {
        public async static Task<IDTO> AddUpdateMode(Lockup lockup)
        {
            string SPName = "";
            string message = "";
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (lockup.ID.HasValue)
            {
                oracleParams.Add(LockUpSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)lockup.ID ?? DBNull.Value);
                SPName = LockUpSPName.SP_UPDATE_LOCKUPS;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(LockUpSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = LockUpSPName.SP_INSERT_LOCKUPS;
                message = "Inserted Successfully";
            }
            oracleParams.Add(LockUpSpParams.PARAMETER_MAJOR_CODE, OracleDbType.Int64, ParameterDirection.Input, (object)lockup.MajorCode ?? DBNull.Value);
            oracleParams.Add(LockUpSpParams.PARAMETER_ST_MINOR_CODE, OracleDbType.Int64, ParameterDirection.Input, (object)lockup.MinorCode ?? DBNull.Value);
            oracleParams.Add(LockUpSpParams.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)lockup.Name ?? DBNull.Value, 500);
            oracleParams.Add(LockUpSpParams.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)lockup.Name2 ?? DBNull.Value, 500);
            oracleParams.Add(LockUpSpParams.PARAMETER_CREATED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)lockup.CreatedBy ?? DBNull.Value, 500);
            oracleParams.Add(LockUpSpParams.PARAMETER_CREATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)lockup.CreationDate ?? DBNull.Value);
            oracleParams.Add(LockUpSpParams.PARAMETER_MODIFIED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)lockup.ModifiedBy ?? DBNull.Value, 500);
            oracleParams.Add(LockUpSpParams.PARAMETER_MODIFICATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)lockup.ModificationDate ?? DBNull.Value);
            oracleParams.Add(LockUpSpParams.PARAMETER_ST_LOCKUP_ID, OracleDbType.Int64, ParameterDirection.Input, (object)lockup.LockUpID ?? DBNull.Value);
            oracleParams.Add(LockUpSpParams.PARAMETER_LOCKUP_TYPE, OracleDbType.Int32, ParameterDirection.Input, (object)lockup.LockUpType ?? DBNull.Value);
            oracleParams.Add(LockUpSpParams.PARAMETER_REF_NO, OracleDbType.Varchar2, ParameterDirection.Input, (object)lockup.ReferenceNo ?? DBNull.Value, 100);
            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)  
                complate.message = message;
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
