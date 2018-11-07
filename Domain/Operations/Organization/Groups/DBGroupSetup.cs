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

namespace Domain.Operations.Organization.Groups
{
    public static class DBGroupSetup 
    {
        public async static Task<IDTO> AddUpdateMode(Group group)
        {
            string SPName = "";
            string message = "";
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (group.ID.HasValue)
            {
                oracleParams.Add(GroupSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)group.ID ?? DBNull.Value);
                SPName = GroupSpName.SP_UPADTE_GROUP;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(GroupSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = GroupSpName.SP_INSERT_GROUP;
                message = "Inserted Successfully";
            }
            oracleParams.Add(GroupSpParams.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)group.Name ?? DBNull.Value, 1000);
            oracleParams.Add(GroupSpParams.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)group.Name2 ?? DBNull.Value, 1000);
            oracleParams.Add(GroupSpParams.PARAMETER_LOC_STATUS, OracleDbType.Int64, ParameterDirection.Input, (object)group.Status ?? DBNull.Value);
            oracleParams.Add(GroupSpParams.PARAMETER_STATUS_DATE, OracleDbType.Date, ParameterDirection.Input, (object)group.StatusDate ?? DBNull.Value);
            oracleParams.Add(GroupSpParams.PARAMETER_IS_PDF, OracleDbType.Int64, ParameterDirection.Input, (object)group.IsPdf ?? DBNull.Value);
            oracleParams.Add(GroupSpParams.PARAMETER_IS_WORD, OracleDbType.Int64, ParameterDirection.Input, (object)group.IsWord ?? DBNull.Value);
            oracleParams.Add(GroupSpParams.PARAMETER_IS_RTF, OracleDbType.Int64, ParameterDirection.Input, (object)group.IsRef ?? DBNull.Value);
            oracleParams.Add(GroupSpParams.PARAMETER_IS_EXCEL, OracleDbType.Int64, ParameterDirection.Input, (object)group.IsExcel ?? DBNull.Value);
            oracleParams.Add(GroupSpParams.PARAMETER_IS_EXCEL_RECORD, OracleDbType.Int64, ParameterDirection.Input, (object)group.IsExcelRecord ?? DBNull.Value);
            oracleParams.Add(GroupSpParams.PARAMETER_EMAIL, OracleDbType.Varchar2, ParameterDirection.Input, (object)group.Email ?? DBNull.Value, 30);
            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)
                complate.message = message;
            else
                complate.message = "Operation Failed";

            return complate;
        }

    }
}
