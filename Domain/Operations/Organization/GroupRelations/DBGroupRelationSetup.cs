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

namespace Domain.Operations.Organization.GroupRelations
{
    public class DBGroupRelationSetup
    {

        public async static Task<IDTO> AddUpdateMode(GroupRelation groupRelation)
        {
            string SPName = "";
            string message = "";
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (groupRelation.ID.HasValue)
            {
                oracleParams.Add(GroupRelationSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)groupRelation.ID ?? DBNull.Value);
                SPName = GroupRelationSpName.SP_UPADTE_GROUP_RELATION;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(GroupRelationSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = GroupRelationSpName.SP_INSERT_GROUP_RELATION;
                message = "Inserted Successfully";
            }
            oracleParams.Add(GroupRelationSpParams.PARAMETER_ST_GRP_ID, OracleDbType.Int64, ParameterDirection.Input, (object)groupRelation.GroupID ?? DBNull.Value);
            oracleParams.Add(GroupRelationSpParams.PARAMETER_GRPNAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)groupRelation.GroupName ?? DBNull.Value, 1000);
            oracleParams.Add(GroupRelationSpParams.PARAMETER_LOCK_GRP_CAT, OracleDbType.Int64, ParameterDirection.Input, (object)groupRelation.LockUpGroupCat ?? DBNull.Value);
            oracleParams.Add(GroupRelationSpParams.PARAMETER_REF_ID, OracleDbType.Date, ParameterDirection.Input, (object)groupRelation.RefrenceID ?? DBNull.Value);
 
            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)
                complate.message = message;
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
