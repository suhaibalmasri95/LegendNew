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
        public SubLineOfBusnies()
        {
            StatusDate = DateTime.Now;
            CreationDate = DateTime.Now;
            ModificationDate = DateTime.Now;
            CreatedBy = "ADMIN";
            ModifiedBy = "ADMIN";
        }
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
        public long? LineOfBusniess { get; set; }
        [DBFiledName("SUB_LOB")]
        public long? BasicLineOfBusniess { get; set; }
        [DBFiledName("RINS_TYPE")]
        public long? ReinsType { get; set; }
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
    }
}
