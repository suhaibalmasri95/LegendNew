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

namespace Domain.Operations.Organization.Companies
{
    public static class DBCompanySetup
    {
        public async static Task<IDTO> AddUpdateMode(Company company)
        {
            string SPName = "";
            string message = "";
            OracleDynamicParameters dyParam = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (company.ID.HasValue)
            {
                dyParam.Add(CompanySpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)company.ID ?? DBNull.Value);
                SPName = CompanySPName.SP_UPADTE_COMPANY;
                message = "Updated Successfully";
            }
            else {
                dyParam.Add(CompanySpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = CompanySPName.SP_INSERT_COMPANY;
                message = "Inserted Successfully";
            }

            dyParam.Add(CompanySpParams.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)company.Name ?? DBNull.Value, 500);
            dyParam.Add(CompanySpParams.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)company.Name ?? DBNull.Value, 500);
            dyParam.Add(CompanySpParams.PARAMETER_PHONE, OracleDbType.Varchar2, ParameterDirection.Input, (object)company.Phone ?? DBNull.Value, 30);
            dyParam.Add(CompanySpParams.PARAMETER_COUNTRY_CODE, OracleDbType.Varchar2, ParameterDirection.Input, (object)company.CountryCode ?? DBNull.Value, 30);
            dyParam.Add(CompanySpParams.PARAMETER_MOBILE, OracleDbType.Varchar2, ParameterDirection.Input, (object)company.Mobile ?? DBNull.Value, 30);
            dyParam.Add(CompanySpParams.PARAMETER_FAX, OracleDbType.Varchar2, ParameterDirection.Input, (object)company.Fax ?? DBNull.Value, 30);
            dyParam.Add(CompanySpParams.PARAMETER_EMAIL, OracleDbType.Varchar2, ParameterDirection.Input, (object)company.Email ?? DBNull.Value, 30);
            dyParam.Add(CompanySpParams.PARAMETER_WEBSITE, OracleDbType.Varchar2, ParameterDirection.Input, (object)company.Website ?? DBNull.Value, 30);
            dyParam.Add(CompanySpParams.PARAMETER_ADDRESS, OracleDbType.Varchar2, ParameterDirection.Input, (object)company.Address ?? DBNull.Value, 30);
            dyParam.Add(CompanySpParams.PARAMETER_ADDRESS2, OracleDbType.Varchar2, ParameterDirection.Input, (object)company.Address2 ?? DBNull.Value, 30);
            dyParam.Add(CompanySpParams.PARAMETER_CONTACT_PERSON, OracleDbType.Varchar2, ParameterDirection.Input, (object)company.ContactPerson ?? DBNull.Value, 30);
            dyParam.Add(CompanySpParams.PARAMETER_CODE, OracleDbType.Varchar2, ParameterDirection.Input, (object)company.Code ?? DBNull.Value, 30);
            dyParam.Add(CompanySpParams.PARAMETER_COUNTRY_CURRENCY_CODE, OracleDbType.Varchar2, ParameterDirection.Input, (object)company.CurrencyCode ?? DBNull.Value, 30);
            dyParam.Add(CompanySpParams.PARAMETER_COUNTRY_ID, OracleDbType.Int64, ParameterDirection.Input, (object)company.CountryID ?? DBNull.Value);
            dyParam.Add(CompanySpParams.PARAMETER_LOGO, OracleDbType.Varchar2, ParameterDirection.Input, (object)company.Logo ?? DBNull.Value, 30);
            dyParam.Add(CompanySpParams.PARAMETER_PASS_MLENGHT, OracleDbType.Int32, ParameterDirection.Input, (object)company.PasswordMinLength ?? DBNull.Value);
            dyParam.Add(CompanySpParams.PARAMETER_PASS_MUPPER, OracleDbType.Int32, ParameterDirection.Input, (object)company.PasswordMinUpperCase ?? DBNull.Value);
            dyParam.Add(CompanySpParams.PARAMETER_PASS_MLOWER, OracleDbType.Int32, ParameterDirection.Input, (object)company.PasswordMinLowerCase ?? DBNull.Value);
            dyParam.Add(CompanySpParams.PARAMETER_PASS_MDIGITS, OracleDbType.Int32, ParameterDirection.Input, (object)company.PasswordMinNumbers ?? DBNull.Value);
            dyParam.Add(CompanySpParams.PARAMETER_PASS_MSPECIAL, OracleDbType.Int32, ParameterDirection.Input, (object)company.PasswordMinSpecialCharacters ?? DBNull.Value);
            dyParam.Add(CompanySpParams.PARAMETER_PASS_EXPIRY_PERIOD, OracleDbType.Int32, ParameterDirection.Input, (object)company.PasswordExpiryDays ?? DBNull.Value);
            dyParam.Add(CompanySpParams.PARAMETER_PASS_LOGATTEMPTS, OracleDbType.Int32, ParameterDirection.Input, (object)company.PasswordFailedLoginAttempts ?? DBNull.Value);
            dyParam.Add(CompanySpParams.PARAMETER_PASS_REPEAT, OracleDbType.Int32, ParameterDirection.Input, (object)company.PasswordRepeats ?? DBNull.Value);


            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, dyParam) == -1)  
                complate.message = message;
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
