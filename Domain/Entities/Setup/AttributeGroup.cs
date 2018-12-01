using Common.Interfaces;
using Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Setup
{
    [DBTableName("ST_MED_ATT_GROUP_SERVICES")]
    public class AttributeGroup : IEntity
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
        [DBFiledName("ST_SRVCS_ID")]
        public long? SRVCS_ID { get; set; }
        [DBFiledName("ST_MED_ATT_GRP_ID")]
        public long? ATT_GRP_ID { get; set; }
    }
}
