using System;
using Common.Interfaces;
using Infrastructure.Attributes;

namespace Domain.Entities.ProductSetup
{
    [DBTableName("INS_ST_PRD_CHARGES")]
    public class ProductCharges : IEntity
    {
        [DBFiledName("NAME")]
        public string Name { get; set; }
        [DBFiledName("NAME2")]
        public string Name2 { get; set; }
        [DBFiledName("LangID")]
        public long? LangID { get; set; }
        [DBFiledName("ID")]
        public long? ID { get; set; }
        [DBFiledName("SERIAL")]
        public double? Serial { get; set; }
        [DBFiledName("FACTOR_TYPE")]
        public long? FactorType { get; set; }
        [DBFiledName("NET_AMOUNT")]
        public double? NetAmount { get; set; }

        [DBFiledName("LOADING_PER")]
        public double? LoadingPercent { get; set; }
        [DBFiledName("DISCOUNT_PER")]
        public double? DiscountPercent { get; set; }
        [DBFiledName("GROSS_AMOUNT")]
        public double? GrossAmount { get; set; }


        [DBFiledName("RATE")]
        public double? Rate { get; set; }

        [DBFiledName("MIN_AMOUNT")]
        public double? MinAmount { get; set; }
        [DBFiledName("MAX_AMOUNT ")]
        public double? MaxAmount { get; set; }
        [DBFiledName("EXCESS_PER")]
        public double? ExcessPercent { get; set; }

        [DBFiledName("EXCESS_AMOUNT")]
        public double? ExcessAmount { get; set; }

        [DBFiledName("AGGREGATED_LIMIT")]
        public double? AggregatedLimit { get; set; }
        [DBFiledName("CASE_LIMIT ")]
        public double? CaseLimit { get; set; }
        [DBFiledName("APPLY_AGENT_COMM")]
        public Int16? ApplyAgentComm { get; set; }
        [DBFiledName("ST_LOB")]
        public long? LineOfBusiness { get; set; }
        [DBFiledName("ST_SUB_LOB")]
        public long? SubLineOfBusiness { get; set; }



        [DBFiledName("IS_EDITABLE")]
        public Int16? IsEditable { get; set; }
        [DBFiledName("ST_PRD_PRCD_ID ")]
        public Int16? PricingID { get; set; }
        [DBFiledName("DR_CR")]
        public Int16? DrCr { get; set; }

        [DBFiledName("LOC_CHARG_TYPE")]
        public Int16? LocChargeType { get; set; }

        [DBFiledName("IS_DISCOUNTABLE ")]
        public Int16? IsDiscountable { get; set; }
        [DBFiledName("IS_REINSURANCE ")]
        public Int16? IsReinsurance { get; set; }
        [DBFiledName("IS_BASIC")]
        public Int16? IsBasic { get; set; }
        [DBFiledName("IS_AUTOFILL")]
        public Int16? IsAutoFill { get; set; }
        [DBFiledName("IS_APPLY_PREMIUM")]
        public Int16? IsApplyPremium { get; set; }


        [DBFiledName("ST_CHG_ID ")]
        public long? ChargeID { get; set; }
        [DBFiledName("ST_PRD_ID")]
        public long? ProductID { get; set; }

        [DBFiledName("ST_PRDT_ID")]
        public long? ProductDetaiID { get; set; }


        [DBFiledName("ST_SBT_ID ")]
        public long? SbtID { get; set; }
        [DBFiledName("ST_DIC_COL_ID")]
        public long? Dictionary { get; set; }

        [DBFiledName("WHERE_COND")]
        public string WhereCondition { get; set; }

        [DBFiledName("CREATED_BY")]
        public string CreatedBy { get; set; }
        [DBFiledName("CREATION_DATE")]
        public DateTime? CreationDate { get; set; }
        [DBFiledName("MODIFIED_BY")]
        public string ModifiedBy { get; set; }
        [DBFiledName("MODIFICATION_DATE")]
        public DateTime? ModificationDate { get; set; }
        [DBFiledName("STATUS")]
        public long? Status { get; set; }
        [DBFiledName("STATUS_DATE")]
        public DateTime? StatusDate { get; set; }
        [DBFiledName("EFFECTIVE_DATE")]
        public DateTime? EffectiveDate { get; set; }
        [DBFiledName("EXPIRY_DATE")]
        public DateTime? ExpiryDate { get; set; }
        [DBFiledName("ST_PRD_FACT_ID")]
        public long? ProductFactorID { get; set; }

    }
}
