﻿using Common.Interfaces;
using Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Organization
{
    [DBTableName("ST_REPORTS")]
    public class Report : IEntity
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
        [DBFiledName("REP_ORDER")]
        public long? Order { get; set; }
        [DBFiledName("CODE")]
        public string Code { get; set; }
        [DBFiledName("ST_REPG_ID")]
        public long? ReportGroupID { get; set; }
        [DBFiledName("ReportRelationID")]
        public long? ReportRelationID { get; set; }
    }
}
