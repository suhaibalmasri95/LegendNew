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
    public static class DBDeleteDiagnosisSetup
    {
        public async static Task<IDTO> DeleteDiagnosisAsync(Diagnosis diagnosis)
        {
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();
            var dyParam = new OracleDynamicParameters();
            dyParam.Add(DiagnosisParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)diagnosis.ID ?? DBNull.Value);
            if (await NonQueryExecuter.ExecuteNonQueryAsync(DiagnosisSPName.SP_DELETE_Diagnosis, dyParam) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";
            return complate;
        }

        public async static Task<IDTO> DeleteDiagnosisAsync(long[] IDs)
        {
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (await NonQueryExecuter.ExecuteNonQueryAsync(MultiDeleteFormater.Format(typeof(Diagnosis), IDs)) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
