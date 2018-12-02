using System;
using System.Collections.Generic;
using System.Text;
using Common.Interfaces;
using Infrastructure.Attributes;


namespace Domain.Entities.Setup
{
    [DBTableName("ST_QUESTIONEAR")]
    public class Questionnaire : IEntity
    {
        public Questionnaire ()
        {
            StatusDate = DateTime.Now;
        }
        [DBFiledName("NAME")]
        public string Name { get; set; }
        [DBFiledName("NAME2")]
        public string Name2 { get; set; }
        [DBFiledName("LangID")]
        public long? LangID { get; set; }

        [DBPrimaryKey]
        [DBFiledName("ID")]
        public long? ID { get; set; }
        [DBFiledName("STATUS")]
        public long? Status { get; set; }
        [DBFiledName("STATUS_DATE")]
        public DateTime StatusDate { get; set; }
        [DBFiledName("QUS_LEVEL")]
        public long? QustionnaireLevel { get; set; }

        [DBFiledName("ST_LOB_ID")]
        public long? LineOfBusiness { get; set; }
        [DBFiledName("ST_SUB_LOB_ID")]
        public long? SubLineOfBusiness { get; set; }

    }
}
