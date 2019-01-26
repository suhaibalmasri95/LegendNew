using Common.Interfaces;
using Infrastructure.Attributes;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.ProductSetup
{
    [DBTableName("ST_PRD_ATTCAHMENTS")]
    public class ProductAttachment : IEntity
    {
        
        public ProductAttachment()
        {
         
           
       
      
        }
        [DBFiledName("NAME")]
        public string Name { get; set; }
        [DBFiledName("NAME2")]
        public string Name2 { get; set; }
        [DBFiledName("LangID")]
        public long? LangID { get; set; }
        [DBPrimaryKey]
        [DBFiledName("ID")]
        public long? ID { get; set; }
        [DBFiledName("STATUS")]
        public long? Status { get; set; }
        [DBFiledName("STATUS_DATE")]
        public DateTime StatusDate { get; set; }
        [DBFiledName("ATT_LEVEL")]
        public long? AttachmentLevel { get; set; }
        [DBFiledName("IS_REQUIRED")]
        public Int16? IsRequired { get; set; }

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
        [DBFiledName("file")]
        public IFormFile File { get; set; }
    }
}
