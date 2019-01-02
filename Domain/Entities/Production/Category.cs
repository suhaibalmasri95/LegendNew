using Common.Interfaces;
using Domain.Entities.ProductDynamic;
using Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Production
{
    [DBTableName("UW_COLUMNS_CATGORY")]
    public class Category : IEntity
    {
        [DBFiledName("LangID")]
        public long? LangID { get; set; }

        [DBFiledName("ID")]
        public long? ID { get; set; }
        [DBFiledName("SERIAL")]
        public long? Serial { get; set; }
        [DBFiledName("NAME")]
        public string Name { get; set; }
        [DBFiledName("NAME2")]
        public string Name2 { get; set; }

        [DBFiledName("ST_PRD_CAT_ID")]
        public long? ProductCategoryID { get; set; }

        [DBFiledName("LABLE")]
        public string Lable { get; set; }
        [DBFiledName("LABLE2")]
        public string Lable2 { get; set; }

        [DBFiledName("CAT_ORDER")]
        public long? CategoryOrder { get; set; }
        [DBFiledName("UW_RISK_ID")]
        public long? RiskID { get; set; }

        [DBFiledName("UW_DOC_ID")]
        public long? DocumentID { get; set; }

        [DBFiledName("ST_LOB")]
        public long? LineOfBusiness { get; set; }


        [DBFiledName("ST_SUB_LOB")]
        public long? SubLineOfBusiness { get; set; }

        [DBFiledName("UW_MBR_ID")]
        public long? MemberID { get; set; }
        [DBFiledName("IsMulti")]
        public long? IsMulti { get; set; }
        [DBFiledName("ResultList")]
        public List<DynamicDdl> ResultList { get; set; }
        [DBFiledName("Result")]
        public List<DynamicDdl[]> Result { get; set; }

    }
}
