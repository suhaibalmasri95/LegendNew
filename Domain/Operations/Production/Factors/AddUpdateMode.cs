using System;
using System.Data;
using System.Threading.Tasks;
using Common.Interfaces;
using Common.Operations;
using Domain.Entities.Production;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;

namespace Domain.Operations.Production.Factors
{
    public static class AddUpdateMode
    {
        public async static Task<IDTO> AddUpdate(Factor factor)
        {
            string SPName = "";
            string message = "";
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (factor.ID.HasValue)
            {
                oracleParams.Add(FactorSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)factor.ID ?? DBNull.Value);

                SPName = FactorSpName.SP_UPADTE_FACTOR;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(FactorSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = FactorSpName.SP_INSERT_FACTOR;
                message = "Inserted Successfully";
            }


            oracleParams.Add(FactorSpParams.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)factor.Name ?? DBNull.Value);
            oracleParams.Add(FactorSpParams.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)factor.Name2 ?? DBNull.Value);
            oracleParams.Add(FactorSpParams.PARAMETER_FACT_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)factor.FactorType ?? DBNull.Value);
            oracleParams.Add(FactorSpParams.PARAMETER_ST_PRD_PRCD_ID, OracleDbType.Int64, ParameterDirection.Input, (object)factor.PricingID ?? DBNull.Value);
            oracleParams.Add(FactorSpParams.PARAMETER_ST_DIC_COL_ID, OracleDbType.Int64, ParameterDirection.Input, (object)factor.DictionaryID ?? DBNull.Value);
            oracleParams.Add(FactorSpParams.PARAMETER_ENTRY_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)factor.EntryType ?? DBNull.Value);
            oracleParams.Add(FactorSpParams.PARAMETER_ST_PRD_FACT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)factor.ProductFactorID ?? DBNull.Value);




            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)
            {
                complate.ID = oracleParams.Get(0);
                complate.message = "Operation Success";
            }

            else
            {
                complate.message = "Operation Failed";
            }

            return complate;
        }
    }
}
