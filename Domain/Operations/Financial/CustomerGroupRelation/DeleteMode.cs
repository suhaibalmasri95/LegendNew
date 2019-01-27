using Common.Interfaces;
using Common.Operations;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Financial.CustomerGroupRelation
{
   public  static class DeleteMode
    {
        public async static Task<IDTO> DeleteGrRelation(Entities.Financial.CustomerGroupRelation customerGroupRelation)
        {
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();
            var dyParam = new OracleDynamicParameters();
            dyParam.Add(CustomerGrRelationSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)customerGroupRelation.ID ?? DBNull.Value);
            if (await NonQueryExecuter.ExecuteNonQueryAsync(CustomerGrRelationSpName.SP_DELETE_CUSTOMER_GROUP_RELATIONS, dyParam) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";
            return complate;
        }

        public async static Task<IDTO> DeleteGrRelations(long[] IDs)
        {

            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (await NonQueryExecuter.ExecuteNonQueryAsync(MultiDeleteFormater.Format(typeof(Entities.Financial.CustomerGroupRelation), IDs)) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
