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

namespace Domain.Operations.Organization.Banks
{
    public static class DBBankSetup
    {
        public async static Task<IDTO> AddUpdateMode(Bank bank)
        {
            string SPName = "";
            string message = "";
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (bank.ID.HasValue)
            {
                oracleParams.Add(BankSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)bank.ID ?? DBNull.Value);
                SPName = BankSPName.SP_UPADTE_BANCK;
                message = "Updated Successfully";
            }
            else { 
                oracleParams.Add(BankSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = BankSPName.SP_INSERT_BANCK;
                message = "Inserted Successfully";
            }

            oracleParams.Add(BankSpParams.PARAMETER_CURRENCY_CODE, OracleDbType.Varchar2, ParameterDirection.Input, (object)bank.CurrencyCode ?? DBNull.Value, 100);
            oracleParams.Add(BankSpParams.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)bank.Name ?? DBNull.Value, 500);
            oracleParams.Add(BankSpParams.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)bank.Name2 ?? DBNull.Value, 500);
            oracleParams.Add(BankSpParams.PARAMETER_PHONE_CODE, OracleDbType.Varchar2, ParameterDirection.Input, (object)bank.PhoneCode ?? DBNull.Value, 50);
            oracleParams.Add(BankSpParams.PARAMETER_PHONE, OracleDbType.Varchar2, ParameterDirection.Input, (object)bank.Phone ?? DBNull.Value,50);
         
            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)  
                complate.message = message;
            else
                complate.message = "Operation Failed";

            return complate;
        }
    }
}
