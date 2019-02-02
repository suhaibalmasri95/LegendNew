using Common.Interfaces;
using Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.ProductSetup
{
    [DBTableName("ST_PRD_REPORTS")]
    public class ProductReport : IEntity
    {
        [DBTableName("ST_PRD_WRD_DETAILS")]
        public ProductReport()
        {

          
            ModificationDate = DateTime.Now;
           
            ModifiedBy = "Admin";

        }
        [DBFiledName("NAME")]
        public string Name { get; set; }
        [DBFiledName("NAME2")]
        public string Name2 { get; set; }
        [DBFiledName("DESCRIPTION")]
        public string Description { get; set; }
        [DBFiledName("DESCRIPTION2")]
        public string Description2 { get; set; }
        [DBFiledName("LangID")]
        public long? LangID { get; set; }
        [DBPrimaryKey]
        [DBFiledName("ID")]
        public long? ID { get; set; }
  
        [DBFiledName("STATUS")]
        public long? Status { get; set; }
        [DBFiledName("STATUS_DATE")]
        public DateTime StatusDate { get; set; }

        [DBFiledName("ST_ATT_ID")]
        public long? AttachmentID { get; set; }
        [DBFiledName("ST_PRD_ID")]
        public long? ProductId { get; set; }
        [DBFiledName("ST_PRDT_ID")]
        public long? ProductDetailId { get; set; }
        [DBFiledName("ST_LOB")]
        public long? LineOfBusiness { get; set; }
        [DBFiledName("ST_SUB_LOB")]
        public long? SubLineOfBusiness { get; set; }
        [DBFiledName("ST_REP_ID")]
        public long? ReportId { get; set; }
        [DBFiledName("REP_LEVEL")]
        public long? ReportLevel { get; set; }
        [DBFiledName("IS_REQUIRED")]
        public Int16? IsRequired { get; set; }
        [DBFiledName("ST_REP_CODE")]
        public string ReportCode { get; set; }
        [DBFiledName("CREATED_BY")]
        public string CreateBy { get; set; }
        [DBFiledName("CREATION_DATE")]
        public DateTime CreationDate { get; set; }
        [DBFiledName("MODIFIED_BY")]
        public string ModifiedBy { get; set; }
        [DBFiledName("MODIFICATION_DATE")]
        public DateTime ModificationDate { get; set; }
    }
}
