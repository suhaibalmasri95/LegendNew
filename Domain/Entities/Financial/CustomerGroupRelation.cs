using Common.Interfaces;
using Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Financial
{
    [DBTableName("FIN_PART_GRP_DETAILS")]
    public class CustomerGroupRelation : IEntity
    {
        [DBFiledName("CREATED_BY")]
        public string CreatedBy { get; set; }
        [DBFiledName("CREATION_DATE")]
        public DateTime CreationDate { get; set; }
        [DBFiledName("MODIFIED_BY")]
        public string ModifiedBy { get; set; }
        [DBFiledName("MODIFICATION_DATE")]
        public DateTime ModificationDate { get; set; }
        [DBFiledName("NAME")]
        public string Name { get; set; }
        [DBFiledName("NAME2")]
        public string Name2 { get; set; }
        [DBFiledName("LangID")]
        public long? LangID { get; set; }
        [DBPrimaryKey]
        [DBFiledName("ID")]
        public long? ID { get; set; }

        [DBFiledName("FIN_CST_ID")]
        public long? CustomerID { get; set; }
        [DBFiledName("ST_PRDT_ID")]
        public long? ProductDetailId { get; set; }

        [DBFiledName("LOC_UNITT")]
        public long? LocUnit { get; set; }

        [DBFiledName("PRICE_AMOUNT")]
        public long? PriceAmount { get; set; }

        [DBFiledName("FREQ")]
        public long? Freq { get; set; }

        [DBFiledName("REF_NO")]
        public long? ReferenceNo { get; set; }
    }
}
