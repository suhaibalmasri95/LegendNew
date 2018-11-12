using Common.Interfaces;
using Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Organization
{
    [DBTableName("ST_REPORT_GROUP")]
    public class ReportGroup : IEntity
    {
        [DBPrimaryKey]
        [DBFiledName("ID")]
        public long? ID { get; set; }
        [DBFiledName("NAME")]
        public string Name { get; set; }
        [DBFiledName("NAME2")]
        public string Name2 { get; set; }
  
        [DBFiledName("")]
        public long? LangID { get; set; }
        [DBFiledName("ORDER_BY")]
        public long? OrderBy { get; set; }
    }
}
