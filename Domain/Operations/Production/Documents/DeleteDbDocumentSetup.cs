using Common.Interfaces;
using Common.Operations;
using Domain.Entities.Production;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Production.Documents
{
   public static class DeleteDbDocumentSetup
    {
        public async static Task<IDTO> DeleteDocumentAsync(Document document)
        {
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();
            var dyParam = new OracleDynamicParameters();
            dyParam.Add(DocumentSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)document.ID ?? DBNull.Value);
            if (await NonQueryExecuter.ExecuteNonQueryAsync(DocumentSpName.SP_DELETE_DOCUMENT, dyParam) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";
            return complate;
        }

        public async static Task<IDTO> DeleteDocumentAsync(long[] IDs)
        {

            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (await NonQueryExecuter.ExecuteNonQueryAsync(MultiDeleteFormater.Format(typeof(Document), IDs)) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
