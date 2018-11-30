using Common.Interfaces;
using Common.Operations;
using Domain.Entities.Setup;
using Domain.Operations.Setup.AttributeGroupGroups;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Setup.AttributeGroups
{
    public static class DBDeleteAttributeGroupsSetup
    {
        public async static Task<IDTO> DeleteAttributeAsync(AttributeGroup Attribute)
        {
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();
            var dyParam = new OracleDynamicParameters();
            dyParam.Add(AttributesGroupSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)Attribute.ID ?? DBNull.Value);
            if (await NonQueryExecuter.ExecuteNonQueryAsync(AttributeGroupsPName.SP_DELETE_AttributeGroup, dyParam) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";
            return complate;
        }

        public async static Task<IDTO> DeleteAttributesAsync(long[] IDs)
        {
            ComplateOperation<int> operation = new ComplateOperation<int>();
            if (await NonQueryExecuter.ExecuteNonQueryAsync(MultiDeleteFormater.Format(typeof(AttributeGroup), IDs)) == -1)
                operation.message = "Operation Successed";
            else
                operation.message = "Operation Failed";
            return operation;
        }
    }
}

