using Common.Interfaces;
using Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Organization
{
    public class Group : IEntity
    {
        [DBFiledName("NAME")]
        public string Name { get; set; }
        [DBFiledName("NAME2")]
        public string Name2 { get; set; }
        [DBFiledName("LangID")]
        public long? LangID { get; set; }
        [DBFiledName("ID")]
        public long? ID { get; set; }
        [DBFiledName("LOC_STATUS")]
        public long? Status { get; set; }
        [DBFiledName("STATUS_DATE")]
        public DateTime StatusDate { get; set; }
        [DBFiledName("IS_PDF")]
        public Int64 IsPdf { get; set; }
        [DBFiledName("IS_WORD")]
        public Int64 IsWord { get; set; }
        [DBFiledName("IS_RTF")]
        public Int64 IsRef { get; set; }
        [DBFiledName("IS_EXCEL")]
        public Int64 IsExcel { get; set; }
        [DBFiledName("IS_EXCEL_RECORD")]
        public Int64 IsExcelRecord { get; set; }
        [DBFiledName("EMAIL")]
        public string Email { get; set; }
    }
}
