using Common.Interfaces;
using Common.Operations;
using Domain.Organization.Entities;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Organization.CompanyBranches
{
    public class DBDeleteCompanyBranchSetup
    {
        public async static Task<IDTO> DeleteCompanyBranchAsync(CompanyBranch companyBranch)
        {
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();
            var dyParam = new OracleDynamicParameters();
            dyParam.Add(CompanyBranchSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)companyBranch.ID ?? DBNull.Value);

            if (await NonQueryExecuter.ExecuteNonQueryAsync(CompanyBranchSPName.SP_DELETE_COMPANY_BRANCH, dyParam) == -1)
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
