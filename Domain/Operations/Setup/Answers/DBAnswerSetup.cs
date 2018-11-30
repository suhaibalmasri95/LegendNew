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

namespace Domain.Operations.Setup.Answers
{
  public static class DBAnswerSetup
    {
        public async static Task<IDTO> AddUpdateMode(Answer answer)
        {
            string SPName = "";
            string message = "";
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (answer.ID.HasValue)
            {
                oracleParams.Add(AnswerSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)answer.ID ?? DBNull.Value);

                SPName = AnswerSpName.SP_UPADTE_ANSWER;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(AnswerSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = AnswerSpName.SP_INSERT_ANSWER;
                message = "Inserted Successfully";
            }
            oracleParams.Add(AnswerSpParams.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)answer.Name ?? DBNull.Value, 1000);
            oracleParams.Add(AnswerSpParams.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)answer.Name2 ?? DBNull.Value, 1000);
            oracleParams.Add(AnswerSpParams.PARAMETER_ANS_ORDER, OracleDbType.Int64, ParameterDirection.Input, (object)answer.AnswerOrder ?? DBNull.Value);
            oracleParams.Add(AnswerSpParams.PARAMETER_ST_QUS_ID, OracleDbType.Int64, ParameterDirection.Input, (object)answer.QuestionnaireID ?? DBNull.Value);

            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)
                complate.message = message;
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
