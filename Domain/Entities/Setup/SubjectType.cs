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
        [DBPrimaryKey]
        [DBFiledName("ID")]
        public long? ID { get; set; }
        [DBFiledName("NAME")]
        public string Name { get; set; }
        [DBFiledName("NAME2")]
        public string Name2 { get; set; }
        [DBFiledName("LangID")]
        public long? LangID { get; set; }
        [DBFiledName("ST_LOB_ID")]
        public long LineOfBusniessID;
        [DBFiledName("ST_SUB_LOB_ID")]
        public long SubLineOfBusniessID;
        [DBFiledName("ST_SBT_ID")]
        public string Parent;
        [DBFiledName("EXCESS_PER")]
        public int ExcessPercentage;
        [DBFiledName("MIN_EXCESS_AMT")]
        public int MinExcessAmount;
        [DBFiledName("MAX_EXCESS_AMT")]
        public int MaxExcessAmount;
        [DBFiledName("CREATED_BY")]
        public string CreatedBy { get; set; }
        [DBFiledName("CREATION_DATE")]
        public DateTime CreationDate { get; set; }
        [DBFiledName("EXCESS_FROM")]
        public string From { get; set; }
    }
}
