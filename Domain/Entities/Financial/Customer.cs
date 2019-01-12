using Common.Interfaces;
using Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Financial
{

    [DBTableName("FIN_CUSTOMERS")]
    public class Customer : IEntity
    {
        [DBFiledName("NAME")]
        public string Name { get; set; }
        [DBFiledName("NAME2")]
        public string Name2 { get; set; }
        [DBFiledName("LangID")]
        public long? LangID { get; set; }
        [DBPrimaryKey]
        [DBFiledName("ID")]
        public long? ID { get; set; }
        [DBFiledName("CUSTOMER_NO")]
        public string CustomerNo { get; set; }
        [DBFiledName("customerNoOrName")]
        public string CustomerNoOrName { get; set; }

        [DBFiledName("LOC_TITLE")]
        public long? LockUpTitle { get; set; }

        [DBFiledName("IND_COMP")]
        public long? IndOrComp { get; set; }
        [DBFiledName("COMM_NAME")]
        public string CommName { get; set; }
        [DBFiledName("POHNE_CODE")]
        public string PhoneCode { get; set; }
        [DBFiledName("POHNE")]
        public string Phone { get; set; }
        [DBFiledName("MOBILE")]
        public string Mobile { get; set; }
        [DBFiledName("FAX")]
        public string Fax { get; set; }
        [DBFiledName("EMAIL")]
        public string Email { get; set; }
        [DBFiledName("WEBSITE")]
        public string Website { get; set; }

        [DBFiledName("ADDRESS")]
        public string Address { get; set; }
        [DBFiledName("LOC_LANGUAGE")]
        public long? LockUpLanguage { get; set; }
        [DBFiledName("LOC_SECOTOR")]
        public long? LockUpSecotor { get; set; }
        [DBFiledName("ST_CTY_ID")]
        public long? CityID { get; set; }
        [DBFiledName("STATUS_DATE")]
        public DateTime StatusDate { get; set; }
        [DBFiledName("LOC_GENDER")]
        public long? LockUpGender { get; set; }
        [DBFiledName("BIRTH_DATE")]
        public DateTime BirthDate { get; set; }
        [DBFiledName("REF_NO")]
        public string ReferenceNo { get; set; }
        [DBFiledName("REF_EFF_DATE")]
        public DateTime RefEffectiveDate { get; set; }
        [DBFiledName("REF_EXP_DATE")]
        public DateTime RefExpiryDate { get; set; }
        [DBFiledName("LOC_TAX_TYPE")]
        public long? LockUpTaxType { get; set; }
        [DBFiledName("TAX_NO")]
        public string TaxNo { get; set; }
        [DBFiledName("START_DATE")]
        public DateTime StartDate { get; set; }
        [DBFiledName("IBAN")]
        public string Iban { get; set; }
        [DBFiledName("ST_BNK_ID")]
        public long? BankID { get; set; }
        [DBFiledName("ST_BNKB_ID")]
        public long? BankBranchID { get; set; }
        [DBFiledName("LOC_STATUS")]
        public long? Status { get; set; }
        [DBFiledName("STATUS_NOTES")]
        public string StatusNotes { get; set; }

        [DBFiledName("CREATED_BY")]
        public string CreatedBy { get; set; }
        [DBFiledName("CREATION_DATE")]
        public DateTime CreationDate { get; set; }
        [DBFiledName("MODIFIED_BY")]
        public string ModifiedBy { get; set; }
        [DBFiledName("MODIFICATION_DATE")]
        public DateTime ModificationDate { get; set; }
        [DBFiledName("ST_COM_ID")]
        public long? CompanyID { get; set; }
        [DBFiledName("ST_CUR_CODE")]
        public string CurrencyCode { get; set; }
        [DBFiledName("ST_CNT_CODE")]
        public long? CountryCode { get; set; }
        [DBFiledName("ST_ARA_ID")]
        public long? AreaID { get; set; }
        [DBFiledName("POBOX")]
        public string PoBox { get; set; }
        [DBFiledName("POSTAL_CODE")]
        public string PostalCode { get; set; }
        [DBFiledName("NATIONALITY")]
        public long? Nationality { get; set; }
        [DBFiledName("IS_VIP")]
        public Int16? IsVip { get; set; }
        [DBFiledName("X_COORDINATES")]
        public string XCoordinates { get; set; }
        [DBFiledName("Y_COORDINATES")]
        public string YCoordinates { get; set; }
        [DBFiledName("LOGO")]
        public string Logo { get; set; }
        [DBFiledName("LOC_CUST_TYPE")]
        public long? CustomerType { get; set; }

        [DBFiledName("AddUpdate")]
        public bool AddUpdate { get; set; }
        [DBFiledName("ShareType")]
        public Int64? ShareType { get; set; }
    }
}
