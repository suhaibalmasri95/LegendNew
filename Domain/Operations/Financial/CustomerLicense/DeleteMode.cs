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
    public static class DeleteMode
    {
        public async static Task<IDTO> DeleteCustomerLicene(Entities.Financial.CustomerLicense customerLicense)
        {
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();
            var dyParam = new OracleDynamicParameters();
            dyParam.Add(CustomerLicenseSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)customerLicense.ID ?? DBNull.Value);
            if (await NonQueryExecuter.ExecuteNonQueryAsync(CustomerLicenseSpName.SP_DELETE_CUSTOMER_LICENSE, dyParam) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";
            return complate;
        }

        public async static Task<IDTO> DeleteCustomerLicenes(long[] IDs)
        {

            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (await NonQueryExecuter.ExecuteNonQueryAsync(MultiDeleteFormater.Format(typeof(Entities.Financial.CustomerLicense), IDs)) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
