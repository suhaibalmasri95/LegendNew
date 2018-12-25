using Common.Interfaces;
using Domain.Entities.Setup;

using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Data;

using System.Threading.Tasks;

namespace Domain.Operations.Setup.SubBusiness
{
    public class GetSubBusniess : SubLineOfBusnies, IQueryable
    {
        public async Task<IEnumerable> QueryAsync()
        {
            
               var parameters = new OracleDynamicParameters();
            parameters.Add(SubBusniesSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)ID ?? DBNull.Value);
            parameters.Add(SubBusniesSpParams.PARAMETER_ST_LOB_ID, OracleDbType.Int64, ParameterDirection.Input, (object)LineOfBusniess ?? DBNull.Value);
            parameters.Add(SubBusniesSpParams.PARAMETER_SUB_LOB, OracleDbType.Int64, ParameterDirection.Input, (object)BasicLineOfBusniess ?? DBNull.Value);
            parameters.Add(SubBusniesSpParams.PARAMETER_LANG_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)LangID ?? DBNull.Value);
            parameters.Add(SubBusniesSpParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);

            return await QueryExecuter.ExecuteQueryAsync<SubLineOfBusnies>(SubBusniesSPName.SP_LOAD_SubBusnies, parameters);
        }
    }
}
