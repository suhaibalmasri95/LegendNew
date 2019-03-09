using System;
using System.Data;
using System.Threading.Tasks;
using Common.Interfaces;
using Common.Operations;
using Domain.Entities.ProductSetup;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;

namespace Domain.Operations.ProductSetup.Charges
{
    public class AddUpdateMode
    {
        public async static Task<IDTO> AddUpdate(ProductCharges charge)
        {
            string SPName = "";
            string message = "";
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();

            if (charge.ID.HasValue)
            {
                oracleParams.Add(ChargeSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)charge.ID ?? DBNull.Value);

                SPName = ChargeSpName.SP_UPADTE_CHARGE;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(ChargeSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = ChargeSpName.SP_INSERT_CHARGE;
                message = "Inserted Successfully";
            }


            oracleParams.Add(ChargeSpParams.PARAMETER_NAME, OracleDbType.Varchar2, ParameterDirection.Input, (object)charge.Name ?? DBNull.Value);
            oracleParams.Add(ChargeSpParams.PARAMETER_NAME2, OracleDbType.Varchar2, ParameterDirection.Input, (object)charge.Name2 ?? DBNull.Value);
            oracleParams.Add(ChargeSpParams.PARAMETER_SERIAL, OracleDbType.Int64, ParameterDirection.Input, (object)charge.Serial ?? DBNull.Value);
            oracleParams.Add(ChargeSpParams.PARAMETER_NET_AMOUNT, OracleDbType.Double, ParameterDirection.Input, (object)charge.NetAmount ?? DBNull.Value);
            oracleParams.Add(ChargeSpParams.PARAMETER_LOADING_PREC, OracleDbType.Double, ParameterDirection.Input, (object)charge.LoadingPercent ?? DBNull.Value);
            oracleParams.Add(ChargeSpParams.PARAMETER_DISCOUNT_PREC, OracleDbType.Double, ParameterDirection.Input, (object)charge.DiscountPercent ?? DBNull.Value);
            oracleParams.Add(ChargeSpParams.PARAMETER_GROSS_AMOUNT, OracleDbType.Double, ParameterDirection.Input, (object)charge.GrossAmount ?? DBNull.Value);
            oracleParams.Add(ChargeSpParams.PARAMETER_FACTOR_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)charge.FactorType ?? DBNull.Value);
            oracleParams.Add(ChargeSpParams.PARAMETER_RATE, OracleDbType.Double, ParameterDirection.Input, (object)charge.Rate ?? DBNull.Value);
            oracleParams.Add(ChargeSpParams.PARAMETER_MIN_AMOUNT, OracleDbType.Double, ParameterDirection.Input, (object)charge.MinAmount ?? DBNull.Value);
            oracleParams.Add(ChargeSpParams.PARAMETER_MAX_AMOUNT, OracleDbType.Double, ParameterDirection.Input, (object)charge.MaxAmount ?? DBNull.Value);
            oracleParams.Add(ChargeSpParams.PARAMETER_EXCESS_PER, OracleDbType.Double, ParameterDirection.Input, (object)charge.ExcessPercent ?? DBNull.Value);
            oracleParams.Add(ChargeSpParams.PARAMETER_EXCESS_AMOUNT, OracleDbType.Double, ParameterDirection.Input, (object)charge.ExcessAmount ?? DBNull.Value);
            oracleParams.Add(ChargeSpParams.PARAMETER_AGGREGATED_LIMIT, OracleDbType.Double, ParameterDirection.Input, (object)charge.AggregatedLimit ?? DBNull.Value);
            oracleParams.Add(ChargeSpParams.PARAMETER_CASE_LIMIT, OracleDbType.Double, ParameterDirection.Input, (object)charge.CaseLimit ?? DBNull.Value);
            oracleParams.Add(ChargeSpParams.PARAMETER_APPLY_AGENT_COMM, OracleDbType.Double, ParameterDirection.Input, (object)charge.ApplyAgentComm ?? DBNull.Value);
            oracleParams.Add(ChargeSpParams.PARAMETER_ST_LOB, OracleDbType.Int64, ParameterDirection.Input, (object)charge.LineOfBusiness ?? DBNull.Value);
            oracleParams.Add(ChargeSpParams.PARAMETER_ST_SUB_LOB, OracleDbType.Int64, ParameterDirection.Input, (object)charge.SubLineOfBusiness ?? DBNull.Value);
            oracleParams.Add(ChargeSpParams.PARAMETER_IS_DISCOUNTABLE, OracleDbType.Int16, ParameterDirection.Input, (object)charge.IsDiscountable ?? DBNull.Value);
            oracleParams.Add(ChargeSpParams.PARAMETER_IS_REINSURANCE, OracleDbType.Int16, ParameterDirection.Input, (object)charge.IsReinsurance ?? DBNull.Value);
            oracleParams.Add(ChargeSpParams.PARAMETER_IS_BASIC, OracleDbType.Int16, ParameterDirection.Input, (object)charge.IsBasic ?? DBNull.Value);
            oracleParams.Add(ChargeSpParams.PARAMETER_IS_AUTOFILL, OracleDbType.Int16, ParameterDirection.Input, (object)charge.IsAutoFill ?? DBNull.Value);
            oracleParams.Add(ChargeSpParams.PARAMETER_IS_APPLY_PREMIUM, OracleDbType.Int16, ParameterDirection.Input, (object)charge.IsApplyPremium ?? DBNull.Value);
            oracleParams.Add(ChargeSpParams.PARAMETER_IS_EDITABLE, OracleDbType.Int16, ParameterDirection.Input, (object)charge.IsEditable ?? DBNull.Value);
            oracleParams.Add(ChargeSpParams.PARAMETER_ST_PRD_PRCD_ID, OracleDbType.Int64, ParameterDirection.Input, (object)charge.PricingID ?? DBNull.Value);
            oracleParams.Add(ChargeSpParams.PARAMETER_DR_CR, OracleDbType.Int64, ParameterDirection.Input, (object)charge.DrCr ?? DBNull.Value);
            oracleParams.Add(ChargeSpParams.PARAMETER_LOC_CHARG_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)charge.LocChargeType ?? DBNull.Value);

