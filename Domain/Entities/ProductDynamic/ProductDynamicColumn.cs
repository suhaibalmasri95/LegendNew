using Common.Interfaces;
using Domain.Entities.Organization;
using Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.ProductDynamic
{
    
    [DBTableName("ST_PRD_COLUMNS")]
    public class ProductDynamicColumn : IEntity
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
        [DBFiledName("COL_TYPE")]
        public long? ColumnType { get; set; }
        [DBFiledName("ST_LOB")]
        public long? LineOfBuisness { get; set; }
        [DBFiledName("ST_SUB_LOB")]
        public long? SubLineOfBuisness { get; set; }
        [DBFiledName("LOC_LEVEL")]
        public long? LockUpLevel { get; set; }
        [DBFiledName("ST_PRD_CLO_ID")]
        public long? ParentID { get; set; }
        [DBFiledName("ST_PRD_CAT_ID")]
        public long? ProductCategoryID { get; set; }
        [DBFiledName("ST_CAT_ID")]
        public long? CategoryID { get; set; }
        [DBFiledName("ST_PRD_ID")]
        public long? ProductID { get; set; }
        [DBFiledName("ST_PRDT_ID")]
        public long? ProductDetailID { get; set; }
        [DBFiledName("ST_COL_ID")]
        public long? ColumnOrder { get; set; }
        [DBFiledName("ST_DIC_ID")]
        public long? Dictionary { get; set; }
        [DBFiledName("ST_DIC_COL_ID")]
        public long? DictionaryColumnID { get; set; }
        [DBFiledName("REF_TABLE")]
        public string ReferenceTable { get; set; }
        [DBFiledName("WHERE_COND")]
        public string WhereCondition { get; set; }
        [DBFiledName("UW_COL_CAT_ID")]
        public long? UnderWritingColCatID { get; set; }
        [DBFiledName("ST_PRD_COL_ID")]
        public long? UnderWritingProductColumnID { get; set; }
        [DBFiledName("VALUE_DATE")]
        public DateTime? ValueDate { get; set; }
        [DBFiledName("VALUE_DATE")]
        public double? ValueAmount { get; set; }
        [DBFiledName("VALUE_DESC")]
        public string ValueDesc  { get; set; }
        [DBFiledName("VAL_LOC_ID")]
        public long? ValueLockUpID { get; set; }
        [DBFiledName("UW_RISK_ID")]
        public long? UnderWritingRiskID { get; set; }
        [DBFiledName("UW_DOC_ID")]
        public long? UnderWritingDocID { get; set; }
        [DBFiledName("ExecludedColumn")]
        public long? ExecludedColumn { get; set; }
      
        
    }
}
