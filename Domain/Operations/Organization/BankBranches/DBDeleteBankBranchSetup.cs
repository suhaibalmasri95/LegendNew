using Common.Interfaces;
using Common.Operations;
using Domain.Organization.Entities;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Organization.BankBranches
{
    public class DBDeleteBankBranchSetup
    {
        public async static Task<IDTO> DeleteBankBranchAsync(BankBranch bankBranch)
        {
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();
            var dyParam = new OracleDynamicParameters();
            dyParam.Add(BankBranchSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)bankBranch.ID ?? DBNull.Value);

            if (await NonQueryExecuter.ExecuteNonQueryAsync(BankBranchSPName.SP_DELETE_BANCK_BRANCH, dyParam) == -1)
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
