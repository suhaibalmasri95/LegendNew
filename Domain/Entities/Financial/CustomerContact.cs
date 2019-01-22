using Common.Interfaces;
using Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Financial
{
    
        [DBTableName("FIN_CUST_CONTACTS")]
    public class CustomerContact : IEntity
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

        [DBFiledName("LOC_INS_DEPT")]
        public long? LocCustomerDept { get; set; }

        [DBFiledName("ST_LOB")]
        public long? LineOfBusiness { get; set; }

        [DBFiledName("POHNE")]
        public string Phone { get; set; }
        [DBFiledName("MOBILE")]
        public string Mobile { get; set; }
        [DBFiledName("POHNE_CODE")]
        public string PhoneCode { get; set; }
        [DBFiledName("EMAIL")]
        public string Email { get; set; }
    }
}
