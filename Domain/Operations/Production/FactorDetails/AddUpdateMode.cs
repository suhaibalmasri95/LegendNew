using System;
using System.Data;
using System.Threading.Tasks;
using Common.Interfaces;
using Common.Operations;
using Domain.Entities.Production;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;

namespace Domain.Operations.Production.FactorDetails
{
    public static class AddUpdateMode
    {
        public async static Task<IDTO> AddUpdate(FactorDetail factor)
        {
            string SPName = "";
            string message = "";
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (factor.ID.HasValue)
            {
                oracleParams.Add(FactorDetailSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)factor.ID ?? DBNull.Value);

                SPName = FactorDetailSpName.SP_UPADTE_FACTOR_DETAIL;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(FactorDetailSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = FactorDetailSpName.SP_INSERT_FACTOR_DETAIL;
                message = "Inserted Successfully";
            }


            oracleParams.Add(FactorDetailSpParams.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)factor.Name ?? DBNull.Value);
            oracleParams.Add(FactorDetailSpParams.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)factor.Name2 ?? DBNull.Value);
            oracleParams.Add(FactorDetailSpParams.PARAMETER_ST_DIC_COL_ID, OracleDbType.Int64, ParameterDirection.Input, (object)factor.DictionaryID ?? DBNull.Value);
            oracleParams.Add(FactorDetailSpParams.PARAMETER_ENTRY_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)factor.EntryType ?? DBNull.Value);
            oracleParams.Add(FactorDetailSpParams.PARAMETER_ST_PRD_FACT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)factor.FactorID ?? DBNull.Value);
            oracleParams.Add(FactorDetailSpParams.PARAMETER_FROM_VALUE, OracleDbType.Int64, ParameterDirection.Input, (object)factor.FromValue ?? DBNull.Value);
            oracleParams.Add(FactorDetailSpParams.PARAMETER_TO_VALUE, OracleDbType.Int64, ParameterDirection.Input, (object)factor.ToValue ?? DBNull.Value);
            oracleParams.Add(FactorDetailSpParams.PARAMETER_F_FROM_DATE, OracleDbType.Date, ParameterDirection.Input, (object)factor.FromDate ?? DBNull.Value);
            oracleParams.Add(FactorDetailSpParams.PARAMETER_F_TO_DATE, OracleDbType.Date, ParameterDirection.Input, (object)factor.ToDate ?? DBNull.Value);
            oracleParams.Add(FactorDetailSpParams.PARAMETER_ST_CHG_ID, OracleDbType.Int64, ParameterDirection.Input, (object)factor.ChargeID ?? DBNull.Value);
            oracleParams.Add(FactorDetailSpParams.PARAMETER_ST_PRD_ID, OracleDbType.Int64, ParameterDirection.Input, (object)factor.ProductID ?? DBNull.Value);
            oracleParams.Add(FactorDetailSpParams.PARAMETER_ST_PRDT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)factor.ProductDetailID ?? DBNull.Value);
            oracleParams.Add(FactorDetailSpParams.PARAMETER_FRRMULA_EDOTORS, OracleDbType.Varchar2, ParameterDirection.Input, (object)factor.FrrmulaEdotors ?? DBNull.Value);
            oracleParams.Add(FactorDetailSpParams.PARAMETER_ST_PRD_FACD_ID, OracleDbType.Int64, ParameterDirection.Input, (object)factor.ProductFacdID ?? DBNull.Value);




            if (await NonQueryExecuter.ExecuteNonQueryAsync(SPName, oracleParams) == -1)
            {
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
