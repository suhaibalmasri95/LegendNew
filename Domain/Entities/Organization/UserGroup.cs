using Common.Interfaces;
using Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Organization
{
    public class UserGroup : IBase
    {
        [DBFiledName("ID")]
        public long? ID { get; set; }
        [DBFiledName("USER_ID")]
        public long? UserID { get; set; }
        [DBFiledName("LangID")]
        public long? LangID { get; set; }
        [DBFiledName("LOCK_USER_CAT")]
        public long? UserRelationID { get; set; }
        [DBFiledName("USERNAME")]
        public string UserName { get; set; }
        [DBFiledName("REF_ID")]
        public long RefrenceID { get; set; }
    }
}
