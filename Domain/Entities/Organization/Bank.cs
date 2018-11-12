using Common.Interfaces;
using Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Organization
{
    [DBTableName("ST_BANCK")]
    public class Bank : IEntity
    {
        [DBFiledName("ID")]
        [DBPrimaryKey]
        public long? ID { get; set; }
        [DBFiledName("NAME")]
        public string Name { get; set; }
        [DBFiledName("NAME2")]
        public string Name2 { get; set; }
        [DBFiledName("LangID")]
        public long? LangID { get; set; }
        [DBFiledName("PHONE_CODE")]
        public string PhoneCode { get; set; }
        [DBFiledName("PHONE")]
        public string Phone { get; set; }
        [DBFiledName("CODE")]
        public string CurrencyCode { get; set; }
    }
}
