using Common.Interfaces;
using Common.Operations;
using Domain.Entities.Organization;
using Domain.Organization.Entities;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Organization.UserGroups
{
    public static class DBUserGroupSetup
    {
        public async static Task<IDTO> AddUpdateMode(UserGroup userGroup)
        {
            string SPName = "";
            string message = "";
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (userGroup.ID.HasValue)
            {
                oracleParams.Add(UserGroupSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)userGroup.ID ?? DBNull.Value);
                SPName = UserGroupSpName.SP_UPADTE_USER_GROUP;
                message = "Updated Successfully";
           
            }
            else { 
                oracleParams.Add(UserGroupSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = UserGroupSpName.SP_INSER_USER_GROUP;
                message = "Inserted Successfully";
              
            }
            oracleParams.Add(UserGroupSpParams.PARAMETER_USER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)userGroup.UserID ?? DBNull.Value);
            oracleParams.Add(UserGroupSpParams.PARAMETER_USERNAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)userGroup.UserName ?? DBNull.Value, 30);
            oracleParams.Add(UserGroupSpParams.PARAMETER_LOCK_USER_CAT, OracleDbType.Int64, ParameterDirection.Input, (object)userGroup.UserRelationID ?? DBNull.Value, 500);
            oracleParams.Add(UserGroupSpParams.PARAMETER_REF_ID, OracleDbType.Int64, ParameterDirection.Input, (object)userGroup.RefrenceID ?? DBNull.Value, 500);

            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)
                complate.message = message;
             else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
