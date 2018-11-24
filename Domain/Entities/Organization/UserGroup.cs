using Common.Interfaces;
using Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Organization
{
    [DBTableName("ST_USER_RELATIONS")]
    public class UserGroup : IBase
    {
        [DBPrimaryKey]
        [DBFiledName("ID")]
        public long? ID { get; set; }
        [DBFiledName("USER_ID")]
        public long? UserID { get; set; }
        [DBFiledName("USER_IDs")]
        public long[] UserIDs { get; set; }
        [DBFiledName("LangID")]
        public long? LangID { get; set; }
        [DBFiledName("LOCK_USER_CAT")]
        public long? UserRelationID { get; set; }
        [DBFiledName("GroupIDs")]
        public long[] GroupIDs { get; set; }
        [DBFiledName("USERNAME")]
        public string UserName { get; set; }
        [DBFiledName("USERNAMES")]
        public string[] UserNames { get; set; }
        [DBFiledName("REF_ID")]
        public long RefrenceID { get; set; }
        [DBFiledName("REF_IDs")]
        public long[] RefrenceIDs { get; set; }
    
    }
}
