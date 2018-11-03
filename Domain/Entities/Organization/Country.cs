using Common.Interfaces;
using Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Organization.Entities
{
    public class Country : IEntity
    {
        public Country() {
            StatusDate = DateTime.Now;
            }
        [DBFiledName("ID")]
        public long? ID { get; set ; }
        [DBFiledName("NAME")]
        public string Name { get; set; }
        [DBFiledName("NAME2")]
        public string Name2 { get; set; }
        [DBFiledName("LangID")]
        public long? LangID { get; set; }
        [DBFiledName("NATIONALITY")]
        public string Nationality { get; set; }
        [DBFiledName("ST_CUR_CODE")]
        public string CurrencyCode { get; set; }
        [DBFiledName("REFERNCE_NO")]
        public string ReferenceNo { get; set; }
        [DBFiledName("LOC_STATUS")]
        public long Status { get; set; }
        [DBFiledName("STATUS_DATE")]
        public DateTime StatusDate { get; set; }
        [DBFiledName("PHONE_CODE")]
        public string PhoneCode { get; set; }
        [DBFiledName("FLAG")]
        public string Flag { get; set; }
    

    }
}
