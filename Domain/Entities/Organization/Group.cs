using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Organization
{
    public class Group : IEntity
    {
        public string Name { get; set; }
        public string Name2 { get; set; }
        public long? LangID { get; set; }
        public long? ID { get; set; }
        public long? Status { get; set; }
        public DateTime StatusDate { get; set; }
        public Int32 IsPdf { get; set; }
        public Int32 IsWord{ get; set; }
        public Int32 IsRef { get; set; }
        public Int32 IsExcel{ get; set; }
        public Int32 IsExcelRecord { get; set; }
        public string Email { get; set; }
    }
}
