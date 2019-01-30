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

namespace Domain.Operations.Production.Installments
{
    public static class DeleteMode
    {
        public async static Task<IDTO> DeleteInstallment(Installment installmet)
        {
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();
            var dyParam = new OracleDynamicParameters();
            dyParam.Add(InstallmetSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)installmet.ID ?? DBNull.Value);
            if (await NonQueryExecuter.ExecuteNonQueryAsync(InstallmentSpName.SP_DELETE_INSTALLMENT, dyParam) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";
            return complate;
        }

        public async static Task<IDTO> DeleteInstallments(long[] IDs)
        {

            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (await NonQueryExecuter.ExecuteNonQueryAsync(MultiDeleteFormater.Format(typeof(Installment), IDs)) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
