using Common.Interfaces;
using Common.Operations;
using Domain.Entities.Organization;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Organization.UserGroups
{
   public static class DBDeleteUserGroupSetup
    {
        public async static Task<IDTO> DeleteUserGroupAsync(UserGroup userGroup)
        {
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();
            var dyParam = new OracleDynamicParameters();
            dyParam.Add(UserGroupSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)userGroup.ID ?? DBNull.Value);

            if (await NonQueryExecuter.ExecuteNonQueryAsync(UserGroupSpName.SP_DELETE_USER_GROUP, dyParam) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";

            return complate;

        }
    }
}
