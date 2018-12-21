using Common.Auth;
using Common.Interfaces;
using Domain.Entities.Authentication;
using Domain.Entities.Organization;
using Domain.Operations.Organization.UserGroups;

using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Organization.Users
{
    public class GetUsers : User, IQueryable
    {
        public async Task<IEnumerable> QueryAsync()
        {
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(UserSpParams.PARAMETER_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)ID ?? DBNull.Value);
            dyParam.Add(UserSpParams.PARAMETER_LANG_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)LangID ?? DBNull.Value);
            dyParam.Add(UserSpParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);
           List<User> users= await QueryExecuter.ExecuteQueryAsync<User>(UserSpName.SP_LOAD_USER, dyParam);
            foreach (var item in users)
            {
                GetUserGroups userGroup = new GetUserGroups();
                    userGroup.UserID = item.ID;
                item.UserRelations = await userGroup.GetUserRelation();
            }
            return users;
        }
        public async Task<IEnumerable> Login(Auth auth)
        {
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(UserSpParams.PARAMETER_USERNAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)auth.UserName ?? DBNull.Value,30);
            dyParam.Add(UserSpParams.PARAMETER_PASSWORD, OracleDbType.Varchar2, ParameterDirection.Input, (object)Encryption.EncryptPassword(auth.Password) ?? DBNull.Value,1000);
            dyParam.Add(UserSpParams.PARAMETER_LANG_ID, OracleDbType.Int64, ParameterDirection.Input, (object) auth.langId ?? DBNull.Value);
            dyParam.Add(UserSpParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);
            List<User> users = await QueryExecuter.ExecuteQueryAsync<User>(UserSpName.SP_LOGIN_USER, dyParam);
           
            return users;
        }
    }
}
