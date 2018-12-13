using Common.Interfaces;
using Domain.Entities.Setup;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Data;

using System.Threading.Tasks;

namespace Domain.Operations.Setup.Diagnosises
{
    public class GetDiagnosises : Diagnosis, IQueryable
    {
        public async Task<IEnumerable> QueryAsync()
        {
            var parameters = new OracleDynamicParameters();
            parameters.Add(DiagnosisParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ID ?? DBNull.Value);
            parameters.Add(DiagnosisParams.PARAMETER_LOC_CODING_SYSTEM, OracleDbType.Int64, ParameterDirection.Input, (object)this.CodingSystem ?? DBNull.Value);
            parameters.Add(DiagnosisParams.PARAMETER_LOC_SERVICE_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)this.ServiceType ?? DBNull.Value);
            parameters.Add(DiagnosisParams.PARAMETER_IS_ICD_SERV_BEN, OracleDbType.Int64, ParameterDirection.Input, (object)this.IS_ICD_SERV_BEN ?? DBNull.Value);
            parameters.Add(DiagnosisParams.PARAMETER_ST_ICD_SVC_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.Parent ?? DBNull.Value);
            parameters.Add(DiagnosisParams.PARAMETER_LANG_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.LangID ?? DBNull.Value);
            parameters.Add(DiagnosisParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);
            return await QueryExecuter.ExecuteQueryAsync<Diagnosis>(DiagnosisSPName.SP_LOAD_Diagnosis, parameters);
        }
    }
}
