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

namespace Domain.Operations.Setup.Questions
{
   public static class DBQuestionSetup
    {
        public async static Task<IDTO> AddUpdateMode(Question question)
        {
            string SPName = "";
            string message = "";
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (question.ID.HasValue)
            {
                oracleParams.Add(QuestionSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)question.ID ?? DBNull.Value);

                SPName = QuestionSpName.SP_UPADTE_QUESTION;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(QuestionSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = QuestionSpName.SP_INSERT_QUESTION;
                message = "Inserted Successfully";
            }
            oracleParams.Add(QuestionSpParams.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)question.Name ?? DBNull.Value, 1000);
            oracleParams.Add(QuestionSpParams.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)question.Name2 ?? DBNull.Value, 1000);
            oracleParams.Add(QuestionSpParams.PARAMETER_DESCRIPTION, OracleDbType.Varchar2, ParameterDirection.Input, (object)question.Description ?? DBNull.Value, 1000);
            oracleParams.Add(QuestionSpParams.PARAMETER_DESCRIPTION2, OracleDbType.Varchar2, ParameterDirection.Input, (object)question.Description2 ?? DBNull.Value, 1000);
            oracleParams.Add(QuestionSpParams.PARAMETER_QUS_ORDER, OracleDbType.Int64, ParameterDirection.Input, (object)question.QustionOrder ?? DBNull.Value);
            oracleParams.Add(QuestionSpParams.PARAMETER_QUS_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)question.QustionType ?? DBNull.Value);
            oracleParams.Add(QuestionSpParams.PARAMETER_STATUS, OracleDbType.Int64, ParameterDirection.Input, (object)question.Status ?? DBNull.Value);
            oracleParams.Add(QuestionSpParams.PARAMETER_STATUS_DATE, OracleDbType.Date, ParameterDirection.Input, (object)question.StatusDate ?? DBNull.Value);
            oracleParams.Add(QuestionSpParams.PARAMETER_ST_QUS_ID, OracleDbType.Int64, ParameterDirection.Input, (object)question.QuestionnaireID ?? DBNull.Value);
            oracleParams.Add(QuestionSpParams.PARAMETER_LOC_ST_LOCK_ID, OracleDbType.Int64, ParameterDirection.Input, (object)question.LockUpID ?? DBNull.Value);

            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)
                complate.message = message;
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
