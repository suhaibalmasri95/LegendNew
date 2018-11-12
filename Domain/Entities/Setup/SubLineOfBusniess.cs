using Common.Interfaces;
using Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Setup
{
    [DBTableName("ST_SUB_LOB")]
    public class SubLineOfBusnies : IEntity
    {
        [DBPrimaryKey]
        [DBFiledName("ID")]
        public long? ID { get; set; }
        [DBFiledName("")]
        public long? LangID { get; set; }
        [DBFiledName("NAME")]
        public string Name { get; set; }
        [DBFiledName("NAME2")]
        public string Name2 { get; set; }
        [DBFiledName("CODE")]
        public string Code { get; set; }
        [DBFiledName("ST_LOB_ID")]
        public string LineOfBusniess { get; set; }
        [DBFiledName("SUB_LOB")]
        public string BasicLineOfBusniess { get; set; }
        [DBFiledName("RINS_TYPE")]
        public string ReinsType { get; set; }
        [DBFiledName("LOC_STATUS")]
        public string Status { get; set; }
        [DBFiledName("STATUS_DATE")]
        public DateTime StatusDate { get; set; }
        [DBFiledName("CREATED_BY")]
        public string CreatedBy { get; set; }
        [DBFiledName("CREATION_DATE")]
        public DateTime CreationDate { get; set; }
        [DBFiledName("MODIFIED_BY")]
        public string ModifiedBy { get; set; }
        [DBFiledName("MODIFICATION_DATE")]
        public string ModificationDate { get; set; }
    }
}
