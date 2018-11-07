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

namespace Domain.Operations.Organization.UserGroups
{
   public  class GetUserGroups : UserGroup, IQueryable
    {
        public async Task<IEnumerable> QueryAsync()
        {
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(UserGroupSpParams.PARAMETER_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)ID ?? DBNull.Value);
            dyParam.Add(UserGroupSpParams.PARAMETER_USER_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)UserID ?? DBNull.Value);
            dyParam.Add(UserGroupSpParams.PARAMETER_LANG_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)LangID ?? DBNull.Value);
            dyParam.Add(UserGroupSpParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);
            return await QueryExecuter.ExecuteQueryAsync<UserGroup>(UserGroupSpName.SP_LOAD_USER_GROUP, dyParam);
        }
        public async Task<List<UserGroup>> GetUserRelation()
        {
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(UserGroupSpParams.PARAMETER_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)ID ?? DBNull.Value);
            dyParam.Add(UserGroupSpParams.PARAMETER_USER_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)UserID ?? DBNull.Value);
            dyParam.Add(UserGroupSpParams.PARAMETER_LANG_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)LangID ?? DBNull.Value);
            dyParam.Add(UserGroupSpParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);
            return await QueryExecuter.ExecuteQueryAsync<UserGroup>(UserGroupSpName.SP_LOAD_USER_GROUP, dyParam);
        }
    }
}
