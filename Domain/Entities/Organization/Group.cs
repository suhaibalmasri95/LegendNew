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
        public bool IsPdf { get; set; }
        [DBFiledName("IS_WORD")]
        public bool IsWord { get; set; }
        [DBFiledName("IS_RTF")]
        public bool IsRef { get; set; }
        [DBFiledName("IS_EXCEL")]
        public bool IsExcel { get; set; }
        [DBFiledName("IS_EXCEL_RECORD")]
        public bool IsExcelRecord { get; set; }
        [DBFiledName("EMAIL")]
        public string Email { get; set; }
    }
}
