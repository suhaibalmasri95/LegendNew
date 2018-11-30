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

namespace Domain.Operations.Setup.Questionnaires
{
  public static class DBQuestionnaireSetup
    {
        public async static Task<IDTO> AddUpdateMode(Questionnaire questionnaire)
        {
            string SPName = "";
            string message = "";
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (questionnaire.ID.HasValue)
            {
                oracleParams.Add(QuestionnaireSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)questionnaire.ID ?? DBNull.Value);

                SPName = QuestionnaireSpName.SP_UPADTE_QUESTIONNAIRE;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(QuestionnaireSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = QuestionnaireSpName.SP_INSERT_QUESTIONNAIRE;
                message = "Inserted Successfully";
            }
            oracleParams.Add(QuestionnaireSpParams.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)questionnaire.Name ?? DBNull.Value, 1000);
            oracleParams.Add(QuestionnaireSpParams.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)questionnaire.Name2 ?? DBNull.Value, 1000);
            oracleParams.Add(QuestionnaireSpParams.PARAMETER_STATUS, OracleDbType.Int64, ParameterDirection.Input, (object)questionnaire.Status ?? DBNull.Value);
            oracleParams.Add(QuestionnaireSpParams.PARAMETER_STATUS_DATE, OracleDbType.Date, ParameterDirection.Input, (object)questionnaire.StatusDate ?? DBNull.Value);
            oracleParams.Add(QuestionnaireSpParams.PARAMETER_QUS_LEVEL, OracleDbType.Int64, ParameterDirection.Input, (object)questionnaire.QustionnaireLevel ?? DBNull.Value);
            oracleParams.Add(QuestionnaireSpParams.PARAMETER_ST_LOB_ID, OracleDbType.Int64, ParameterDirection.Input, (object)questionnaire.LineOfBusiness ?? DBNull.Value);
            oracleParams.Add(QuestionnaireSpParams.PARAMETER_ST_SUB_LOB_ID, OracleDbType.Int64, ParameterDirection.Input, (object)questionnaire.SubLineOfBusiness ?? DBNull.Value);
            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)
                complate.message = message;
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
