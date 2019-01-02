using Common.Interfaces;
using Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.ProductSetup
{
    [DBTableName("ST_PRD_SUBJECT_TYPE")]
    public class ProductSubjectType : IEntity
    {
        public ProductSubjectType()
        {
            ModificationDate = DateTime.Now;
            CreationDate = DateTime.Now;
            CreateBy = "Admin";
            ModifiedBy = "Admin";
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
        [DBFiledName("CREATED_BY")]
        public string CreateBy { get; set; }
        [DBFiledName("CREATION_DATE")]
        public DateTime CreationDate { get; set; }
        [DBFiledName("MODIFIED_BY")]
        public string ModifiedBy { get; set; }
        [DBFiledName("MODIFICATION_DATE")]
        public DateTime ModificationDate { get; set; }
        [DBFiledName("ST_LOB")]
        public long? LineOfBusniess { get; set; }
        [DBFiledName("ST_SUB_LOB")]
        public long? SubLineOfBusniess { get; set; }
        [DBFiledName("ST_PRD_ID")]
        public long? ProductID { get; set; }
        [DBFiledName("ST_PRDT_ID")]
        public long? ProductDetailsID { get; set; }
        [DBFiledName("ST_SBT_ID")]
        public long? SubjectTypeID { get; set; }
        [DBFiledName("ST_SBT_PARENT_ID")]
        public long? SubjectTypeParentID { get; set; }
        [DBFiledName("EXCESS_PER")]
        public double? ExcessPerc { get; set; }
        [DBFiledName("MIN_EXCESS_AMT")]
        public double? MinExcess { get; set; }
        [DBFiledName("MAX_EXCESS_AMT")]
        public double? MaxExcess { get; set; }
        [DBFiledName("EXCESS_FROM")]
        public long? ExcessFrom { get; set; }
        [DBFiledName("ST_SUB_LOB_DESC")]
        public string SubjectTypeDesc { get; set; }
    }
}
