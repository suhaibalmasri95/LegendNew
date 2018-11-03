using Common.Interfaces;
using Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Organization.Entities
{
   public class Company : IEntity
    {
        [DBFiledName("ID")]
        public long? ID { get; set; }
        [DBFiledName("NAME")]
        public string Name { get; set; }
        [DBFiledName("NAME2")]
        public string Name2 { get; set; }
        [DBFiledName("LangID")]
        public long? LangID { get; set; }

        [DBFiledName("MOBILE")]
        public string Mobile { get; set; }
        [DBFiledName("Website")]
        public string Website { get; set; }
        [DBFiledName("ContactPerson")]
        public string ContactPerson { get; set; }
        [DBFiledName("PASS_MLENGHT")]
        public int PasswordMinLength { get; set; }
        [DBFiledName("PASS_MUPPER")]
        public int PasswordMinUpperCase { get; set; }
        [DBFiledName("PASS_MLOWER")]
        public int PasswordMinLowerCase { get; set; }
        [DBFiledName("PASS_MDIGITS")]
        public int PasswordMinNumbers { get; set; }
        [DBFiledName("PASS_MSPECIAL")]
        public int PasswordMinSpecialCharacters { get; set; }
        [DBFiledName("PASS_EXPIRY_PERIOD")]
        public int PasswordExpiryDays { get; set; }
        [DBFiledName("PASS_LOGATTEMPTS")]
        public int PasswordFailedLoginAttempts { get; set; }
        [DBFiledName("PASS_REPEAT")]
        public int PasswordRepeats { get; set; }
        [DBFiledName("LOGO")]
        public string Logo { get; set; }

        [DBFiledName("FAX")]
        public string Fax { get; set; }

        [DBFiledName("PHONE")]
        public string Phone { get; set; }
        [DBFiledName("ADDRESS")]
        public string Address { get; set; }

        [DBFiledName("ADDRESS2")]
        public string Address2 { get; set; }

        [DBFiledName("CODE")]
        public string Code { get; set; }
        [DBFiledName("ST_CUR_CODE")]
        public string CurrencyCode { get; set; }
        [DBFiledName("COUNTRY_CODE")]
        public string CountryCode { get; set; }
        [DBFiledName("ST_CNT_ID")]
        public long CountryID { get; set; }

        [DBFiledName("EMAIL")]
        public string Email { get; set; }



    }
}
