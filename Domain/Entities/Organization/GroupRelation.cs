using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Organization
{
    public class GroupRelation : IBase
    {
       
        public long? LangID { get; set; }
        public long? ID { get; set; }

        public long? GroupID { get; set; }
        public string GroupName { get; set; }
        public long? LockUpGroupCat { get; set; }
        public long? RefrenceID { get; set; }
    }
}
