using Common.Interfaces;
using Domain.Entities.Setup;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Data;

using System.Threading.Tasks;

namespace Domain.Operations.Setup.Business
{
    public class GetBusniess : BusinessLine, IQueryable
    {
        public async Task<IEnumerable> QueryAsync()
        {
            var parameters = new OracleDynamicParameters();
            parameters.Add(BusinessSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ID ?? DBNull.Value);
            parameters.Add(BusinessSpParams.PARAMETER_CODE, OracleDbType.Int64, ParameterDirection.Input, (object)this.LineOfBusiness ?? DBNull.Value);
            parameters.Add(BusinessSpParams.PARAMETER_LOC_MODULE, OracleDbType.Int64, ParameterDirection.Input, (object)this.Module ?? DBNull.Value);
            parameters.Add(BusinessSpParams.PARAMETER_LANG_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.LangID ?? DBNull.Value);
            parameters.Add(BusinessSpParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);
            return await QueryExecuter.ExecuteQueryAsync<BusinessLine>(BusinessSPName.SP_LOAD_Busnies, parameters);
        }
    }
}
