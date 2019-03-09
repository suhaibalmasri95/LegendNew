using System;
using Common.Interfaces;
using Infrastructure.Attributes;

namespace Domain.Entities.Production
{
   [DBTableName("ST_DISCTIONARY")]
    public class Dictionary : IEntity
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
   
    }
}
