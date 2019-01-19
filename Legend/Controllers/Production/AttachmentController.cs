using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Operations.Production.Attachments;
using Common.Validations;
using Common.Controllers;
using Common.Operations;
using Domain.Entities.Production;
using Domain.Entities.ProductSetup;
using Attachment = Domain.Entities.Production.Attachment;
using Microsoft.Extensions.Configuration;

namespace API.Controllers.Production
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentController : ControllerBase
    {
        private readonly IConfiguration configuration;
        public AttachmentController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        [Route("Create")]
        [HttpPost] 
        public IApiResult Create([FromForm]CustomObject obj)
        {
            CreateAttachment operation = convertCustomerObjectToAttachment(obj);
            var result = operation.ExecuteAsync().Result;
            if (result is ValidationsOutput)
            {
                return new ApiResult<List<ValidationItem>>() { Data = ((ValidationsOutput)result).Errors };
            }
            else
            {
                return new ApiResult<object>() { Status = ApiResult<object>.ApiStatus.Success, ID = ((ComplateOperation<int>)result).ID.Value };
            }
        }

        [Route("Update")]
        [HttpPost]
        public IApiResult Update(UpdateAttachment operation)
        {
            var result = operation.ExecuteAsync().Result;
            if (result is ValidationsOutput)
            {
                return new ApiResult<List<ValidationItem>>() { Data = ((ValidationsOutput)result).Errors };
            }
            else
            {
                return new ApiResult<object>() { Status = ApiResult<object>.ApiStatus.Success };
            }
        }

        [Route("Load")]
        [HttpGet]
        public IActionResult Load(long? ID, long? DocumentID, long? RiskID, long? ProductAttachmentID, long? ClaimID, long? Level,  long? langId)
        {
            GetAttachment operation = new GetAttachment();
            operation.ID = ID;
            operation.DocumentID = DocumentID;
            operation.RiskID = RiskID;
            operation.ProductAttachmentID = ProductAttachmentID;
            operation.ClaimID = ClaimID;
            operation.Level = Level;


            if (langId.HasValue)
                operation.LangID = langId;
            else
                operation.LangID = 1;

            var result = operation.QueryAsync().Result;
            if (result is ValidationsOutput)
            {
                return Ok(new ApiResult<List<ValidationItem>>() { Data = ((ValidationsOutput)result).Errors });
            }
            else
            {
                return Ok((List<Attachment>)result);
            }
        }
        [Route("LoadAttachment")]
        [HttpGet]
        public IActionResult LoadAttachment(long? DocumentID, long? RiskID,  long? ClaimID, long? Level, long? langId)
        {
            GetAttachment operation = new GetAttachment();
            operation.DocumentID = DocumentID;
            operation.RiskID = RiskID;
            operation.ClaimID = ClaimID;
            operation.Level = Level;


            if (langId.HasValue)
                operation.LangID = langId;
            else
                operation.LangID = 1;

            var result = operation.QueryFull().Result;
            if (result is ValidationsOutput)
            {
                return Ok(new ApiResult<List<ValidationItem>>() { Data = ((ValidationsOutput)result).Errors });
            }
            else
            {
                return Ok((List<AttachmentProdSetup>)result);
            }
        }
        [Route("Delete")]
        [HttpPost]
        public IApiResult Delete(DeleteAttachment operation)
        {
            var result = operation.ExecuteAsync().Result;
            if (result is ValidationsOutput)
            {
                return new ApiResult<List<ValidationItem>>() { Data = ((ValidationsOutput)result).Errors };
            }
            else
            {
                return new ApiResult<object>() { Status = ApiResult<object>.ApiStatus.Success };
            }
        }
        [Route("DeleteMultiple")]
        [HttpPost]
        public IApiResult DeleteMultiple(DeletesAttachment operation)
        {
            var result = operation.ExecuteAsync().Result;
            if (result is ValidationsOutput)
            {
                return new ApiResult<List<ValidationItem>>() { Data = ((ValidationsOutput)result).Errors };
            }
            else
            {
                return new ApiResult<object>() { Status = ApiResult<object>.ApiStatus.Success };
            }
        }

        public CreateAttachment convertCustomerObjectToAttachment(CustomObject obj)
        {
            CreateAttachment attachmentToReturn = new CreateAttachment();

            attachmentToReturn.ModifiedBy = obj.CreatedBy;
            attachmentToReturn.CreatedBy = obj.CreatedBy;
            attachmentToReturn.Remarks = obj.Remarks;
            attachmentToReturn.Type = obj.Type;
            attachmentToReturn.Path = configuration.GetSection("AttachmentPath:Path").Value;
            if(!string.IsNullOrEmpty(obj.ID))
            {
                attachmentToReturn.ID = Convert.ToInt64(obj.ID);
            }
            if (!string.IsNullOrEmpty(obj.ProductAttachmentID))
            {
                attachmentToReturn.ProductAttachmentID = Convert.ToInt64(obj.ProductAttachmentID);
            }
            if (!string.IsNullOrEmpty(obj.DocumentID))
            {
                attachmentToReturn.DocumentID = Convert.ToInt64(obj.DocumentID);
            }
          
            if (!string.IsNullOrEmpty(obj.Serial))
            {
                attachmentToReturn.Serial = Convert.ToInt64(obj.Serial);
            }
            if (obj.IsReceived == "true")
            {
                attachmentToReturn.IsReceived = 1;
            }
            if (obj.File != null )
            {
                attachmentToReturn.IsReceived = 1;
                attachmentToReturn.File = obj.File;
            }
            if (!string.IsNullOrEmpty(obj.ClaimID))
            {
                attachmentToReturn.ClaimID = Convert.ToInt64(obj.ClaimID);
            }
            if (!string.IsNullOrEmpty(obj.RiskID))
            {
                attachmentToReturn.RiskID = Convert.ToInt64(obj.RiskID);
            }
            if (!string.IsNullOrEmpty(obj.Level))
            {
                attachmentToReturn.Level = Convert.ToInt64(obj.Level);
            }
            attachmentToReturn.ReceivedDate = DateTime.Now;
            attachmentToReturn.ModificationDate = DateTime.Now;
          

            return attachmentToReturn;
        }
    }

    public class CustomObject
    {
        public string ID { get; set; }
        public string DocumentID { get; set; }
        public string CreationDate { get; set; }
        public string Type { get; set; }
        public string Serial { get; set; }
        public string RiskID { get; set; }
        public string IsReceived { get; set; }
        public string ReceivedDate { get; set; }
        public string Remarks { get; set; }
        public string ClaimID { get; set; }
        public string Level { get; set; }
        public string CreatedBy { get; set; }
        public string ProductAttachmentID { get; set; }
        public IFormFile File { get; set; }
    }
}