            oracleParams.Add(ChargeSpParams.PARAMETER_ST_CHG_ID, OracleDbType.Int64, ParameterDirection.Input, (object)charge.ChargeID ?? DBNull.Value);
            oracleParams.Add(ChargeSpParams.PARAMETER_ST_PRD_ID, OracleDbType.Int64, ParameterDirection.Input, (object)charge.ProductID ?? DBNull.Value);
            oracleParams.Add(ChargeSpParams.PARAMETER_ST_PRDT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)charge.ProductDetaiID ?? DBNull.Value);
            oracleParams.Add(ChargeSpParams.PARAMETER_ST_SBT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)charge.SbtID ?? DBNull.Value);
            oracleParams.Add(ChargeSpParams.PARAMETER_ST_DIC_COL_ID, OracleDbType.Int64, ParameterDirection.Input, (object)charge.Dictionary ?? DBNull.Value);
            oracleParams.Add(ChargeSpParams.PARAMETER_WHERE_COND, OracleDbType.Varchar2, ParameterDirection.Input, (object)charge.WhereCondition ?? DBNull.Value);
            oracleParams.Add(ChargeSpParams.PARAMETER_CREATED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)charge.CreatedBy ?? DBNull.Value);
            oracleParams.Add(ChargeSpParams.PARAMETER_CREATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)charge.CreationDate ?? DBNull.Value);
            oracleParams.Add(ChargeSpParams.PARAMETER_MODIFIED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)charge.ModifiedBy ?? DBNull.Value);
            oracleParams.Add(ChargeSpParams.PARAMETER_MODIFICATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)charge.ModificationDate ?? DBNull.Value);
            oracleParams.Add(ChargeSpParams.PARAMETER_STATUS, OracleDbType.Int64, ParameterDirection.Input, (object)charge.Status ?? DBNull.Value);
            oracleParams.Add(ChargeSpParams.PARAMETER_STATUS_DATE, OracleDbType.Date, ParameterDirection.Input, (object)charge.StatusDate ?? DBNull.Value);
            oracleParams.Add(ChargeSpParams.PARAMETER_EFFECTIVE_DATE, OracleDbType.Date, ParameterDirection.Input, (object)charge.EffectiveDate ?? DBNull.Value);
            oracleParams.Add(ChargeSpParams.PARAMETER_EXPIRY_DATE, OracleDbType.Date, ParameterDirection.Input, (object)charge.ExpiryDate ?? DBNull.Value);
            oracleParams.Add(ChargeSpParams.PARAMETER_ST_PRD_FACT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)charge.ProductFactorID ?? DBNull.Value);


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
