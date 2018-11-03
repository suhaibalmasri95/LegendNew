using Common.Interfaces;
using Common.Operations;
using Domain.Organization.Entities;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Organization.Departments
{
    public static class DBDepartmentSetup
    {
        public async static Task<IDTO> AddUpdateMode(Department department)
        {
            string SPName = "";
            string message = "";
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (department.ID.HasValue)
            {
                oracleParams.Add(DepartmentSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)department.ID ?? DBNull.Value);
                SPName = DepartmentSPName.SP_UPADTE_COMPANY_DEPARTMENT;
                message = "Updated Successfully";
            }
            else { 
                oracleParams.Add(DepartmentSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = DepartmentSPName.SP_INSERT_COMPANY_DEPARTMENT;
                message = "Inserted Successfully";
            }
            oracleParams.Add(DepartmentSpParams.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)department.Name ?? DBNull.Value, 500);
            oracleParams.Add(DepartmentSpParams.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)department.Name2 ?? DBNull.Value, 500);
            oracleParams.Add(DepartmentSpParams.PARAMETER_ADDRESS, OracleDbType.Varchar2, ParameterDirection.Input, (object)department.Address ?? DBNull.Value, 30);
            oracleParams.Add(DepartmentSpParams.PARAMETER_EMAIL, OracleDbType.Varchar2, ParameterDirection.Input, (object)department.Email ?? DBNull.Value, 30);
            oracleParams.Add(DepartmentSpParams.PARAMETER_COMPANY_ID, OracleDbType.Int64, ParameterDirection.Input, (object)department.CompanyID ?? DBNull.Value);

            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)  
                complate.message = message;
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
