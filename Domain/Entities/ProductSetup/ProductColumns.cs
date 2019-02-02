using Common.Interfaces;
using Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.ProductSetup
{
    [DBTableName("ST_PRD_COLUMNS")]
    public class ProductColumns : IEntity
    {
     
        [DBFiledName("NAME")]
        public string Name { get; set; }
        [DBFiledName("NAME2")]
        public string Name2 { get; set; }
        [DBFiledName("LangID")]
        public long? LangID { get; set; }

        [DBPrimaryKey]
        [DBFiledName("ID")]
        public long? ID { get; set; }

        [DBFiledName("LABLE")]
        public string Lable { get; set; }
        [DBFiledName("LABLE2")]
        public string Lable2 { get; set; }
        [DBFiledName("STATUS")]
        public long? Status { get; set; }
        [DBFiledName("STATUS_DATE")]
        public DateTime StatusDate { get; set; }

        [DBFiledName("COM_TYPE")]
        public long? ColumnType { get; set; }
        [DBFiledName("ST_LOB")]
        public long? LineOfBusniess { get; set; }
        [DBFiledName("ST_SUB_LOB")]
        public long? SubLineOfBusniess { get; set; }
        [DBFiledName("CREATED_BY")]
        public string CreateBy { get; set; }
        [DBFiledName("CREATION_DATE")]
        public DateTime CreationDate { get; set; }
        [DBFiledName("MODIFIED_BY")]
        public string ModifiedBy { get; set; }
        [DBFiledName("MODIFICATION_DATE")]
        public DateTime ModificationDate { get; set; }

        [DBFiledName("ST_CAT_ID")]
        public long? CategoryID { get; set; }
        [DBFiledName("RFE_TABLE_NAME")]
        public string RefTableName { get; set; }
        [DBFiledName("REF_MAJOR_CODE")]
        public long? RefMajorCode { get; set; }
        [DBFiledName("REF_COL_DT_ID")]
        public long? RefColDetailsID { get; set; }
        [DBFiledName("ST_PRD_CAT_ID")]
        public long? ProductCategoryID { get; set; }
        [DBFiledName("ST_PRD_CLO_ID")]
        public long? PrdColumnID { get; set; }
        [DBFiledName("ST_COL_ID")]
        public long? ColumnID { get; set; }
        [DBFiledName("ST_PRD_ID")]
        public long? ProductID { get; set; }
        [DBFiledName("ST_PRDT_ID")]
        public long? ProductDetailID { get; set; }
        [DBFiledName("COL_ORDER")]
        public long? Order { get; set; }
        [DBFiledName("ST_DIC_ID")]
        public long? DictionaryID { get; set; }
        [DBFiledName("ST_DIC_COL_ID")]
        public long? DictionaryColumnID { get; set; }
        [DBFiledName("LOC_LEVEL")]
        public long? LocLevel { get; set; }
        [DBFiledName("WHERE_COND")]
        public string WhereCondition { get; set; }
        [DBFiledName("REF_TABLE ")]
        public string RefTable { get; set; }
        [DBFiledName("ST_LOB_DESC")]
        public string LineDesc { get; set; }
        [DBFiledName("ST_SUB_LOB_DESC")]
        public string SubLineDesc { get; set; }
        [DBFiledName("COL_TYPE_DESC")]
        public string ColumnTypeDesc { get; set; }
        [DBFiledName("LOC_LEVEL_DESC")]
        public string LocLevelDesc { get; set; }
        [DBFiledName("ST_CAT_ID_DESC")]
        public string CategoryDesc { get; set; }
        [DBFiledName("ST_PRD_ID_DESC")]
        public string ProductDesc { get; set; }
        [DBFiledName("ST_COL_ID_DESC")]
        public string ColumnDesc { get; set; }
        [DBFiledName("ST_PRD_CLO_ID_DESC")]
        public string ProductColumnDesc { get; set; }


    }
}
