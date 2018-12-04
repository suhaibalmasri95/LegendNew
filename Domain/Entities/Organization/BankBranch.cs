using Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Organization
{
    [DBTableName("ST_BANCK_BRANCHES")]
    public class BankBranch : Bank
    {
        [DBFiledName("ST_BNK_ID")]
        public long? BankID { get; set; }
        [DBFiledName("ST_CTY_ID")]
        public long CityID { get; set; }
        [DBFiledName( "ST_CNT_ID")]
        public long CountryID { get; set; }
    }
}
