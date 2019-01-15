using Infrastructure.Attributes;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Production
{
   public class AttachmentProdSetup
    {
        [DBFiledName("NAME")]
        public string Name { get; set; }
        [DBFiledName("NAME2")]
        public string Name2 { get; set; }
        [DBFiledName("LangID")]
        public long? LangID { get; set; }



        [DBFiledName("ID")]
        public decimal? ID { get; set; }
        [DBFiledName("SERIAL")]
        public decimal? Serial { get; set; }
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
        public decimal? DocumentID { get; set; }
        [DBFiledName("UW_RISK_ID")]
        public decimal? RiskID { get; set; }
        [DBFiledName("IS_RECEIVED")]
        public decimal? IsReceived { get; set; }
        [DBFiledName("RECEIVED_DATE")]
        public DateTime? ReceivedDate { get; set; }
        [DBFiledName("REMARKS")]
        public string Remarks { get; set; }
        [DBFiledName("ST_PRD_ATT_ID")]
        public Int64? ProductAttachmentID { get; set; }
        [DBFiledName("CLM_ID")]
        public decimal? ClaimID { get; set; }
        [DBFiledName("LOC_LEVEL")]
        public Int64? Level { get; set; }

        [DBFiledName("type")]
        public string Type { get; set; }
        [DBFiledName("Path")]
        public string Path { get; set; }
        [DBFiledName("FullPath")]
        public string FullPath { get; set; }

        [DBFiledName("attachments")]
        public IFormFile File { get; set; }

    }
}
