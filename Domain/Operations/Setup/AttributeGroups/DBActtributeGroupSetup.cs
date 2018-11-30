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
    public static class DBActtributeGroupSetup
    {
        public async static Task<IDTO> AddUpdateMode(AttributeGroup busnies)
        {
            string SPName = "";
            string message = "";
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (busnies.ID.HasValue)
            {
                oracleParams.Add(AttributesGroupSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)busnies.ID ?? DBNull.Value);
                SPName = AttributeGroupsPName.SP_UPADTE_AttributeGroup;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(AttributesGroupSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = AttributeGroupsPName.SP_INSERT_AttributeGroup;
                message = "Inserted Successfully";
            }
            oracleParams.Add(AttributesGroupSpParams.PARAMETER_ATTRIBUTE_GROUP, OracleDbType.Long, ParameterDirection.Input, (object)busnies.ATT_GRP_ID ?? DBNull.Value, 1000);
            oracleParams.Add(AttributesGroupSpParams.PARAMETER_SERVICE_ID, OracleDbType.Varchar2, ParameterDirection.Input, (object)busnies.SRVCS_ID ?? DBNull.Value, 1000);
            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)
                complate.message = message;
            else
                complate.message = "Operation Failed";

            return complate;
        }

    }
}
