using Common.Interfaces;
using Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Production
{
    [DBTableName("UW_INSTALLMENT")]
    public class Installment : IEntity
    {
        [DBFiledName("LangID")]
        public long? LangID { get; set; }
        [DBFiledName("Name")]
        public string Name { get; set; }
        [DBFiledName("Name2")]
        public string Name2 { get; set; }
        [DBFiledName("ID")]
        public long? ID { get; set; }

        [DBFiledName("DUE_DATE")]
        public DateTime? DueDate { get; set; }
        [DBFiledName("GROSS_AMOUNT")]
        public double? GrossAmount { get; set; }
        [DBFiledName("GROSS_AMOUNT_LC")]
        public double? GrossAmountLc { get; set; }
        [DBFiledName("NET_AMOUNT_LC")]
        public double? NetAmountLc { get; set; }
        [DBFiledName("NET_AMOUNT")]
        public double? NetAmount { get; set; }
        [DBFiledName("EXRATE")]
        public double? Exrate { get; set; }
        [DBFiledName("UW_DOC_ID")]
        public long? DocumentID { get; set; }
        [DBFiledName("INST_COMM")]
        public double? CommissionAmount { get; set; }
        [DBFiledName("INST_FEES")]
        public double? FeesAmount { get; set; }
        [DBFiledName("INST_FEES_LC")]
        public double? FeesAmountLC { get; set; }


        [DBFiledName("INST_COMM_LC")]
        public double? CommissionAmountLc { get; set; }
        [DBFiledName("INS_PERCENT")]
        public double? Percent { get; set; }

        [DBFiledName("CREATED_BY")]
        public string CreatedBy { get; set; }
        [DBFiledName("CREATION_DATE")]
        public DateTime CreationDate { get; set; }
        [DBFiledName("MODIFIED_BY")]
        public string ModifiedBy { get; set; }
        [DBFiledName("MODIFICATION_DATE")]
        public DateTime ModificationDate { get; set; }

    }
}
