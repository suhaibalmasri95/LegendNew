using Common.Interfaces;
using Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Organization
{
    [DBTableName("ST_DEPARTMENTS")]
    public class Department : IEntity
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
        [DBFiledName("ST_COM_ID")]
        public long? CompanyID { get; set; }
        [DBFiledName("ADDRESS")]
        public string Address { get; set; }
        [DBFiledName("EMAIL")]
        public string Email { get; set; }
    }
}
