using Common.Interfaces;
using Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Setup
{
    [DBTableName("ST_COLUMNS")]
    public class Column : IEntity
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
        public string Label { get; set; }
        [DBFiledName("LABLE2")]
        public string Label2 { get; set; }
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
        public long? RefTableName { get; set; }
        [DBFiledName("REF_MAJOR_CODE")]
        public long? RefMajorCode { get; set; }
        [DBFiledName("REF_COL_DT_ID")]
        public long? RefColDetailsID { get; set; }


    }
}
