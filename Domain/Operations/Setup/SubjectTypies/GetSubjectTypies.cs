using Common.Interfaces;
using Domain.Entities.Setup;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Data;

using System.Threading.Tasks;

namespace Domain.Operations.Setup.SubjectTypies
{
    public class GetSubjectTypies : SubjectType, IQueryable
    {
        public async Task<IEnumerable> QueryAsync()
        {
            var parameters = new OracleDynamicParameters();
            parameters.Add(SubjectTypepParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ID ?? DBNull.Value);
            parameters.Add(SubjectTypepParams.PARAMETER_LINEOFBUSNIESS, OracleDbType.Int64, ParameterDirection.Input, (object)this.LineOfBusniessID ?? DBNull.Value);
            parameters.Add(SubjectTypepParams.PARAMETER_SUBLINEOFBUSNIESS, OracleDbType.Int64, ParameterDirection.Input, (object)this.SubLineOfBusniessID ?? DBNull.Value);
            parameters.Add(SubjectTypepParams.PARAMETER_LANG_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.LangID ?? DBNull.Value);
            parameters.Add(SubjectTypepParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);
            return await QueryExecuter.ExecuteQueryAsync<SubjectType>(SubjectTypeSPName.SP_LOAD_SubjectType, parameters);
        }
    }
}
