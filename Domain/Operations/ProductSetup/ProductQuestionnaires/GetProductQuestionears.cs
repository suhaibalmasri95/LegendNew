using Common.Interfaces;
using Domain.Entities.ProductSetup;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.ProductSetup.ProductQuestionnaires
{
   public class GetProductQuestionears : ProductQuestionnaire, IQueryable
    {
        public async Task<IEnumerable> QueryAsync()
        {
            var parameters = new OracleDynamicParameters();
            parameters.Add(ProductQuestionearsSPParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ID ?? DBNull.Value);
            parameters.Add(ProductQuestionearsSPParams.PARAMETER_PRODUCT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ProductID ?? DBNull.Value);
            parameters.Add(ProductQuestionearsSPParams.PARAMETER_PRODUCT_DETAILS_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ProductDetailedID ?? DBNull.Value);
            parameters.Add(ProductQuestionearsSPParams.PARAMETER_LANG_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.LangID ?? DBNull.Value);
            parameters.Add(ProductQuestionearsSPParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);
            return await QueryExecuter.ExecuteQueryAsync<ProductQuestionnaire>(ProductQuestionearsSPName.SP_LOAD_PRODUCT_Question, parameters);
        }
    }
}
