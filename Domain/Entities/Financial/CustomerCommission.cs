using Common.Interfaces;
using Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Financial
{
    [DBTableName("FIN_CUST_COMM")]
   public class CustomerCommission : IEntity
    {
        [DBFiledName("CREATED_BY")]
        public string CreatedBy { get; set; }
        [DBFiledName("CREATION_DATE")]
        public DateTime CreationDate { get; set; }
        [DBFiledName("MODIFIED_BY")]
        public string ModifiedBy { get; set; }
        [DBFiledName("MODIFICATION_DATE")]
        public DateTime ModificationDate { get; set; }
        [DBFiledName("NAME")]
        public string Name { get; set; }
        [DBFiledName("NAME2")]
        public string Name2 { get; set; }
        [DBFiledName("LangID")]
        public long? LangID { get; set; }
        [DBPrimaryKey]
        [DBFiledName("ID")]
        public long? ID { get; set; }

        [DBFiledName("FIN_CST_ID")]
        public long? CustomerID { get; set; }

        [DBFiledName("LOC_CUST_TYPE")]
        public long? LocCustomerType { get; set; }

        [DBFiledName("FIN_GL_ID")]
        public long? FinGlID { get; set; }

        [DBFiledName("COMM_PERC")]
        public double? ComissionPercentage { get; set; }

        [DBFiledName("COMM_AMOUNT")]
        public double? CommissionAmount { get; set; }

        [DBFiledName("COMM_AMOUNT_LC")]
        public double? CommissionAmountLc { get; set; }

        [DBFiledName("ST_PRD_ID")]
        public long? ProductId { get; set; }

        [DBFiledName("ST_PRDT_ID")]
        public long? ProductDetailId { get; set; }

        [DBFiledName("ST_LOB")]
        public long? LineOfBusiness { get; set; }
        [DBFiledName("ST_SUB_LOB")]
        public long? SubLineOfBusiness { get; set; }

        [DBFiledName("DRT_CR")]
        public long? DrtCr { get; set; }

        [DBFiledName("LOC_COMM_TYPE")]
        public long? LocCommissionType { get; set; }
    }
}
