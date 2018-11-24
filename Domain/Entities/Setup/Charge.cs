using Common.Interfaces;
using Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Setup
{
    [DBTableName("ST_CHARGES")]
    public class Charge : IEntity
    {
        public Charge()
        {
           
            CreationDate = DateTime.Now;
            ModificationDate = DateTime.Now;
            CreatedBy = "ADMIN";
            ModifiedBy = "ADMIN";
        }
        [DBFiledName("NAME")]
        public string Name { get; set; }
        [DBFiledName("NAME2")]
        public string Name2 { get; set; }
        [DBFiledName("LangID")]
        public long? LangID { get; set; }

        [DBPrimaryKey]
        [DBFiledName("ID")]
        public long? ID { get; set; }
        [DBFiledName("LOB_CODE")]
        public long? LineOfBusinessCode { get; set; }
        [DBFiledName("LOC_CHARG_TYPE")]
        public long? LockUpChargeType { get; set; }
        [DBFiledName("CREATED_BY")]
        public string CreatedBy { get; set; }
        [DBFiledName("CREATION_DATE")]
        public DateTime CreationDate { get; set; }
        [DBFiledName("MODIFIED_BY")]
        public string ModifiedBy { get; set; }
        [DBFiledName("MODIFICATION_DATE")]
        public DateTime ModificationDate { get; set; }
        [DBFiledName("ST_CHG_ID")]
        public long ?ChargeID { get; set; }
        [DBFiledName("ST_TYPE")]
        public long? ChargeType { get; set; }
    }
}
