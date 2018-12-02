using Common.Interfaces;
using Common.Operations;
using Domain.Entities.Setup;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Setup.Diagnosises
{
    public static class DBDiagnosisSetup
    {
        public async static Task<IDTO> AddUpdateMode(Diagnosis subjectType)
        {
            var SPName = default(string);
            var message = default(string);
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (subjectType.ID.HasValue)
            {
                oracleParams.Add(DiagnosisParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)subjectType.ID ?? DBNull.Value);
                SPName = DiagnosisSPName.SP_INSERT_Diagnosis;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(DiagnosisParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = DiagnosisSPName.SP_UPADTE_Diagnosis;
                message = "Inserted Successfully";
            }

            oracleParams.Add(DiagnosisParams.PARAMETER_CODE, OracleDbType.Varchar2, ParameterDirection.Input, (object)subjectType.Code ?? DBNull.Value);
            oracleParams.Add(DiagnosisParams.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)subjectType.Name ?? DBNull.Value, 1000);
            oracleParams.Add(DiagnosisParams.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)subjectType.Name2 ?? DBNull.Value, 1000);
            oracleParams.Add(DiagnosisParams.PARAMETER_LOC_CODING_SYSTEM, OracleDbType.Int64, ParameterDirection.Input, (object)subjectType.CodeingSystem ?? DBNull.Value);
            oracleParams.Add(DiagnosisParams.PARAMETER_LOC_SERVICE_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)subjectType.ServiceType ?? DBNull.Value);
            oracleParams.Add(DiagnosisParams.PARAMETER_GENDER, OracleDbType.Int64, ParameterDirection.Input, (object)subjectType.Gender ?? DBNull.Value, 1000);
            oracleParams.Add(DiagnosisParams.PARAMETER_AGE_FROM, OracleDbType.Int64, ParameterDirection.Input, (object)subjectType.AgeFrom ?? DBNull.Value);
            oracleParams.Add(DiagnosisParams.PARAMETER_AGE_TO, OracleDbType.Int64, ParameterDirection.Input, (object)subjectType.AgeTo ?? DBNull.Value);
            oracleParams.Add(DiagnosisParams.PARAMETER_FREQUENCY, OracleDbType.Int64, ParameterDirection.Input, subjectType.Frequency, 500);
            oracleParams.Add(DiagnosisParams.PARAMETER_FREQUENCYUNIT, OracleDbType.Int64, ParameterDirection.Input, subjectType.FrequencyUnit, 500);
            oracleParams.Add(DiagnosisParams.PARAMETER_IS_ICD_SERV_BEN, OracleDbType.Int64, ParameterDirection.Input, subjectType.IS_ICD_SERV_BEN, 500);
            oracleParams.Add(DiagnosisParams.PARAMETER_IS_CHRONIC, OracleDbType.Int64, ParameterDirection.Input, subjectType.IsChronic, 500);
            oracleParams.Add(DiagnosisParams.PARAMETER_ST_ICD_SVC_ID, OracleDbType.Int64, ParameterDirection.Input, subjectType.Parent, 500);
            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)
                complate.message = message;
            else
                complate.message = "Operation Failed";
            return complate;
        }
    }
}
