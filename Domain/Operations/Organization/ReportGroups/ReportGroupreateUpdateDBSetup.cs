using Common.Interfaces;
using Common.Operations;
using Domain.Entities.Organization;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Organization.ReportGroups
{
    public class ReportGroupreateUpdateDBSetup
    {
        public async static Task<IDTO> AddUpdateMode(ReportGroup bank)
        {
            string SPName = "";
            string message = "";
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (bank.ID.HasValue)
            {
                oracleParams.Add(ReportGroupSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)bank.ID ?? DBNull.Value);
                SPName = ReportGroupSPName.SP_UPADTE_ReportGroup;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(ReportGroupSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = ReportGroupSPName.SP_INSERT_ReportGroup;
                message = "Inserted Successfully";
            }

            oracleParams.Add(ReportGroupSpParams.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)bank.Name ?? DBNull.Value, 500);
            oracleParams.Add(ReportGroupSpParams.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)bank.Name2 ?? DBNull.Value, 500);
            oracleParams.Add(ReportGroupSpParams.PARAMETER_ORDER_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)bank.OrderBy ?? DBNull.Value, 50);

            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)
                complate.message = message;
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
