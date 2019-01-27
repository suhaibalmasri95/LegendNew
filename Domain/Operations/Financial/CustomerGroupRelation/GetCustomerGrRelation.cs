using Common.Interfaces;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Operations.Financial.CustomerGroupRelation
{
   public class GetCustomerGrRelation : Entities.Financial.CustomerGroupRelation, IQueryable
    {
        public async Task<IEnumerable> QueryAsync()
        {
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(CustomerGrRelationSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)ID ?? DBNull.Value);
            dyParam.Add(CustomerGrRelationSpParams.PARAMETER_ST_PARTD_ID, OracleDbType.Int64, ParameterDirection.Input, (object)ProductDetailId ?? DBNull.Value);
            dyParam.Add(CustomerGrRelationSpParams.PARAMETER_FIN_CST_ID, OracleDbType.Int64, ParameterDirection.Input, (object)CustomerID ?? DBNull.Value);
            dyParam.Add(CustomerGrRelationSpParams.PARAMETER_LANG_ID, OracleDbType.Int64, ParameterDirection.Input, (object)LangID ?? DBNull.Value);
            dyParam.Add(CustomerGrRelationSpParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);

            return await QueryExecuter.ExecuteQueryAsync<Entities.Financial.CustomerGroupRelation>(CustomerGrRelationSpName.SP_LOAD_CUSTOMER_GROUP_RELATIONS, dyParam);
        }
    }
}
