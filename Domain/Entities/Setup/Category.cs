using Common.Interfaces;
using Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Setup
{
    [DBTableName("ST_COLUMNS_CATGORY")]
    public class Category : IEntity
    {
        public Category()
        {
            ModificationDate = DateTime.Now;
            CreationDate = DateTime.Now;
            CreateBy = "Admin";
            ModifiedBy = "Admin";
            StatusDate = DateTime.Now;
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
        [DBFiledName("LABLE")]
        public string Label { get; set; }
        [DBFiledName("LABLE2")]
        public string Label2 { get; set; }
        [DBFiledName("ST_LOB_ID")]
        public long? LineOfBusniess { get; set; }
        [DBFiledName("ST_SUB_LOB_ID")]
        public long? SubLineOfBusniess { get; set; }
        [DBFiledName("STATUS")]
        public int Status { get; set; }
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
        public Int32? MultiRecord { get; set; }
    }
}
