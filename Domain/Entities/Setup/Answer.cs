using System;
using System.Collections.Generic;

using Common.Interfaces;
using Infrastructure.Attributes;

namespace Domain.Entities.Setup
{
    [DBTableName("ST_ANSWERS")]
    public class Answer : IEntity
    {
        [DBFiledName("NAME")]
        public string Name { get; set; }
        [DBFiledName("NAME2")]
        public string Name2 { get; set; }
        [DBFiledName("LangID")]
        public long? LangID { get; set; }

        [DBPrimaryKey]
        [DBFiledName("ID")]
        public long? ID { get; set; }

        [DBFiledName("ANS_ORDER")]
        public Int16? AnswerOrder { get; set; }
        [DBFiledName("ST_QUS_ID")]
        public long? QuestionnaireID { get; set; }


    }
}
