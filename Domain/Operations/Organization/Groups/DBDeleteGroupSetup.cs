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

namespace Domain.Operations.Organization.Groups
{
   public static class DBDeleteGroupSetup
    {
        public async static Task<IDTO> DeleteGroupAsync(Group group)
        {
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();
            var dyParam = new OracleDynamicParameters();
            dyParam.Add(GroupSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)group.ID ?? DBNull.Value);

            if (await NonQueryExecuter.ExecuteNonQueryAsync(GroupSpName.SP_DELETE_GROUP, dyParam) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";

            return complate;

        }

    }
}
