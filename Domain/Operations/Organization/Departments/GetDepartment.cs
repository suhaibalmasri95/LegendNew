using Common.Interfaces;
using Domain.Organization.Entities;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Data;

using System.Threading.Tasks;

namespace Domain.Operations.Organization.Departments
{
    public class GetDepartment : Department, IQueryable
    {
        public async Task<IEnumerable> Query()
        {
            var dyParam = new OracleDynamicParameters();
            
            dyParam.Add(DepartmentSpParams.PARAMETER_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)ID ?? DBNull.Value);
            dyParam.Add(DepartmentSpParams.PARAMETER_COMPANY_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)CompanyID ?? DBNull.Value);
            dyParam.Add(DepartmentSpParams.PARAMETER_LANG_ID, OracleDbType.Decimal, ParameterDirection.Input, (object)LangID ?? DBNull.Value);
            dyParam.Add(DepartmentSpParams.PARAMETER_REF_SELECT, OracleDbType.RefCursor, ParameterDirection.Output);

            return await QueryExecuter.ExecuteQueryAsync<Department>(DepartmentSPName.SP_LOAD_COMPANY_DEPARTMENT, dyParam);
        }
    }
}
