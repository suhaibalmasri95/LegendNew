using Common.Interfaces;
using Domain.Entities.Organization;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Organization.GroupRelations
{
   public class GetGroupRelation : GroupRelation, IQueryable
    {
        public async Task<IEnumerable> QueryAsync()
        {
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(GroupRelationSpParams.PARAMETER_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)ID ?? DBNull.Value);
            dyParam.Add(GroupRelationSpParams.PARAMETER_ST_GRP_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)GroupID ?? DBNull.Value);
            dyParam.Add(GroupRelationSpParams.PARAMETER_LANG_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)LangID ?? DBNull.Value);
            dyParam.Add(GroupRelationSpParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);
            return await QueryExecuter.ExecuteQueryAsync<GroupRelation>(GroupRelationSpName.SP_LOAD_GROUP_RELATION, dyParam);
        }
    }
}
