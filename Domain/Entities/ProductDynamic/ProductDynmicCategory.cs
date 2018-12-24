using Common.Interfaces;
using Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.ProductDynamic
{
    [DBTableName("ST_PRD_COLUMNS_CATGORY")]
    public class ProductDynmicCategory : IEntity
    {
        [DBFiledName("Name")]
        public string Name { get; set; }
        [DBFiledName("Name2")]
        public string Name2 { get; set; }
        [DBFiledName("LangID")]
        public long? LangID { get; set; }
        [DBPrimaryKey]
        [DBFiledName("ID")]
        public long? ID { get; set; }
        [DBFiledName("ST_CAT_ID")] 
        public long? CategoryID { get; set; }
        [DBFiledName("LABLE")]
        public string Lable { get; set; }
        [DBFiledName("LABLE2")]
        public string Lable2 { get; set; }
        [DBFiledName("STATUS")]
        public long? Status { get; set; }
        [DBFiledName("STATUS_DATE")]
        public DateTime StatusDate { get; set; }
        [DBFiledName("CREATED_BY")]
        public string CreatedBy { get; set; }
        [DBFiledName("CREATION_DATE")]
        public DateTime CreationDate { get; set; }
        [DBFiledName("MODIFIED_BY")]
        public string ModifiedBy { get; set; }
        [DBFiledName("MODIFICATION_DATE")]
        public DateTime ModificationDate { get; set; }
        [DBFiledName("CAT_LEVEL")]
        public long? CategoryLevel { get; set; }
        [DBFiledName("IS_MULTI_RECORDS")]
        public Int16? IsMulitRecords { get; set; }
        [DBFiledName("ST_PRD_ID")]
        public long? ProductID { get; set; }
        [DBFiledName("ST_PRDT_ID")]
        public long? ProductDetailID { get; set; }
        [DBFiledName("COL_ORDER")]
        public Int16? OrderID { get; set; }
        [DBFiledName("ST_DIC_ID")]
        public long? Dictionary { get; set; }
        [DBFiledName("ST_LOB")]
        public long? LineOfBuisness { get; set; }
        [DBFiledName("ST_SUB_LOB")]
        public long? SubLineOfBuisness { get; set; }
        [DBFiledName("Columns")]
        public List<ProductDynamicColumn> Columns { get; set; }
        [DBFiledName("Lists")]
        public List<ProductDynamicColumn> Lists { get; set; }
    }


}
