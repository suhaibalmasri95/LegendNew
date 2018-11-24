using Common.Interfaces;
using Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Organization
{
    [DBTableName("ST_GROUP_RELATIONS")]
    public class GroupRelation : IBase
    {
        [DBPrimaryKey]
        [DBFiledName("ID")]
        public long? ID { get; set; }
        [DBFiledName("LangID")]
        public long? LangID { get; set; }
        [DBFiledName("ST_GRP_ID")]
        public long? GroupID { get; set; }
        [DBFiledName("GRPNAME")]
        public string GroupName { get; set; }
        [DBFiledName("LOCK_GRP_CAT")]
        public long? LockUpGroupCat { get; set; }
        [DBFiledName("REF_ID")]
        public long? RefrenceID { get; set; }
        [DBFiledName("REF_IDs")]
        public long[] RefrenceIDs { get; set; }
    }
}
