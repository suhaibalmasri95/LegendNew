﻿using Common.Interfaces;
using Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Financial
{
    [DBTableName("FIN_CUST_REALTIONS")]
    public class CustomerRelation : IEntity
    {
        [DBFiledName("CREATED_BY")]
        public string CreatedBy { get; set; }
        [DBFiledName("CREATION_DATE")]
        public DateTime CreationDate { get; set; }
        [DBFiledName("MODIFIED_BY")]
        public string ModifiedBy { get; set; }
        [DBFiledName("MODIFICATION_DATE")]
        public DateTime ModificationDate { get; set; }
        [DBFiledName("NAME")]
        public string Name { get; set; }
        [DBFiledName("NAME2")]
        public string Name2 { get; set; }
        [DBFiledName("LangID")]
        public long? LangID { get; set; }
        [DBPrimaryKey]
        [DBFiledName("ID")]
        public long? ID { get; set; }

        [DBFiledName("FIN_CST_ID")]
        public long? CustomerID { get; set; }
        [DBFiledName("FIN_CST_ID2")]
        public long? CustomerID2 { get; set; }
        [DBFiledName("LOC_REL_TYPE")]
        public long? LocRelationType { get; set; }
    }
}
