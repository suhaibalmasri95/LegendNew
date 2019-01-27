using Common.Interfaces;
using Common.Operations;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Financial.CustomerLicense
{
    public static class AddUpdateMode
    {
        public async static Task<IDTO> AddUpdate(Entities.Financial.CustomerLicense customerLicense)
        {
            string SPName = "";
            string message = "";
            ComplateOperation<int> complate = new ComplateOperation<int>();


            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            if (customerLicense.ID.HasValue)
            {
                oracleParams.Add(CustomerLicenseSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)customerLicense.ID ?? DBNull.Value);

                SPName = CustomerLicenseSpName.SP_UPADTE_CUSTOMER_LICENSE;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(CustomerLicenseSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = CustomerLicenseSpName.SP_INSERT_CUSTOMER_LICENSE;
                message = "Inserted Successfully";
            }
            oracleParams.Add(CustomerLicenseSpParams.PARAMETER_LICNESNO, OracleDbType.Varchar2, ParameterDirection.Input, (object)customerLicense.LicenseNo ?? DBNull.Value);
            oracleParams.Add(CustomerLicenseSpParams.PARAMETER_EFF_DATE, OracleDbType.Date, ParameterDirection.Input, (object)customerLicense.EffectiveDate ?? DBNull.Value);
            oracleParams.Add(CustomerLicenseSpParams.PARAMETER_EXP_DATE, OracleDbType.Date, ParameterDirection.Input, (object)customerLicense.ExpireDate ?? DBNull.Value);
            oracleParams.Add(CustomerLicenseSpParams.PARAMETER_CREATED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)customerLicense.CreatedBy ?? DBNull.Value);
            oracleParams.Add(CustomerLicenseSpParams.PARAMETER_CREATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)customerLicense.CreationDate ?? DBNull.Value);
            oracleParams.Add(CustomerLicenseSpParams.PARAMETER_MODIFIED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)customerLicense.ModifiedBy ?? DBNull.Value);
            oracleParams.Add(CustomerLicenseSpParams.PARAMETER_MODIFICATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)customerLicense.ModificationDate ?? DBNull.Value);
            oracleParams.Add(CustomerLicenseSpParams.PARAMETER_FIN_CST_ID, OracleDbType.Int64, ParameterDirection.Input, (object)customerLicense.CustomerID ?? DBNull.Value);
            oracleParams.Add(CustomerLicenseSpParams.PARAMETER_LOC_SPT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)customerLicense.LocSptID ?? DBNull.Value);
            oracleParams.Add(CustomerLicenseSpParams.PARAMETER_LOC_COD, OracleDbType.Int64, ParameterDirection.Input, (object)customerLicense.LocCode ?? DBNull.Value);
            oracleParams.Add(CustomerLicenseSpParams.PARAMETER_LOC_STATUS, OracleDbType.Int64, ParameterDirection.Input, (object)customerLicense.Status ?? DBNull.Value);
            oracleParams.Add(CustomerLicenseSpParams.PARAMETER_STATUS_DATE, OracleDbType.Int64, ParameterDirection.Input, (object)customerLicense.StatuseDate ?? DBNull.Value);
            oracleParams.Add(CustomerLicenseSpParams.PARAMETER_LOC_PROVIDER_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)customerLicense.LocProviderTyoe ?? DBNull.Value);
          


            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)
                complate.message = message;
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
