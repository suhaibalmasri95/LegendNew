using Common.Interfaces;
using Common.Operations;
using Domain.Entities.Production;
using Infrastructure.DB;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Production.Covers
{
   public static class AddUpdateMode
    {
        public async static Task<IDTO> AddUpdate(Cover cover)
        {
            string SPName = "";
            string message = "";
            OracleDynamicParameters oracleParams = new OracleDynamicParameters();
            ComplateOperation<int> complate = new ComplateOperation<int>();
       
            if (cover.ID.HasValue)
            {
                oracleParams.Add(CoverSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Input, (object)cover.ID ?? DBNull.Value);

                SPName = CoverSpName.SP_UPADTE_COVER;
                message = "Updated Successfully";
            }
            else
            {
                oracleParams.Add(CoverSpParams.PARAMETER_ID, OracleDbType.Int64, ParameterDirection.Output);
                SPName = CoverSpName.SP_INSERT_COVER;
                message = "Inserted Successfully";
            }


            oracleParams.Add(CoverSpParams.PARAMETER_LOC_CHARG_TYPE, OracleDbType.Int64, ParameterDirection.Input, (object)cover.ChargeType ?? DBNull.Value);
            oracleParams.Add(CoverSpParams.PARAMETER_SERIAL, OracleDbType.Int64, ParameterDirection.Input, (object)cover.Serial ?? DBNull.Value);
            oracleParams.Add(CoverSpParams.PARAMETER_SUMINSURED, OracleDbType.Decimal, ParameterDirection.Input, (object)cover.Suminsured ?? DBNull.Value);
            oracleParams.Add(CoverSpParams.PARAMETER_SUMINSURED_LC, OracleDbType.Decimal, ParameterDirection.Input, (object)cover.SuminsuredLC ?? DBNull.Value);
            oracleParams.Add(CoverSpParams.PARAMETER_RATE, OracleDbType.Decimal, ParameterDirection.Input, (object)cover.Rate ?? DBNull.Value);
            oracleParams.Add(CoverSpParams.PARAMETER_EXRATE, OracleDbType.Decimal, ParameterDirection.Input, (object)cover.Exrate ?? DBNull.Value);
            oracleParams.Add(CoverSpParams.PARAMETER_GROSS_AMOUNT, OracleDbType.Decimal, ParameterDirection.Input, (object)cover.GrossAmount ?? DBNull.Value);
            oracleParams.Add(CoverSpParams.PARAMETER_GROSS_AMOUNT_LC, OracleDbType.Decimal, ParameterDirection.Input, (object)cover.GrossAmountLc ?? DBNull.Value);
            oracleParams.Add(CoverSpParams.PARAMETER_NET_AMOUNT, OracleDbType.Decimal, ParameterDirection.Input, (object)cover.NetAmount ?? DBNull.Value);
            oracleParams.Add(CoverSpParams.PARAMETER_NET_AMOUNT_LC, OracleDbType.Decimal, ParameterDirection.Input, (object)cover.NetAmountLc    ?? DBNull.Value);
            oracleParams.Add(CoverSpParams.PARAMETER_DISCOUNT_PREC, OracleDbType.Decimal, ParameterDirection.Input, (object)cover.DiscountPrec ?? DBNull.Value);
            oracleParams.Add(CoverSpParams.PARAMETER_DISCOUNT_AMOUNT, OracleDbType.Decimal, ParameterDirection.Input, (object)cover.DiscountAmount ?? DBNull.Value);
            oracleParams.Add(CoverSpParams.PARAMETER_LOADING_PREC, OracleDbType.Decimal, ParameterDirection.Input, (object)cover.LoadingPrec ?? DBNull.Value);
            oracleParams.Add(CoverSpParams.PARAMETER_LOAING_AMOUNT, OracleDbType.Decimal, ParameterDirection.Input, (object)cover.LoadingAmount ?? DBNull.Value);
            oracleParams.Add(CoverSpParams.PARAMETER_EXCESS_PER, OracleDbType.Decimal, ParameterDirection.Input, (object)cover.ExcressPer ?? DBNull.Value);
            oracleParams.Add(CoverSpParams.PARAMETER_MIN_EXCESS_AMT, OracleDbType.Decimal, ParameterDirection.Input, (object)cover.MinExcessAmt ?? DBNull.Value);
            oracleParams.Add(CoverSpParams.PARAMETER_ANNUAL_LIMIT, OracleDbType.Decimal, ParameterDirection.Input, (object)cover.AnnualLimit ?? DBNull.Value);
            oracleParams.Add(CoverSpParams.PARAMETER_CASE_LIMIT, OracleDbType.Decimal, ParameterDirection.Input, (object)cover.CaseLimit ?? DBNull.Value);
            oracleParams.Add(CoverSpParams.PARAMETER_IS_CANCELED, OracleDbType.Int64, ParameterDirection.Input, (object)cover.IsCanceled ?? DBNull.Value);
            oracleParams.Add(CoverSpParams.PARAMETER_CANCEL_DATE, OracleDbType.Date, ParameterDirection.Input, (object)cover.CancelDate ?? DBNull.Value);
            oracleParams.Add(CoverSpParams.PARAMETER_NOTES, OracleDbType.Varchar2, ParameterDirection.Input, (object)cover.Notes ?? DBNull.Value);
            oracleParams.Add(CoverSpParams.PARAMETER_CREATED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)cover.CreatedBy ?? DBNull.Value, 1000);
            oracleParams.Add(CoverSpParams.PARAMETER_CREATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)cover.CreationDate ?? DBNull.Value);
            oracleParams.Add(CoverSpParams.PARAMETER_MODIFIED_BY, OracleDbType.Varchar2, ParameterDirection.Input, (object)cover.ModifiedBy ?? DBNull.Value, 1000);
            oracleParams.Add(CoverSpParams.PARAMETER_MODIFICATION_DATE, OracleDbType.Date, ParameterDirection.Input, (object)cover.ModificationDate ?? DBNull.Value);
            oracleParams.Add(CoverSpParams.PARAMETER_ST_PRD_CALC_ID, OracleDbType.Int64, ParameterDirection.Input, (object)cover.ProductCalcID ?? DBNull.Value);
            oracleParams.Add(CoverSpParams.PARAMETER_ST_LOB, OracleDbType.Int64, ParameterDirection.Input, (object)cover.StLOB ?? DBNull.Value);

            oracleParams.Add(CoverSpParams.PARAMETER_ST_SUB_LOB, OracleDbType.Int64, ParameterDirection.Input, (object)cover.StSubLOB ?? DBNull.Value);
            oracleParams.Add(CoverSpParams.PARAMETER_UW_DOC_ID, OracleDbType.Int64, ParameterDirection.Input, (object)cover.UwDocumentID ?? DBNull.Value);
            oracleParams.Add(CoverSpParams.PARAMETER_UW_RISK_ID, OracleDbType.Int64, ParameterDirection.Input, (object)cover.UwRiskID ?? DBNull.Value);
            oracleParams.Add(CoverSpParams.PARAMETER_ST_CUR_CODE, OracleDbType.Varchar2, ParameterDirection.Input, (object)cover.CurrencyCode ?? DBNull.Value);
            oracleParams.Add(CoverSpParams.PARAMETER_MANUAL_AMOUNT, OracleDbType.Decimal, ParameterDirection.Input, (object)cover.ManualAmount ?? DBNull.Value);
            oracleParams.Add(CoverSpParams.PARAMETER_MANUAL_AMOUNT_LC, OracleDbType.Decimal, ParameterDirection.Input, (object)cover.ManualAmountLc ?? DBNull.Value);
            oracleParams.Add(CoverSpParams.PARAMETER_APPLY_COMMISSION, OracleDbType.Int64, ParameterDirection.Input, (object)cover.ApplyCommission ?? DBNull.Value);
            oracleParams.Add(CoverSpParams.PARAMETER_MIN_AMOUNT, OracleDbType.Decimal, ParameterDirection.Input, (object)cover.MinAmount ?? DBNull.Value);
            oracleParams.Add(CoverSpParams.PARAMETER_ST_PRD_CH_ID, OracleDbType.Int64, ParameterDirection.Input, (object)cover.ProductChargeID ?? DBNull.Value);
            oracleParams.Add(CoverSpParams.PARAMETER_ST_SBT_ID, OracleDbType.Int64, ParameterDirection.Input, (object)cover.StSbtId ?? DBNull.Value);
            oracleParams.Add(CoverSpParams.PARAMETER_NUMBER_OF_MEMBERS, OracleDbType.Int64, ParameterDirection.Input, (object)cover.NumberOfMembers ?? DBNull.Value);
            oracleParams.Add(CoverSpParams.PARAMETER_TOATAL_PREMIUM_LC, OracleDbType.Decimal, ParameterDirection.Input, (object)cover.TotalPremiumLc ?? DBNull.Value);
            oracleParams.Add(CoverSpParams.PARAMETER_TOATAL_PREMIUM, OracleDbType.Decimal, ParameterDirection.Input, (object)cover.TotalPremium ?? DBNull.Value);



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
