using System;
using Common.Interfaces;
using Infrastructure.Attributes;

namespace Domain.Entities.Production
{
    [DBTableName("ST_DICTIONARY_COLS")]
    public class DictionaryColumn : IEntity
    {
   [DBFiledName("NAME")]
        public string Name { get; set; }
        [DBFiledName("NAME2")]
        public string Name2 { get; set; }
        [DBFiledName("LangID")]
        public long? LangID { get; set; }
        [DBFiledName("ID")]
        public long? ID { get; set; }

        [DBFiledName("TABLE_TYPE")]
        public long? TableType { get; set; }
        [DBFiledName("RFE_TABLE_NAME")]
        public string RefTableName { get; set; }
        [DBFiledName("REF_COULMN_NAME")]
        public string RefColumnName { get; set; }
        [DBFiledName("REF_COL_POINTER")]
        public string RefColPointer { get; set; }
        [DBFiledName("LABEL")]
        public string Label { get; set; }
        [DBFiledName("LABEL2")]
        public string Label2 { get; set; }
        [DBFiledName("ST_DIC_ID")]
        public long? DictionaryID { get; set; }
        [DBFiledName("CREATED_BY")]
        public string CreatedBy { get; set; }
        [DBFiledName("CREATION_DATE")]
        public DateTime? CreateDate { get; set; }
        [DBFiledName("MODIFIED_BY")]
        public string ModifiedBy { get; set; }
        [DBFiledName("MODIFICATION_DATE")]
        public DateTime? ModificationDate { get; set; }
        [DBFiledName("ST_LOB")]
        public long? LineOfBusiness { get; set; }
        [DBFiledName("ST_SUB_LOB")]
        public long? SubLineOfBusiness { get; set; }
        [DBFiledName("REF_DAYN_TABLE")]
        public string RefDaynTable { get; set; }
        [DBFiledName("REF_COL_VLAUES")]
        public string RefColValues { get; set; }
        [DBFiledName("QUREY")]
        public string Query { get; set; }
    }
}
