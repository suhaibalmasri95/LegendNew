using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Controllers;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.ProductSetup;
using Domain.Operations.ProductSetup.Attachments;
using Domain.Operations.ProductSetup.ProductAttachments;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.ProductSetup
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAttachmentController : ControllerBase
    {
        [Route("Create")]
        [HttpPost]
        public IApiResult Create(CreateProductAttachment operation)
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

        [Route("Update")]
        [HttpPost]
        public IApiResult Update(UpdateProductAttachment operation)
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
        public IActionResult Load(long? ID, long? ProductID,long? ProductDetailID, long?  AttachmentLevel, long? langId)
        {
            GetProductAttachments operation = new GetProductAttachments();
            operation.ID = ID;
            operation.ProductId = ProductID;
            operation.ProductDetailId = ProductDetailID;
            operation.AttachmentLevel = AttachmentLevel;
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
                return Ok((List<ProductAttachment>)result);
            }
        }

        [Route("LoadUnRelated")]
        [HttpGet]
        public IActionResult LoadUnRelated(long? ID, long? ProductID, long? ProductDetailID, long? AttachmentLevel, long? langId)
        {
            GetProductAttachments operation = new GetProductAttachments();
            GetAttachments operation2 = new GetAttachments();
            
            operation.ID = ID;
            operation.ProductId = ProductID;
            operation.ProductDetailId = ProductDetailID;
            operation.AttachmentLevel = AttachmentLevel;
            
            if (langId.HasValue) { 
                operation.LangID = langId;
                operation2.LangID = langId;
            }
            else { 
                operation.LangID = 1;
                operation2.LangID = 1;
            }

            var result = operation.QueryAsync().Result;
            var result2 = (List<Attachment>)operation2.QueryAsync().Result;

            List<ProductAttachment> RelatedAttachment = new List<ProductAttachment>();
            List<Attachment> UnRelatedAttachment = new List<Attachment>();



            var productAttachment = (List<ProductAttachment>)result;

       
            if (productAttachment.Count > 0)
            {
                RelatedAttachment = productAttachment.Where(p => result2.Any(s => s.ID == p.AttachmentID)).ToList();

                UnRelatedAttachment = result2.Where(s => productAttachment.Any(p => p.AttachmentID != s.ID )).ToList();

                UnRelatedAttachment = UnRelatedAttachment.Where(un => !RelatedAttachment.Exists(re => un.ID == re.AttachmentID)).ToList();
            }
            else
            {
                UnRelatedAttachment = result2;
            }


            if (result is ValidationsOutput)
            {
                return Ok(new ApiResult<List<ValidationItem>>() { Data = ((ValidationsOutput)result).Errors });
            }
            else
            {
                return Ok(new { RelatedAttachment, UnRelatedAttachment });
            }
        }
        [Route("Delete")]
        [HttpPost]
        public IApiResult Delete(DeleteProductAttachment operation)
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
        public IApiResult DeleteMultiple(DeleteProductAttachments operation)
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
    }
}