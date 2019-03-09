using System;
using Common.Interfaces;
using Infrastructure.Attributes;

namespace Domain.Entities.Production
{
    [DBTableName("ST_PRD_FACTORS")]
    public class Factor : IEntity
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
        public long? ProductFactorID { get; set; }
    }
}
