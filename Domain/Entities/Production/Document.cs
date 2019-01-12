using System;
using System.Collections.Generic;
using System.Text;
using Common.Interfaces;
using Domain.Entities.Financial;
using Domain.Entities.ProductDynamic;
using Infrastructure.Attributes;


namespace Domain.Entities.Production
{
    [DBTableName("UW_DCOUMENTS")]
    public class Document : IEntity
    {
        public Document()
        {
            StatusDate = DateTime.Now;
            DocumentType = 1;
            UwYear =   Convert.ToInt16( DateTime.Now.Year);
            TrnSerial = 1;
            DocumentShare = 100;
            CurrencyCode = "AED";
            Exrate = 1;
            AccountedFor = 1;
            IsClaimed = 0;
            IsCancelled = 0;
            IsReinsured = 0;
            IsPrinted = 0;
            IsPosted = 0;
            OpenCoverType = 0;
            Status = 1;
            CreatedBy = "Admin";
            CreationDate = DateTime.Now;
            PaymentId = 1;
            LocEndtId = 1;
            FyrYear = Convert.ToInt16(DateTime.Now.Year);
            FinancialDate = DateTime.Now;
            CalcBases = 1;
            LocDistChnales = 1;
            NetAmount = 0;
            NetAmountLc = 0;
            LoadingAmount = 0;
            LoadingAmountLc = 0;
            DiscountAmount = 0;
            DiscountAmountLc = 0;
            ChargesAmount = 0;
            ChargesAmountLc = 0;
            CommAmount = 0;
            CommAmountLc = 0;
            GrossAmmount = 0;
            GrossAmountLc = 0;
        }
        [DBFiledName("DOC_TYPE")]
        public Int16 DocumentType { get; set; }
        [DBFiledName("DCOUMENT_NO")]
        public long DocumentNo { get; set; }
        [DBFiledName("LangID")]
        public long? LangID { get; set; }

        [DBFiledName("NAME")]
        public string Name { get; set; }
        [DBFiledName("NAME2")]
        public string Name2 { get; set; }

        [DBPrimaryKey]
        [DBFiledName("ID")]
        public long? ID { get; set; }
        [DBFiledName("TRN_SERIAL")]
        public long? TrnSerial { get; set; }

        [DBFiledName("UW_YEAR")]
        public Int16? UwYear { get; set; }

        [DBFiledName("DOC_SEGMENT")]
        public string DocumentSegment { get; set; }
        [DBFiledName("ISSUE_DATE")]
        public DateTime IssueDate { get; set; }
        [DBFiledName("EFFECTIVE_DATE")]
        public DateTime EffectiveDate { get; set; }

        [DBFiledName("EXPIRY_DATE")]
        public DateTime ExpiryDate { get; set; }
        [DBFiledName("REF_NO")]
        public string ReferenceNo { get; set; }
        [DBFiledName("DOC_SHARE")]
        public double? DocumentShare { get; set; }
        [DBFiledName("EXRATE")]
        public double? Exrate { get; set; }
        [DBFiledName("ST_CUR_CODE")]
        public string CurrencyCode { get; set; }
        [DBFiledName("NOTES")]
        public string Notes { get; set; }
        [DBFiledName("NOTES2")]
        public string Notes2 { get; set; }
        [DBFiledName("ACC_FOR")]
        public Int16? AccountedFor { get; set; }
        [DBFiledName("IS_CLAIMED")]
        public Int16? IsClaimed { get; set; }
        [DBFiledName("IS_PRINTED")]
        public Int16? IsPrinted { get; set; }
        [DBFiledName("IS_REINSURED")]
        public Int16? IsReinsured { get; set; }
        [DBFiledName("IS_POSTED")]
        public Int16? IsPosted { get; set; }
        [DBFiledName("IS_CANCELLED")]
        public Int16? IsCancelled { get; set; }
        [DBFiledName("OPEN_COVER_TYPE")]
        public Int16? OpenCoverType { get; set; }
        [DBFiledName("STATUS")]
        public long? Status { get; set; }
        [DBFiledName("STATUS_DATE")]
        public DateTime StatusDate { get; set; }
        [DBFiledName("CREATED_BY")]
        public string CreatedBy { get; set; }
        [DBFiledName("CREATION_DATE")]
        public DateTime CreationDate { get; set; }
        [DBFiledName("MODIFIED_BY")]
        public string ModifiedBy { get; set; }
        [DBFiledName("MODIFICATION_DATE")]
        public DateTime ModificationDate { get; set; }
        [DBFiledName("UW_DOC_ID")]
        public long? UwDocId { get; set; }
        [DBFiledName("ST_PROD_ID")]
        public long? ProductId { get; set; }
        [DBFiledName("LOC_PYM_ID")]
        public long? PaymentId { get; set; }
        [DBFiledName("LOC_BUST_ID")]
        public long? LocBustId { get; set; }
        [DBFiledName("LOC_ENDT_ID")]
        public long? LocEndtId { get; set; }
        [DBFiledName("ST_COM_ID")]
        public long? StComId { get; set; }
        [DBFiledName("ST_BRN_ID")]
        public long? StBrnId { get; set; }
        [DBFiledName("QUT_VALIDITY")]
        public long? QutValidity { get; set; }
        [DBFiledName("FYR_YEAR")]
        public Int16? FyrYear { get; set; }
        [DBFiledName("FINANCIAL_DATE")]
        public DateTime FinancialDate { get; set; }
        [DBFiledName("CALC_BASES")]
        public long? CalcBases { get; set; }
        [DBFiledName("LOC_DIST_CHNALES")]
        public long? LocDistChnales { get; set; }
        [DBFiledName("NET_AMOUNT")]
        public double? NetAmount { get; set; }
        [DBFiledName("NET_AMOUNT_LC")]
        public double? NetAmountLc { get; set; }
        [DBFiledName("LOADING_AMOUNT")]
        public double? LoadingAmount { get; set; }
        [DBFiledName("LOADING_AMOUNT_LC")]
        public double? LoadingAmountLc { get; set; }
        [DBFiledName("DISCOUNT_AMOUNT")]
        public double? DiscountAmount { get; set; }
        [DBFiledName("DISCOUNT_AMOUNT_LC")]
        public double? DiscountAmountLc { get; set; }
        [DBFiledName("CHARGES_AMOUNT")]
        public double? ChargesAmount { get; set; }
        [DBFiledName("CHARGES_AMOUNT_LC")]
        public double? ChargesAmountLc { get; set; }
        [DBFiledName("COMM_AMOUNT")]
        public double? CommAmount { get; set; }
        [DBFiledName("COMM_AMOUNT_LC")]
        public double? CommAmountLc { get; set; }
        [DBFiledName("GROSS_AMMOUNT")]
        public double? GrossAmmount { get; set; }
        [DBFiledName("GROSS_AMOUNT_LC")]
        public double? GrossAmountLc { get; set; }
        [DBFiledName("DynamicCategories")]
        public List<ProductDynmicCategory> DynamicCategories { get; set; }

        [DBFiledName("Risks")]
        public List<Risk> Risks { get; set; }
        [DBFiledName("share")]
        public Share share { get; set; }
        [DBFiledName("NewCustomer")]
        public Customer  NewCustomer { get; set; }

        [DBFiledName("UpdateMode")]
        public bool UpdateMode { get; set; }

    }
}
