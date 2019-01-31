using Common.Interfaces;
using Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.ProductSetup
{
    [DBTableName("ST_UW_PRODUCTS")]
    public class Product : IEntity
    {
        public Product()
        {
         
        }

        [DBPrimaryKey]
        [DBFiledName("ID")]
        public long? ID { get; set; }
        [DBFiledName("NAME")]
        public string Name { get; set; }
        [DBFiledName("NAME2")]
        public string Name2 { get; set; }
        [DBFiledName("LangID")]
        public long? LangID { get; set; }
        [DBFiledName("LOGO")]
        public string Logo { get; set; }
        [DBFiledName("CODE")]
        public string Code { get; set; }
        [DBFiledName("STATUS")]
        public long? Status { get; set; }
        [DBFiledName("STATUS_DATE")]
        public DateTime StatusDate { get; set; }
        [DBFiledName("CREATED_BY")]
        public string CreateBy { get; set; }
        [DBFiledName("CREATION_DATE")]
        public DateTime CreationDate { get; set; }
        [DBFiledName("MODIFIED_BY")]
        public string ModifiedBy { get; set; }
        [DBFiledName("MODIFICATION_DATE")]
        public DateTime? ModificationDate { get; set; }
        [DBFiledName("EFFECTIVE_DATE")]
        public DateTime? EffectiveDate { get; set; }
        [DBFiledName("EXPIRY_DATE")]
        public DateTime? ExpiryDate { get; set; }
        [DBFiledName("LOCK_INDV_GROUP")]
        public long? LockIndvGroup { get; set; }
        [DBFiledName("ST_COM_ID")]
        public long? CompanyID { get; set; }
        [DBFiledName("FIN_CST_ID")]
        public long? FCustomerID { get; set; }
    }
}
