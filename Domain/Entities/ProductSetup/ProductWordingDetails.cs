using Common.Interfaces;
using Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.ProductSetup
{
    [DBTableName("ST_PRD_WRD_DETAILS")]
    public class ProductWordingDetails : IEntity
    {
       
        public ProductWordingDetails()
        {

            this.Serial = 1;

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
        [DBFiledName("SERIAL")]
        public long? Serial { get; set; }
        [DBFiledName("STATUS")]
        public long? Status { get; set; }
        [DBFiledName("STATUS_DATE")]
        public DateTime StatusDate { get; set; }
        [DBFiledName("WORD_TYPE")]
        public long? WordType { get; set; }
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
        [DBFiledName("ST_WORD_ID")]
        public long? WordId { get; set; }
        [DBFiledName("IS_AUTO_ADD")]
        public Int16? IsAutoAdd { get; set; }
        [DBFiledName("ST_SRVCS_ID")]
        public long? ServiceID { get; set; }
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
