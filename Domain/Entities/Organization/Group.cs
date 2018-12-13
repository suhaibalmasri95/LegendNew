using Common.Interfaces;
using Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Organization
{
    [DBTableName("ST_GROUPS")]
    public class Group : IEntity
    {
        public Group()
        {
            StatusDate = DateTime.Now;
        }
        [DBPrimaryKey]
        [DBFiledName("ID")]
        public long? ID { get; set; }
        [DBFiledName("NAME")]
        public string Name { get; set; }
        [DBFiledName("NAME2")]
        public string Name2 { get; set; }
        [DBFiledName("LangID")]
        public long? LangID { get; set; }
        [DBFiledName("LOC_STATUS")]
        public long? Status { get; set; }
        [DBFiledName("STATUS_DATE")]
        public DateTime StatusDate { get; set; }
        [DBFiledName("IS_PDF")]
        public Int32 IsPdf { get; set; }
        [DBFiledName("IS_WORD")]
        public Int32 IsWord { get; set; }
        [DBFiledName("IS_RTF")]
        public Int32 IsRef { get; set; }
        [DBFiledName("IS_EXCEL")]
        public Int32 IsExcel { get; set; }
        [DBFiledName("IS_EXCEL_RECORD")]
        public Int32 IsExcelRecord { get; set; }
        [DBFiledName("EMAIL")]
        public string Email { get; set; }
        [DBFiledName("UserRelationID")]
        public long? UserRelationID { get; set; }
    }
}
