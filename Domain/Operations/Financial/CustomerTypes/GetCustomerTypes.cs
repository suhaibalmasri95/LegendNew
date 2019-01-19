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

namespace Domain.Operations.Financial.CustomerTypes
{
    public class GetCustomerTypes : CustomerType, IQueryable
    {
        public async Task<IEnumerable> QueryAsync()
        {
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(CustomerTypeSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)ID ?? DBNull.Value);
            dyParam.Add(CustomerTypeSpParams.PARAMETER_FIN_CST_ID, OracleDbType.Int64, ParameterDirection.Input, (object)CustomerID ?? DBNull.Value);
            dyParam.Add(CustomerTypeSpParams.PARAMETER_LOC_CUST_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)LocCustomerType ?? DBNull.Value);
            dyParam.Add(CustomerTypeSpParams.PARAMETER_FIN_GL_ID, OracleDbType.Int64, ParameterDirection.Input, (object)FinGlID ?? DBNull.Value);
            dyParam.Add(CustomerTypeSpParams.PARAMETER_LANG_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)LangID ?? DBNull.Value);
            dyParam.Add(CustomerTypeSpParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);

            return await QueryExecuter.ExecuteQueryAsync<CustomerType>(CustomerTypesSpName.SP_LOAD_CUSTOMER_TYPE, dyParam);
        }
    }
}
