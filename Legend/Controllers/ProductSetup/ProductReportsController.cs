using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Controllers;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.Organization;
using Domain.Entities.ProductSetup;
using Domain.Operations.Organization.Reports;
using Domain.Operations.ProductSetup.ProductReports;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.ProductSetup
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductReportsController : ControllerBase
    {
        [Route("Create")]
        [HttpPost]
        public IApiResult Create(CreateProductReport operation)
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
        public IApiResult Update(UpdateProductReport operation)
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
        public IActionResult Load(long? ID, long? ProductID, long? ProductDetailID, long? langId)
        {
            GetProductReports operation = new GetProductReports();
            operation.ID = ID;
            operation.ProductId = ProductID;
            operation.ProductDetailId = ProductDetailID;
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
                return Ok((List<ProductReport>)result);
            }
        }

        [Route("LoadRelated")]
        [HttpGet]
        public IActionResult LoadRelated(long? ID, long? ProductID, long? ProductDetailID, long? langId)
        {
            GetProductReports operation = new GetProductReports();
            GetReport operation2 = new GetReport();
            operation.ID = ID;
            operation.ProductId = ProductID;
            operation.ProductDetailId = ProductDetailID;
            if (langId.HasValue) { 
                operation.LangID = langId;
                operation2.LangID = langId;
            }
            else { 
                operation.LangID = 1;
                operation2.LangID = 1;
            }

            var result = operation.QueryAsync().Result;
            var result2 =(List<Report>) operation2.QueryAsync().Result;

            List<ProductReport> RelatedReports = new List<ProductReport>();
            List<Report> UnRelatedReports= new List<Report>();



            var productReports = (List<ProductReport>)result;


            if (productReports.Count > 0)
            {
                RelatedReports = productReports.Where(p => result2.Any(s => s.ID == p.ReportId)).ToList();

                UnRelatedReports = result2.Where(s => productReports.Any(p => p.ReportId != s.ID)).ToList();

                UnRelatedReports = UnRelatedReports.Where(un => !RelatedReports.Exists(re => un.ID == re.ReportId)).ToList();
            }
            else
            {
                UnRelatedReports = result2;
            }
            if (result is ValidationsOutput)
            {
                return Ok(new ApiResult<List<ValidationItem>>() { Data = ((ValidationsOutput)result).Errors });
            }
            else
            {
                return Ok(new { UnRelatedReports, RelatedReports } );
            }
        }
        [Route("Delete")]
        [HttpPost]
        public IApiResult Delete(DeleteProductReport operation)
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
        public IApiResult DeleteMultiple(DeleteProductReports operation)
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
