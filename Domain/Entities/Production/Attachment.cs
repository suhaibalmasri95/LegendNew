using System;
using System.Collections.Generic;
using System.Text;
using Common.Interfaces;
using Domain.Entities.ProductSetup;
using Infrastructure.Attributes;
using Microsoft.AspNetCore.Http;

namespace Domain.Entities.Production
{
    [DBTableName("UW_ATTACHMENTS")]
    public class Attachment : IEntity
    {
        public Attachment()
        {
          
        }
        [DBFiledName("NAME")]
        public string Name { get; set; }
        [DBFiledName("NAME2")]
        public string Name2 { get; set; }
        [DBFiledName("LangID")]
        public long? LangID { get; set; }



        [DBFiledName("ID")]
        public long? ID { get; set; }
        [DBFiledName("SERIAL")]
        public long? Serial { get; set; }
        [DBFiledName("ATTACHED_PATH")]
        public string AttachedPath { get; set; }
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
        [DBFiledName("UW_RISK_ID")]
        public long? RiskID { get; set; }
        [DBFiledName("IS_RECEIVED")]
        public long? IsReceived { get; set; }
        [DBFiledName("RECEIVED_DATE")]
        public DateTime? ReceivedDate { get; set; }
        [DBFiledName("REMARKS")]
        public string Remarks { get; set; }
        [DBFiledName("ST_PRD_ATT_ID")]
        public long? ProductAttachmentID { get; set; }
        [DBFiledName("CLM_ID")]
        public long? ClaimID { get; set; }
        [DBFiledName("LOC_LEVEL")]
        public long? Level { get; set; }

        [DBFiledName("type")]
        public string Type { get; set; }
        [DBFiledName("Path")]
        public string Path { get; set; }
        [DBFiledName("FullPath")]
        public string FullPath { get; set; }
        [DBFiledName("attachments")]
        public ProductAttachment attachments { get; set; }
        [DBFiledName("attachments")]
        public IFormFile File { get; set; }



    }
}
