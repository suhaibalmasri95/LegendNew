﻿using Common.Interfaces;
using Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Organization.Entities
{
    public class Lockup : IEntity
    {
        [DBFiledName("ID")]
        public long? ID { get; set; }
        [DBFiledName("NAME")]
        public string Name { get; set; }
        [DBFiledName("NAME2")]
        public string Name2 { get; set; }
        [DBFiledName("LangID")]
        public long? LangID { get; set; }
        [DBFiledName("MAJOR_CODE")]
        public long MajorCode { get; set; }
        [DBFiledName("MINOR_CODE")]
        public long MinorCode { get; set; }
        [DBFiledName("ST_LOCKUP_ID")]
        public int? LockUpID { get; set; }
        [DBFiledName("CREATED_BY")]
        public string CreatedBy { get; set; }
        [DBFiledName("CREATION_DATE")]
        public DateTime CreationDate { get; set; }
        [DBFiledName("MODIFIED_BY")]
        public string ModifiedBy { get; set; }
        [DBFiledName("MODIFICATION_DATE")]
        public DateTime ModificationDate { get; set; }
        [DBFiledName("LOCKUP_TYPE")]
        public int? LockUpType { get; set; }
        [DBFiledName("REF_NO")]
        public string ReferenceNo { get; set; }
    }
}
