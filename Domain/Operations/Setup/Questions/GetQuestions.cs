using Common.Interfaces;
using Domain.Entities.Setup;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Setup.Questions
{
   public class GetQuestions : Question, IQueryable
    {
        public async Task<IEnumerable> QueryAsync()
        {
            var parameters = new OracleDynamicParameters();
            parameters.Add(QuestionSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ID ?? DBNull.Value);
            parameters.Add(QuestionSpParams.PARAMETER_QUS_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)this.QustionType ?? DBNull.Value);
            parameters.Add(QuestionSpParams.PARAMETER_ST_QUS_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.QuestionnaireID ?? DBNull.Value);
            parameters.Add(QuestionSpParams.PARAMETER_LANG_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.LangID ?? DBNull.Value);
            parameters.Add(QuestionSpParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);
            return await QueryExecuter.ExecuteQueryAsync<Question>(QuestionSpName.SP_LOAD_QUESTION, parameters);
        }
    }
}