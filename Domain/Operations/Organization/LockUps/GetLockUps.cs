using Common.Interfaces;
using Domain.Organization.Entities;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Data;

using System.Threading.Tasks;

namespace Domain.Operations.Organization.LockUps
{
    public class GetLockUps : Lockup, IQueryable
    {
        public async Task<IEnumerable> Query()
        {
            var dyParam = new OracleDynamicParameters();

            dyParam.Add(LockUpSpParams.PARAMETER_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)ID ?? DBNull.Value);
            dyParam.Add(LockUpSpParams.PARAMETER_MAJOR_CODE, OracleDbType.Decimal, ParameterDirection.Input, (object)MajorCode ?? DBNull.Value);
            dyParam.Add(LockUpSpParams.PARAMETER_ST_MINOR_CODE, OracleDbType.Decimal, ParameterDirection.Input, (object)MinorCode ?? DBNull.Value);
            dyParam.Add(LockUpSpParams.PARAMETER_ST_LOCKUP_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)LockUpID ?? DBNull.Value);
            dyParam.Add(LockUpSpParams.PARAMETER_LANG_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)LangID ?? DBNull.Value);
            dyParam.Add(LockUpSpParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);
            return await QueryExecuter.ExecuteQueryAsync<Lockup>(LockUpSPName.SP_LOAD_LOCKUPS, dyParam);
        }
    }
}
