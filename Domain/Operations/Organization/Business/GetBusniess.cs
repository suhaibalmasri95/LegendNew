using Common.Interfaces;
using Domain.Entities.Organization;
using Domain.Entities.Organization;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Data;

using System.Threading.Tasks;

namespace Domain.Operations.Organization.Business
{
    public class GetBusniess : BusinesLine, IQueryable
    {
        public async Task<IEnumerable> QueryAsync()
        {
            var parameters = new OracleDynamicParameters();
            parameters.Add(BusniesSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ID ?? DBNull.Value);
            parameters.Add(BusniesSpParams.PARAMETER_CODE, OracleDbType.Int64, ParameterDirection.Input, (object)this.LineOfBusiness ?? DBNull.Value);
            parameters.Add(BusniesSpParams.PARAMETER_LOC_MODULE, OracleDbType.Int64, ParameterDirection.Input, (object)this.Module ?? DBNull.Value);
            parameters.Add(BusniesSpParams.PARAMETER_LANG_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.LangID ?? DBNull.Value);
            parameters.Add(BusniesSpParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);
            return await QueryExecuter.ExecuteQueryAsync<BusinesLine>(BusniesSPName.SP_LOAD_Busnies, parameters);
        }
    }
}
