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

namespace Domain.Operations.Organization.BankBranches
{
    public static class DBBankBranchSetup
    {
        public async static Task<IDTO> AddUpdateMode(BankBranch bankBranch)
        {
            string SPName = "";
            string message = "";
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (bankBranch.ID.HasValue)
            {
                oracleParams.Add(BankBranchSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)bankBranch.ID ?? DBNull.Value);
                SPName = BankBranchSPName.SP_UPADTE_BANCK_BRANCH;
                message = "Updated Successfully";
            }
            else { 
                oracleParams.Add(BankBranchSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = BankBranchSPName.SP_INSERT_BANCK_BRANCH;
                message = "Inserted Successfully";
            }

            oracleParams.Add(BankBranchSpParams.PARAMETER_CURRENCY_CODE, OracleDbType.Varchar2, ParameterDirection.Input, (object)bankBranch.CurrencyCode ?? DBNull.Value, 100);
            oracleParams.Add(BankBranchSpParams.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)bankBranch.Name ?? DBNull.Value, 500);
            oracleParams.Add(BankBranchSpParams.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)bankBranch.Name2 ?? DBNull.Value, 500);
            oracleParams.Add(BankBranchSpParams.PARAMETER_PHONE_CODE, OracleDbType.Varchar2, ParameterDirection.Input, (object)bankBranch.PhoneCode ?? DBNull.Value, 50);
            oracleParams.Add(BankBranchSpParams.PARAMETER_PHONE, OracleDbType.Varchar2, ParameterDirection.Input, (object)bankBranch.Phone ?? DBNull.Value,50);
            oracleParams.Add(BankBranchSpParams.PARAMETER_BANK_ID, OracleDbType.Int64, ParameterDirection.Input, (object)bankBranch.BankID ?? DBNull.Value);
            oracleParams.Add(BankBranchSpParams.PARAMETER_CITY_ID, OracleDbType.Int64, ParameterDirection.Input, (object)bankBranch.CityID ?? DBNull.Value);
            oracleParams.Add(BankBranchSpParams.PARAMETER_COUNTRY_ID, OracleDbType.Int64, ParameterDirection.Input, (object)bankBranch.CountryID ?? DBNull.Value);




            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)  
                complate.message = message;
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
