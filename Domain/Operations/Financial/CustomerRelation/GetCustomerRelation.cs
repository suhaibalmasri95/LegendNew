using Common.Interfaces;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Operations.Financial.CustomerRelation
{
   public class GetCustomerRelation : Entities.Financial.CustomerRelation, IQueryable
    {
        public async Task<IEnumerable> QueryAsync()
        {
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(CustomerRelationSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)ID ?? DBNull.Value);
            dyParam.Add(CustomerRelationSpParams.PARAMETER_FIN_CST_ID, OracleDbType.Int64, ParameterDirection.Input, (object)CustomerID ?? DBNull.Value);
            dyParam.Add(CustomerRelationSpParams.PARAMETER_FIN_CST_ID2, OracleDbType.Int64, ParameterDirection.Input, (object)CustomerID2 ?? DBNull.Value);
            dyParam.Add(CustomerRelationSpParams.PARAMETER_LOC_REL_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)LocRelationType ?? DBNull.Value);

            dyParam.Add(CustomerRelationSpParams.PARAMETER_LANG_ID, OracleDbType.Int64, ParameterDirection.Input, (object)LangID ?? DBNull.Value);
            dyParam.Add(CustomerRelationSpParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);

            return await QueryExecuter.ExecuteQueryAsync<Entities.Financial.CustomerRelation>(CustomerRelationSpName.SP_LOAD_CUSTOMER_RELATIONS, dyParam);
        }
    }
}
