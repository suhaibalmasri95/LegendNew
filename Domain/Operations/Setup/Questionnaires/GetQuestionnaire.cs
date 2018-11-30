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

namespace Domain.Operations.Setup.Questionnaires
{
   public class GetQuestionnaire : Questionnaire, IQueryable
    {
        public async Task<IEnumerable> QueryAsync()
    {
        var parameters = new OracleDynamicParameters();
        parameters.Add(QuestionnaireSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ID ?? DBNull.Value);
        parameters.Add(QuestionnaireSpParams.PARAMETER_QUS_LEVEL, OracleDbType.Int64, ParameterDirection.Input, (object)this.QustionnaireLevel ?? DBNull.Value);
        parameters.Add(QuestionnaireSpParams.PARAMETER_ST_LOB_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.LineOfBusiness ?? DBNull.Value);
        parameters.Add(QuestionnaireSpParams.PARAMETER_ST_SUB_LOB_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.SubLineOfBusiness ?? DBNull.Value);
            parameters.Add(QuestionnaireSpParams.PARAMETER_LANG_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.LangID ?? DBNull.Value);
            parameters.Add(QuestionnaireSpParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);
        return await QueryExecuter.ExecuteQueryAsync<Questionnaire>(QuestionnaireSpName.SP_LOAD_QUESTIONNAIRE, parameters);
    }
}
}
