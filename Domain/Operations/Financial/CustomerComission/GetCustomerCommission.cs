using Common.Interfaces;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Financial.CustomerComission
{
   public class GetCustomerCommission : Entities.Financial.CustomerCommission, IQueryable
    {
        public async Task<IEnumerable> QueryAsync()
        {
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(CustomerCommissionSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)ID ?? DBNull.Value);
            dyParam.Add(CustomerCommissionSpParams.PARAMETER_FIN_CST_ID, OracleDbType.Int64, ParameterDirection.Input, (object)CustomerID ?? DBNull.Value);
            dyParam.Add(CustomerCommissionSpParams.PARAMETER_LOC_CUST_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)LocCustomerType ?? DBNull.Value);
            dyParam.Add(CustomerCommissionSpParams.PARAMETER_ST_PRD_ID, OracleDbType.Int64, ParameterDirection.Input, (object)ProductId ?? DBNull.Value);
            dyParam.Add(CustomerCommissionSpParams.PARAMETER_ST_PARTD_ID, OracleDbType.Int64, ParameterDirection.Input, (object)ProductDetailId ?? DBNull.Value);
            dyParam.Add(CustomerCommissionSpParams.PARAMETER_LANG_ID, OracleDbType.Int64, ParameterDirection.Input, (object)LangID ?? DBNull.Value);
            dyParam.Add(CustomerCommissionSpParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);

            return await QueryExecuter.ExecuteQueryAsync<Entities.Financial.CustomerCommission>(CustomerCommissionSpName.SP_LOAD_CUSTOMER_COMM, dyParam);
        }
    }
}
