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

namespace Domain.Operations.Setup.SubjectTypies
{
    public static class DBSubjectTypeSetup
    {
        public async static Task<IDTO> AddUpdateMode(SubjectType subjectType)
        {
            var SPName = default(string);
            var message = default(string);
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (subjectType.ID.HasValue)
            {
                oracleParams.Add(SubjectTypepParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)subjectType.ID ?? DBNull.Value);
                SPName = SubjectTypeSPName.SP_UPADTE_SubjectType;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(SubjectTypepParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = SubjectTypeSPName.SP_INSERT_SubjectType;
                message = "Inserted Successfully";
            }
            oracleParams.Add(SubjectTypepParams.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)subjectType.Name ?? DBNull.Value, 1000);
            oracleParams.Add(SubjectTypepParams.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)subjectType.Name2 ?? DBNull.Value, 1000);
            oracleParams.Add(SubjectTypepParams.PARAMETER_CREATED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)subjectType.CreatedBy ?? DBNull.Value, 1000);
            oracleParams.Add(SubjectTypepParams.PARAMETER_CREATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)subjectType.CreationDate ?? DBNull.Value);
            oracleParams.Add(SubjectTypepParams.PARAMETER_MODIFIED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)subjectType.ModifiedBy ?? DBNull.Value,1000);
            oracleParams.Add(SubjectTypepParams.PARAMETER_MODIFICATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)subjectType.ModificationDate ?? DBNull.Value);
            oracleParams.Add(SubjectTypepParams.PARAMETER_PARENT, OracleDbType.Int64, ParameterDirection.Input, (object)subjectType.Parent ?? DBNull.Value);
            oracleParams.Add(SubjectTypepParams.PARAMETER_LINEOFBUSNIESS, OracleDbType.Long, ParameterDirection.Input, subjectType.LineOfBusniessID, 500);
            oracleParams.Add(SubjectTypepParams.PARAMETER_SUBLINEOFBUSNIESS, OracleDbType.Long, ParameterDirection.Input, subjectType.SubLineOfBusniessID, 500);
            oracleParams.Add(SubjectTypepParams.PARAMETER_EXCESS_MAX_AMOUNT, OracleDbType.Long, ParameterDirection.Input, subjectType.MaxExcessAmount, 500);
            oracleParams.Add(SubjectTypepParams.PARAMETER_EXCESS_FROM, OracleDbType.Long, ParameterDirection.Input, subjectType.From, 500);
            oracleParams.Add(SubjectTypepParams.PARAMETER_EXCESS_PER, OracleDbType.Varchar2, ParameterDirection.Input, subjectType.ExcessPercentage, 500);
            oracleParams.Add(SubjectTypepParams.PARAMETER_EXCESS_MIN_AMOUNT, OracleDbType.Varchar2, ParameterDirection.Input, subjectType.MinExcessAmount, 500);
            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)
                complate.message = message;
            else
                complate.message = "Operation Failed";
            return complate;
        }

    }
}
