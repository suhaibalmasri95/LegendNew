using Common.Interfaces;
using Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Setup
{
    [DBTableName("ST_SUBJECT_TYPE")]
    public class Diagnosis : IEntity
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
        [DBFiledName("LOC_CODING_SYSTEM")]
        public long? CodeingSystem { get; set; }
        [DBFiledName("ST_ICD_SVC_ID")]
        public long? Parent { get; set; }
        [DBFiledName("GENDER")]
        public long? Gender { get; set; }
        [DBFiledName("AGE_FROM")]
        public long? AgeFrom { get; set; }
        [DBFiledName("AGE_TO")]
        public long? AgeTo { get; set; }
        [DBFiledName("FREQUENCY")]
        public long? Frequency { get; set; }
        [DBFiledName("UNIT")]
        public long? FrequencyUnit { get; set; }
        [DBFiledName("IS_CHRONIC")]
        public long? IsChronic { get; set; }
        [DBFiledName("LOC_SERVICE_TYPE")]
        public long? ServiceType { get; set; }
        [DBFiledName("IS_ICD_SERV_BEN")]
        public long? IS_ICD_SERV_BEN { get; set; }
    }
}
