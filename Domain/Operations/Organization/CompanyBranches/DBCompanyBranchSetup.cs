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

namespace Domain.Operations.Organization.CompanyBranches
{
    public static class DBCompanyBranchSetup
    {
        public async static Task<IDTO> AddUpdateMode(CompanyBranch companyBranch)
        {
            string SPName = "";
            string message = "";
            OracleDynamicParameters dyParam = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (companyBranch.ID.HasValue)
            {
                dyParam.Add(CompanyBranchSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)companyBranch.ID ?? DBNull.Value);
                SPName = CompanyBranchSPName.SP_UPADTE_COMPANY_BRANCH;
                message = "Updated Successfully";
            }
            else {
                dyParam.Add(CompanyBranchSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = CompanyBranchSPName.SP_INSERT_COMPANY_BRANCH;
                message = "Inserted Successfully";
            }

        
            dyParam.Add(CompanyBranchSpParams.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)companyBranch.Name ?? DBNull.Value, 1000);
            dyParam.Add(CompanyBranchSpParams.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)companyBranch.Name2 ?? DBNull.Value, 1000);
            dyParam.Add(CompanyBranchSpParams.PARAMETER_CODE, OracleDbType.Varchar2, ParameterDirection.Input, (object)companyBranch.Code ?? DBNull.Value, 30);
            dyParam.Add(CompanyBranchSpParams.PARAMETER_PHONE, OracleDbType.Varchar2, ParameterDirection.Input, (object)companyBranch.Phone ?? DBNull.Value, 30);
            dyParam.Add(CompanyBranchSpParams.PARAMETER_FAX, OracleDbType.Varchar2, ParameterDirection.Input, (object)companyBranch.Fax ?? DBNull.Value, 30);
            dyParam.Add(CompanyBranchSpParams.PARAMETER_EMAIL, OracleDbType.Varchar2, ParameterDirection.Input, (object)companyBranch.Email ?? DBNull.Value, 30);
            dyParam.Add(CompanyBranchSpParams.PARAMETER_ADDRESS, OracleDbType.Varchar2, ParameterDirection.Input, (object)companyBranch.Address ?? DBNull.Value, 30);
            dyParam.Add(CompanyBranchSpParams.PARAMETER_ADDRESS2, OracleDbType.Varchar2, ParameterDirection.Input, (object)companyBranch.Address2 ?? DBNull.Value, 30);
            dyParam.Add(CompanyBranchSpParams.PARAMETER_COMPANY_ID, OracleDbType.Int64, ParameterDirection.Input, (object)companyBranch.CompanyID ?? DBNull.Value);
            dyParam.Add(CompanyBranchSpParams.PARAMETER_CITY_ID, OracleDbType.Int64, ParameterDirection.Input, (object)companyBranch.CityID ?? DBNull.Value);
            dyParam.Add(CompanyBranchSpParams.PARAMETER_COUNTRY_ID, OracleDbType.Int64, ParameterDirection.Input, (object)companyBranch.CountryID ?? DBNull.Value);
            dyParam.Add(CompanyBranchSpParams.PARAMETER_COUNTRY_CURRENCY_CODE, OracleDbType.Varchar2, ParameterDirection.Input, (object)companyBranch.CurrencyCode ?? DBNull.Value, 30);


            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, dyParam) == -1)  
                complate.message = message;
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
