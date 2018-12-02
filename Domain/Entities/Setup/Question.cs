using System;
using System.Collections.Generic;
using System.Text;
using Common.Interfaces;
using Infrastructure.Attributes;
 
namespace Domain.Entities.Setup
{
    [DBTableName("ST_QUESTIONS")]
    public class Question : IEntity
    {
        public Question ()
        {
            StatusDate = DateTime.Now;
        }
        [DBFiledName("NAME")]
        public string Name { get; set; }
        [DBFiledName("NAME2")]
        public string Name2 { get; set; }
        [DBFiledName("DESCRIPTION")]
        public string Description { get; set; }
        [DBFiledName("DESCRIPTION2")]
        public string Description2 { get; set; }
        [DBFiledName("LangID")]
        public long? LangID { get; set; }

        [DBPrimaryKey]
        [DBFiledName("ID")]
        public long? ID { get; set; }
        [DBFiledName("STATUS")]
        public long? Status { get; set; }
        [DBFiledName("STATUS_DATE")]
        public DateTime StatusDate { get; set; }
        [DBFiledName("QUS_ORDER")]
        public Int16 QustionOrder { get; set; }

        [DBFiledName("QUS_TYPE")]
        public long? QustionType { get; set; }
        [DBFiledName("ST_QUS_ID")]
        public long? QuestionnaireID { get; set; }
        [DBFiledName("LOC_ST_LOCK_ID")]
        public long? LockUpID { get; set; }

    }
}
