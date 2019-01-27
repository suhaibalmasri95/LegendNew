using Common.Interfaces;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Financial.CustomerLicense
{
    public class GetCustomerLicense : Entities.Financial.CustomerLicense, IQueryable
    {
        public async Task<IEnumerable> QueryAsync()
        {
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(CustomerLicenseSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)ID ?? DBNull.Value);
            dyParam.Add(CustomerLicenseSpParams.PARAMETER_LICNESNO, OracleDbType.Varchar2, ParameterDirection.Input, (object)LicenseNo ?? DBNull.Value);
            dyParam.Add(CustomerLicenseSpParams.PARAMETER_FIN_CST_ID, OracleDbType.Int64, ParameterDirection.Input, (object)CustomerID ?? DBNull.Value);
            dyParam.Add(CustomerLicenseSpParams.PARAMETER_LOC_SPT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)LocSptID ?? DBNull.Value);
            dyParam.Add(CustomerLicenseSpParams.PARAMETER_LOC_COD, OracleDbType.Int64, ParameterDirection.Input, (object)LocCode ?? DBNull.Value);
            dyParam.Add(CustomerLicenseSpParams.PARAMETER_LOC_PROVIDER_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)LocProviderTyoe ?? DBNull.Value);
            dyParam.Add(CustomerLicenseSpParams.PARAMETER_LANG_ID, OracleDbType.Int64, ParameterDirection.Input, (object)LangID ?? DBNull.Value);
            dyParam.Add(CustomerLicenseSpParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);

            return await QueryExecuter.ExecuteQueryAsync<Entities.Financial.CustomerLicense>(CustomerLicenseSpName.SP_LOAD_CUSTOMER_LICENSE, dyParam);
        }
    }

}
