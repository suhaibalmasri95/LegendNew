using Common.Interfaces;
using Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.ProductSetup
{
    
         [DBTableName("ST_PRD_COLUMNS_CATGORY")]
    public class ProductCategory : IEntity
    {
        [DBPrimaryKey]
        [DBFiledName("ID")]
        public long? ID { get; set; }
        [DBFiledName("NAME")]
        public string Name { get; set; }
        [DBFiledName("NAME2")]
        public string Name2 { get; set; }
        [DBFiledName("LangID")]
        public long? LangID { get; set; }
        [DBFiledName("LABLE")]
        public string Lable { get; set; }
        [DBFiledName("LABLE2")]
        public string Lable2 { get; set; }
        [DBFiledName("ST_LOB")]
        public long? LineOfBusniess { get; set; }
        [DBFiledName("ST_SUB_LOB")]
        public long? SubLineOfBusniess { get; set; }
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
        public DateTime ModificationDate { get; set; }
        [DBFiledName("CAT_LEVEL")]
        public long? CategoryLevel { get; set; }
        [DBFiledName("IS_MULTI_RECORDS")]
        public Int16? MultiRecord { get; set; }

        [DBFiledName("ST_CAT_ID")]
        public long? CategoryID { get; set; }
        [DBFiledName("ST_PRD_ID")]
        public long? ProductID { get; set; }
        [DBFiledName("ST_PRDT_ID")]
        public long? ProductDetailID { get; set; }
        [DBFiledName("COL_ORDER")]
        public Int16? Order { get; set; }
        [DBFiledName("ST_DIC_ID")]
        public long? DictionaryID { get; set; }

    }

}
