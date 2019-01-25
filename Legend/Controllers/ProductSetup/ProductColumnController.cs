using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Controllers;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.ProductDynamic;
using Domain.Entities.ProductSetup;
using Domain.Operations.Dynamic;
using Domain.Operations.ProductSetup.ProductColumns;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.ProductSetup
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductColumnController : ControllerBase
    {
        [Route("Create")]
        [HttpPost]
        public IApiResult Create(CreateProductColumn operation)
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
        public IApiResult Update(CreateProductColumn operation)
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
        public IActionResult Load(long? ID, long? CategoryID, long? ProductID, long? ProductDetailID,
            long? ColumnType, long? LineOfBusniess, long? SubLineOfBusniess, long? langId)
        {
            GetDynamicColumns columns = new GetDynamicColumns();
            columns.ID = ID;
            columns.ProductID = ProductID;
            columns.CategoryID = CategoryID;
            columns.ProductDetailID = ProductDetailID;
            columns.ColumnType = ColumnType;
            columns.LineOfBuisness = LineOfBusniess;
            columns.SubLineOfBuisness = SubLineOfBusniess;
            if (langId.HasValue)
                columns.LangID = langId;
            else
                columns.LangID = 1;

            var result = columns.QueryAsyncInsert().Result;
            if (result is ValidationsOutput)
            {
                return Ok(new ApiResult<List<ValidationItem>>() { Data = ((ValidationsOutput)result).Errors });
            }
            else
            {
                return Ok((List<DynamicDdl>)result);
            }
        }
        [Route("Delete")]
        [HttpPost]
        public IApiResult Delete(DeleteProductColumn operation)
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
        public IApiResult DeleteMultiple(DeleteProductColumns operation)
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