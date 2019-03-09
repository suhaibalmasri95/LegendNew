using System;
using Common.Interfaces;
using Infrastructure.Attributes;

namespace Domain.Entities.Production
{
    [DBTableName("ST_PRD_FAC_DETAILS")]
    public class FactorDetail : IEntity
    {
        [DBFiledName("NAME")]
        public string Name { get; set; }
        [DBFiledName("NAME2")]
        public string Name2 { get; set; }
        [DBFiledName("LangID")]
        public long? LangID { get; set; }
        [DBFiledName("ID")]
        public long? ID { get; set; }
        [DBFiledName("FACT_TYPE")]
        public long? FactorType { get; set; }

        [DBFiledName("ST_PRD_PRCD_ID")]
        public long? PricingID { get; set; }

        [DBFiledName("ST_DIC_COL_ID")]
        public long? DictionaryID { get; set; }
        [DBFiledName("ENTRY_TYPE")]
        public long? EntryType { get; set; }
        [DBFiledName("ST_PRD_FACT_ID")]
        public long? FactorID { get; set; }


        [DBFiledName("FROM_VALUE")]
        public long? FromValue { get; set; }

        [DBFiledName("TO_VALUE")]
        public long? ToValue { get; set; }
        [DBFiledName("F_FROM_DATE ")]
        public DateTime? FromDate { get; set; }
        [DBFiledName("F_TO_DATE")]
        public DateTime? ToDate { get; set; }

        [DBFiledName("ST_CHG_ID")]
        public long? ChargeID { get; set; }

        [DBFiledName("ST_PRD_ID")]
        public long? ProductID { get; set; }
        [DBFiledName("ST_PRDT_ID ")]
        public long? ProductDetailID { get; set; }
        [DBFiledName("FRRMULA_EDOTORS")]
        public string FrrmulaEdotors { get; set; }
        [DBFiledName("ST_PRD_FACD_ID")]
        public long? ProductFacdID { get; set; }

        [DBFiledName("ST_PRD_PRIC_ID")]
        public long? ProductPricID{ get; set; }

    }
}
