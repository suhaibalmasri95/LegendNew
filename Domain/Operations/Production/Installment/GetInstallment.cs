using Common.Interfaces;
using Domain.Entities.Production;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Production.Installments
{
    public class GetInstallments : Installment, IQueryable
    {
        public async Task<IEnumerable> QueryAsync()
        {
            var parameters = new OracleDynamicParameters();
            parameters.Add(InstallmetSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.ID ?? DBNull.Value);
            parameters.Add(InstallmetSpParams.PARAMETER_UW_DOC_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.DocumentID ?? DBNull.Value);
    
            parameters.Add(InstallmetSpParams.PARAMETER_LANG_ID, OracleDbType.Int64, ParameterDirection.Input, (object)this.LangID ?? DBNull.Value);
            parameters.Add(InstallmetSpParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);

            return await QueryExecuter.ExecuteQueryAsync<Installment>(InstallmentSpName.SP_LOAD_INSTALLMENT, parameters);
        }
    }
}
