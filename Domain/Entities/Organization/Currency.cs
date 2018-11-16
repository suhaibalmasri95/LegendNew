using Common.Interfaces;
using Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Organization
{
    [DBTableName("ST_COUNTRIES")]
    public class Currency : ILocalized
    {
        public Currency ()
        {
            StatusDate = DateTime.Now;
        }
        [DBPrimaryKey]
        [DBFiledName("CODE")]
        public string Code { get; set; }
        [DBFiledName("NAME")]
        public string Name { get; set; }
        [DBFiledName("NAME2")]
        public string Name2 { get; set; }
        [DBFiledName("LangID")]
        public long? LangID { get; set; }
        [DBFiledName("DECIMAL_PLACES")]
        public long DecimalPlaces { get; set; }
        [DBFiledName("STATUS")]
        public long Status { get; set; }
        [DBFiledName("SIGN")]
        public string Sign { get; set; }
        [DBFiledName("IS_DELETED")]
        public long IsDeleted { get; set; }
        [DBFiledName("STATUS_DATE")]
        public DateTime StatusDate { get; set; }
        [DBFiledName("FRACT_NAME")]
        public string FractName { get; set; }
        [DBFiledName("FRACT_NAME2")]
        public string FractName2 { get; set; }
    }
}
