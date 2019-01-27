using Common.Interfaces;
using Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Financial
{
    [DBTableName("FIN_CUST_LCINES")]
    public class CustomerLicense : IEntity
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
        public decimal? ComissionPercentage { get; set; }

        [DBFiledName("LOC_PROVIDER_TYPE")]
        public decimal? LocProviderTyoe { get; set; }

        [DBFiledName("STATUS_DATE")]
        public DateTime? StatuseDate { get; set; }

        [DBFiledName("LOC_STATUS")]
        public long? Status { get; set; }

        [DBFiledName("LOC_COD")]
        public long? LocCode { get; set; }

        [DBFiledName("LOC_SPT_ID")]
        public long? LocSptID { get; set; }
        [DBFiledName("EXP_DATE")]
        public DateTime? ExpireDate { get; set; }

        [DBFiledName("EFF_DATE")]
        public DateTime? EffectiveDate { get; set; }

        [DBFiledName("LICNESNO")]
        public string LicenseNo { get; set; }
    }
}
