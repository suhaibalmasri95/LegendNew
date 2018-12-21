using System;
using System.Collections.Generic;
using System.Text;
using Common.Interfaces;
using Infrastructure.Attributes;


namespace Domain.Entities.Production
{
    [DBTableName("UW_RISKS")]
    public class Risk : IEntity
    {
        public Risk()
        {          
            CreatedBy = "Admin";
            CreationDate = DateTime.Now;
        }

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
        [DBFiledName("DESCRIPTION")]
        public string Description { get; set; }
        [DBFiledName("EFFECTIVE_DATE")]
        public DateTime EffectiveDate { get; set; }
        [DBFiledName("EXPIRY_DATE")]
        public DateTime ExpiryDate { get; set; }
        [DBFiledName("OUR_SHARE")]
        public double? OurShare { get; set; }
        [DBFiledName("MIN_EXCESS_AMT")]
        public double? MinExcessAmount { get; set; }
        [DBFiledName("MAX_EXCESS_AMT")]
        public double? MaxExcessAmount { get; set; }
        [DBFiledName("REF_NO")]
        public string RefNo { get; set; }
        [DBFiledName("ST_LOB")]
        public long? StLOB { get; set; }
        [DBFiledName("ST_SUB_LOB")]
        public long? StSubLOB { get; set; }
        [DBFiledName("UW_DOC_ID")]
        public long? UwDocumentID { get; set; }       
        [DBFiledName("SUMINSURED_LC")]
        public double? SuminsuredLC { get; set; }
        [DBFiledName("SUMINSURED")]
        public double? Suminsured { get; set; }
        [DBFiledName("NET_PREMIUM")]
        public double? NetPremium { get; set; }
        [DBFiledName("NET_PREMIUM_LC")]
        public double? NetPremiumLc { get; set; }
        [DBFiledName("GROSS_PREMIUM")]
        public double? GrossPremium { get; set; }
        [DBFiledName("GROSS_PREMIUM_LC")]
        public double? GrossPremiumLc { get; set; }
        [DBFiledName("ST_PRD_SBT_ID")]
        public long? ProductSubjectTypeID { get; set; }
        [DBFiledName("ST_SBT_ID")]
        public long? SubjectTypeID { get; set; }
        [DBFiledName("ST_PROD_ID")]
        public long? ProductID { get; set; }
        [DBFiledName("ST_PRDT_ID")]
        public long? ProductDetailID { get; set; }
        [DBFiledName("UW_MBR_ID")]
        public long? MemberID { get; set; }
        [DBFiledName("CREATED_BY")]
        public string CreatedBy { get; set; }
        [DBFiledName("CREATION_DATE")]
        public DateTime CreationDate { get; set; }
        [DBFiledName("MODIFIED_BY")]
        public string ModifiedBy { get; set; }
        [DBFiledName("MODIFICATION_DATE")]
        public DateTime ModificationDate { get; set; }
        [DBFiledName("UW_RISK_ID")]
        public long? UwRiskID { get; set; }
    }
}
