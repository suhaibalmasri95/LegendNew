using Common.Interfaces;
using Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Setup
{
    [DBTableName("ST_SUBJECT_TYPE")]
    public class SubjectType : IEntity
    {
        public SubjectType()
        {
            
            CreationDate = DateTime.Now;
            ModificationDate = DateTime.Now;
            CreatedBy = "ADMIN";
            ModifiedBy = "ADMIN";
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

        [DBFiledName("ST_LOB")]
        public long? LineOfBusniessID { get; set; }
        [DBFiledName("ST_SUB_LOB")]
        public long? SubLineOfBusniessID { get; set; }
        [DBFiledName("ST_SBT_ID")]
        public long? Parent { get; set; }
        [DBFiledName("EXCESS_PER")]
        public double ExcessPercentage { get; set; }
        [DBFiledName("MIN_EXCESS_AMT")]
        public double MinExcessAmount { get; set; }
        [DBFiledName("MAX_EXCESS_AMT")]
        public double MaxExcessAmount { get; set; }
        [DBFiledName("CREATED_BY")]
        public string CreatedBy { get; set; }
        [DBFiledName("CREATION_DATE")]
        public DateTime CreationDate { get; set; }
        [DBFiledName("EXCESS_FROM")]
        public long? From { get; set; }
        [DBFiledName("MODIFIED_BY")]
        public string ModifiedBy { get; set; }
        [DBFiledName("MODIFICATION_DATE")]
        public DateTime ModificationDate { get; set; }
    }
}
