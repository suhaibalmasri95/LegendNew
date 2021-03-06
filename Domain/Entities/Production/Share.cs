﻿using System;
using System.Collections.Generic;
using System.Text;
using Common.Interfaces;
using Infrastructure.Attributes;

namespace Domain.Entities.Production
{
    [DBTableName("UW_SHARES")]
    public class Share : IEntity
    {
        public Share()
        {
            
        }
        [DBFiledName("NAME")]
        public string Name { get; set; }
        [DBFiledName("AgentName")]
        public string AgentName => Name;
        [DBFiledName("NAME2")]
        public string Name2 { get; set; }
        [DBFiledName("LangID")]
        public long? LangID { get; set; }



        [DBFiledName("ID")]
        public long? ID { get; set; }
        [DBFiledName("LOC_SHARE_TYPE")]
        public long? LocShareType { get; set; }
        [DBFiledName("PRCNT")]
        public double? Percent { get; set; }
        [DBFiledName("ComissionPercent")]
        public double? CommissionPercent => Percent;
        [DBFiledName("ComissionPercent")]
        public double? Commission => Percent;
        [DBFiledName("SHARE_PER")]
        public double? SharePercent { get; set; }
        [DBFiledName("AMOUNT")]
        public double? Amount { get; set; }
        [DBFiledName("CommissionAMOUNT")]
        public double? CommissionAmount => Amount;

        [DBFiledName("AMOUNT_LC")]
        public double? AmountLC { get; set; }
        [DBFiledName("NOTES")]
        public string Notes { get; set; }
        [DBFiledName("CREATED_BY")]
        public string CreatedBy { get; set; }
        [DBFiledName("CREATION_DATE")]
        public DateTime CreationDate { get; set; }
        [DBFiledName("MODIFIED_BY")]
        public string ModifiedBy { get; set; }
        [DBFiledName("MODIFICATION_DATE")]
        public DateTime ModificationDate { get; set; }
        [DBFiledName("UW_DOC_ID")]
        public long? DocumentID { get; set; }
        [DBFiledName("FIN_CST_ID")]
        public long? CustomerId { get; set; }
        [DBFiledName("ST_LOB")]
        public long? StLOB { get; set; }
        [DBFiledName("ST_SUB_LOB")]
        public long? StSubLOB { get; set; }
        [DBFiledName("DR_CR")]
        public long? DrCr { get; set; }
        [DBFiledName("LOC_SHARE_TYPE_DESC")] 
        public string ShareType{ get; set; }
        
        [DBFiledName("CUSTOMER_NO")]
        public string CustomerNo { get; set; }
        [DBFiledName("customer")]
        public List<CustomerShare> customer { get; set; }


        [DBFiledName("ST_LOB")]
        public long? LineOfBusiness => StLOB;
        [DBFiledName("SubLineOfBusiness")]
        public long? SubLineOfBusiness => StSubLOB;
    }
}
