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

namespace Domain.Operations.Setup.Charges
{
   public static class DBChargeSetup
    {
        public async static Task<IDTO> AddUpdateMode(Charge charge)
        {
            string SPName = "";
            string message = "";
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (charge.ID.HasValue)
            {
                oracleParams.Add(ChargeSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)charge.ID ?? DBNull.Value);
                SPName = ChargeSPName.SP_UPADTE_CHARGE;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(ChargeSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = ChargeSPName.SP_INSERT_CHARGE;
                message = "Inserted Successfully";
            }
            oracleParams.Add(ChargeSpParams.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)charge.Name ?? DBNull.Value, 1000);
            oracleParams.Add(ChargeSpParams.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)charge.Name2 ?? DBNull.Value, 1000);
            oracleParams.Add(ChargeSpParams.PARAMETER_CREATED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)charge.CreatedBy ?? DBNull.Value, 100);
            oracleParams.Add(ChargeSpParams.PARAMETER_CREATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)charge.CreationDate ?? DBNull.Value);
            oracleParams.Add(ChargeSpParams.PARAMETER_MODIFIED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)charge.ModifiedBy ?? DBNull.Value, 100);
            oracleParams.Add(ChargeSpParams.PARAMETER_MODIFICATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)charge.ModificationDate ?? DBNull.Value);
            oracleParams.Add(ChargeSpParams.PARAMETER_LOC_CHARG_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)charge.LockUpChargeType ?? DBNull.Value);
            oracleParams.Add(ChargeSpParams.PARAMETER_ST_CHG_ID, OracleDbType.Int64, ParameterDirection.Input, (object)charge.ChargeID ?? DBNull.Value);
            oracleParams.Add(ChargeSpParams.PARAMETER_LOB_CODE, OracleDbType.Int64, ParameterDirection.Input, (object)charge.LineOfBusinessCode ?? DBNull.Value);
            oracleParams.Add(ChargeSpParams.PARAMETER_ST_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)charge.ChargeType ?? DBNull.Value);
            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)
                complate.message = message;
            else
                complate.message = "Operation Failed";

            return complate;
        }
    
}
}
