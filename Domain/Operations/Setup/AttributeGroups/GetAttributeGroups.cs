using Common.Interfaces;
using Domain.Entities.Setup;
using Domain.Operations.Setup.AttributeGroupGroups;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Data;

using System.Threading.Tasks;

namespace Domain.Operations.Setup.AttributeGroups
{
    public class GetAttributeGroups : AttributeGroup, IQueryable
    {
        public async Task<IEnumerable> QueryAsync()
        {
            var parameters = new OracleDynamicParameters();
            parameters.Add(AttributesGroupSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ID ?? DBNull.Value);
            parameters.Add(AttributesGroupSpParams.PARAMETER_ATTRIBUTE_GROUP, OracleDbType.Int64, ParameterDirection.Input, (object)this.ATT_GRP_ID ?? DBNull.Value);
            parameters.Add(AttributesGroupSpParams.PARAMETER_SERVICE_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.SRVCS_ID ?? DBNull.Value);
            parameters.Add(AttributesGroupSpParams.PARAMETER_LANG_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.LangID ?? DBNull.Value);
            parameters.Add(AttributesGroupSpParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);
            return await QueryExecuter.ExecuteQueryAsync<AttributeGroup>(AttributeGroupsPName.SP_LOAD_AttributeGroup, parameters);
        }
    }
}
