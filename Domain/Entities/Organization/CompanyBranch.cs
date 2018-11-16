using Common.Interfaces;
using Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Organization
{
    [DBTableName("ST_BRANCHES")]
    public class CompanyBranch : IEntity
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
        [DBFiledName("ST_CTY_ID")]
        public long CityID { get; set; }
        [DBFiledName("ST_COM_ID")]
        public long? CompanyID { get; set; }
        [DBFiledName("ADDRESS")]
        public string Address { get; set; }
        [DBFiledName("ADDRESS2")]
        public string Address2 { get; set; }
        [DBFiledName("EMAIL")]
        public string Email { get; set; }
        [DBFiledName("FAX")]
        public string Fax { get; set; }
        [DBFiledName("PHONE")]
        public string Phone { get; set; }
        [DBFiledName("CODE")]
        public string Code { get; set; }
        [DBFiledName("ST_CUR_CODE")]
        public string CurrencyCode { get; set; }
        [DBFiledName("COUNTRY_CODE")]
        public string CountryCode { get; set; }
        [DBFiledName("ST_CNT_ID")]
        public long CountryID { get; set; }
    }
}
