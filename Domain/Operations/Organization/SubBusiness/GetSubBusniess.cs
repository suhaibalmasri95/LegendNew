using Common.Interfaces;
using Domain.Entities.Organization;

using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Data;

using System.Threading.Tasks;

namespace Domain.Operations.Organization.SubBusiness
{
    public class GetSubBusniess : SubLineOfBusnies, IQueryable
    {
        public async Task<IEnumerable> QueryAsync()
        {
            var parameters = new OracleDynamicParameters();
            parameters.Add(SubBusniesSpParams.PARAMETER_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)ID ?? DBNull.Value);
            parameters.Add(SubBusniesSpParams.PARAMETER_SUB_LOB, OracleDbType.Varchar2, ParameterDirection.Input, (object)BasicLineOfBusniess ?? DBNull.Value, 500);
            parameters.Add(SubBusniesSpParams.PARAMETER_ST_LOB_ID, OracleDbType.Varchar2, ParameterDirection.Input, (object)LineOfBusniess ?? DBNull.Value, 500);
            parameters.Add(SubBusniesSpParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);
            parameters.Add(SubBusniesSpParams.PARAMETER_LANG_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)LangID ?? DBNull.Value);
            return await QueryExecuter.ExecuteQueryAsync<SubLineOfBusnies>(SubBusniesSPName.SP_LOAD_SubBusnies, parameters);
        }
    }
}
