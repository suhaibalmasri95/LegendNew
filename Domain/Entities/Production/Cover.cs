using Common.Interfaces;
using Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Production
{
    [DBTableName("UW_CALC")]
    public class Cover : IEntity
    {
        [DBFiledName("LangID")]
        public long? LangID { get; set; }
        [DBFiledName("ID")]
        public long? ID { get; set; }
        [DBFiledName("SERIAL")]
        public long? Serial { get; set; }
        [DBFiledName("NAME")]
        public string Name { get; set; }
        [DBFiledName("NAME2")]
        public string Name2 { get; set; }
        [DBFiledName("RATE")]
        public double? Rate { get; set; }
        [DBFiledName("LOC_CHARG_TYPE")]
        public long? ChargeType { get; set; }
        [DBFiledName("EXPIRY_DATE")]
        public DateTime? ExpiryDate { get; set; }
        [DBFiledName("EXRATE")]
        public double? Exrate { get; set; }
        [DBFiledName("GROSS_AMOUNT")]
        public double? GrossAmount { get; set; }
        [DBFiledName("GROSS_AMOUNT_LC")]
        public double? GrossAmountLc { get; set; }
        [DBFiledName("NET_AMOUNT")]
        public double? NetAmount { get; set; }
        [DBFiledName("NET_AMOUNT_LC")]
        public double? NetAmountLc { get; set; }
        [DBFiledName("ST_LOB")]
        public long? StLOB { get; set; }
        [DBFiledName("ST_SUB_LOB")]
        public long? StSubLOB { get; set; }
        [DBFiledName("UW_DOC_ID")]
        public long? UwDocumentID { get; set; }
        [DBFiledName("SUMINSURED_LC")]
        public double? SuminsuredLC { get; set; }
        [DBFiledName("SUMINSURED")]
        public double? Suminsured { get; set; }
        [DBFiledName("DISCOUNT_PREC")]
        public double? DiscountPrec { get; set; }
        [DBFiledName("DISCOUNT_AMOUNT")]
        public double? DiscountAmount { get; set; }
        [DBFiledName("LOADING_PREC")]
        public double? LoadingPrec { get; set; }
        [DBFiledName("LOAING_AMOUNT")]
        public double? LoadingAmount { get; set; }
        [DBFiledName("EXCESS_PER")]
        public double? ExcressPer { get; set; }
        [DBFiledName("MIN_EXCESS_AMT")]
        public double? MinExcessAmt { get; set; }
        [DBFiledName("ANNUAL_LIMIT")]
        public double? AnnualLimit { get; set; }
        [DBFiledName("CASE_LIMIT")]
        public double? CaseLimit { get; set; }
        [DBFiledName("IS_CANCELED")]
        public Int16? IsCanceled { get; set; }
        [DBFiledName("CREATED_BY")]
        public string CreatedBy { get; set; }
        [DBFiledName("CREATION_DATE")]
        public DateTime CreationDate { get; set; }
        [DBFiledName("MODIFIED_BY")]
        public string ModifiedBy { get; set; }
        [DBFiledName("MODIFICATION_DATE")]
        public DateTime ModificationDate { get; set; }
        [DBFiledName("UW_RISK_ID")]
        public long? UwRiskID { get; set; }


        [DBFiledName("CANCEL_DATE")]
        public DateTime? CancelDate { get; set; }
        [DBFiledName("NOTES")]
        public string Notes { get; set; }
        [DBFiledName("ST_PRD_CALC_ID")]
        public long? ProductCalcID { get; set; }
        [DBFiledName("ST_CUR_CODE")]
        public string CurrencyCode { get; set; }
        [DBFiledName("MANUAL_AMOUNT_LC")]
        public double? ManualAmountLc { get; set; }
        [DBFiledName("MANUAL_AMOUNT")]
        public double? ManualAmount { get; set; }
        [DBFiledName("APPLY_COMMISSION")]
        public Int16? ApplyCommission { get; set; }
        [DBFiledName("MIN_AMOUNT")]
        public double? MinAmount { get; set; }
        [DBFiledName("ST_PRD_CH_ID")]
        public long? ProductChargeID { get; set; }
        [DBFiledName("ST_SBT_ID")]
        public long? StSbtId { get; set; }
        [DBFiledName("NUMBER_OF_MEMBERS")]
        public long? NumberOfMembers { get; set; }
        [DBFiledName("TOATAL_PREMIUM_LC")]
        public double? TotalPremiumLc { get; set; }
        [DBFiledName("TOATAL_PREMIUM")]
        public double? TotalPremium { get; set; }
        [DBFiledName("ST_LOB_DESC")]
        public String LineOfBusiness { get; set; }
        [DBFiledName("ST_SUB_LOB_DESC")]
        public string SubLineOfBusiness { get; set; }
        [DBFiledName("UW_RISK_ID_DESC")]
        public String RiskName { get; set; }
        [DBFiledName("ST_PRD_CH_ID_DESC")]
        public string CoverName { get; set; }

        [DBFiledName("FeeAmountLc")]
        public double? FeeAmountLc => ManualAmountLc;
        [DBFiledName("FeeAmount")]
        public double? FeesAmount => ManualAmount;

    }
}
