using Common.Interfaces;
using Domain.Entities.Financial;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Financial.Customers
{
   public class GetCustomers : Customer, IQueryable
    {
        public async Task<IEnumerable> QueryAsync()
        {
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(CustomerSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)ID ?? DBNull.Value);
            dyParam.Add(CustomerSpParams.PARAMETER_CUSTOMER_NO, OracleDbType.Varchar2, ParameterDirection.Input, (object)CustomerNo ?? DBNull.Value);
            dyParam.Add(CustomerSpParams.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)Name ?? DBNull.Value);
            dyParam.Add(CustomerSpParams.PARAMETER_IND_COMP, OracleDbType.Int64, ParameterDirection.Input, (object)IndOrComp ?? DBNull.Value);
            dyParam.Add(CustomerSpParams.PARAMETER_COMM_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)CommName ?? DBNull.Value);
            dyParam.Add(CustomerSpParams.PARAMETER_PHONE, OracleDbType.Varchar2, ParameterDirection.Input, (object)Phone ?? DBNull.Value);
            dyParam.Add(CustomerSpParams.PARAMETER_MOBILE, OracleDbType.Varchar2, ParameterDirection.Input, (object)Mobile ?? DBNull.Value);
            dyParam.Add(CustomerSpParams.PARAMETER_EMAIL, OracleDbType.Varchar2, ParameterDirection.Input, (object)Email ?? DBNull.Value);
            dyParam.Add(CustomerSpParams.PARAMETER_ST_COM_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)CompanyID ?? DBNull.Value);
            dyParam.Add(CustomerSpParams.PARAMETER_LOC_CUST_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)CustomerType ?? DBNull.Value);
            dyParam.Add(CustomerSpParams.PARAMETER_LANG_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)LangID ?? DBNull.Value);
            dyParam.Add(CustomerSpParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);

            return await QueryExecuter.ExecuteQueryAsync<Customer>(CustomerSpName.SP_LOAD_CUSTOMER, dyParam);
        }
    }
}
