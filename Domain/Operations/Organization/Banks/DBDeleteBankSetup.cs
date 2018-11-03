using Common.Interfaces;
using Common.Operations;
using Domain.Organization.Entities;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Organization.Banks
{
    public class DBDeleteBankSetup
    {
        public async static Task<IDTO> DeleteBankAsync(Bank bank)
        {
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();
            var dyParam = new OracleDynamicParameters();
            dyParam.Add(BankSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)bank.ID ?? DBNull.Value);

            if (await NonQueryExecuter.ExecuteNonQueryAsync(BankSPName.SP_DELETE_BANCK, dyParam) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";

            return complate;

        }

        /*public async static Task<IDTO> DeleteCountriesAsync(List<Country> countries)
        {
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();
            var dyParam = new OracleDynamicParameters();
            dyParam.Add(CountrySpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)country.ID ?? DBNull.Value);

            if (await NonQueryExecuter.ExecuteNonQueryAsync(CountrySPName.SP_DELETE_COUNTRY, dyParam) == -1)
                complate.message = "Operation Successed";
            else
                complate.message = "Operation Failed";

            return complate;

        }*/
    }
    }
