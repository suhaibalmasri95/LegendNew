using System;
using Common.Interfaces;
using Infrastructure.Attributes;

namespace Domain.Entities.Production
{
    [DBTableName("ST_PRD_PRICING_DETAILS")]
    public class PricingDetail : IEntity
    {
        [DBFiledName("NAME")]
        public string Name { get; set; }
        [DBFiledName("NAME2")]
        public string Name2 { get; set; }
        [DBFiledName("LangID")]
        public long? LangID { get; set; }
        [DBFiledName("ID")]
        public long? ID { get; set; }
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
        [DBFiledName("ST_PRD_ID")]
        public long? ProductID { get; set; }
        [DBFiledName("EFFECTIVE_DATE")]
        public DateTime? EffectiveDate { get; set; }
        [DBFiledName("EXPIRY_DATE")]
        public DateTime? ExpiryDate { get; set; }
        [DBFiledName("LOC_PRICE_TYPE")]
        public long? LocPricingType { get; set; }
        [DBFiledName("FIN_CST_ID")]
        public long? CustomerID { get; set; }
        [DBFiledName("ST_PRDT_ID")]
        public long? ProductDetailID { get; set; }
        [DBFiledName("ST_LOB")]
        public long? LineOfBusiness { get; set; }
        [DBFiledName("ST_SUB_LOB")]
        public long? SubLineOfBusiness { get; set; }
        [DBFiledName("IS_FACTOR")]
        public long? IsFactor { get; set; }
        [DBFiledName("ST_PRD_PRIC_ID")]
        public long? PricingID { get; set; }

    }
}
