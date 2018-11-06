using Common.Interfaces;
using Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Organization
{
    public class ReportGroup : IEntity
    {
        [DBFiledName("ID")]
        public long? ID { get; set; }
        [DBFiledName("NAME")]
        public string Name { get; set; }
        [DBFiledName("NAME2")]
        public string Name2 { get; set; }
        [DBFiledName("")]
        public long? LangID { get; set; }
        [DBFiledName("ORDER_BY")]
        public string OrderBy { get; set; }
    }
}
