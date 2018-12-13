using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Controllers;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.ProductSetup;
using Domain.Operations.ProductSetup.ProductsSubjectstypies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.ProductSetup
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsSubjectTypesController : ControllerBase
    {
      
            [Route("Create")]
            [HttpPost]
            public IApiResult Create(CreateProductSibjectType operation)
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
            public IApiResult Update(UpdateProductSibjectType operation)
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
            public IActionResult Load(long? ID, long? langId, long? productID, long? productDetailsID)
            {
                GetProductSubjectTypies operation = new GetProductSubjectTypies();
                operation.ID = ID;
                operation.ProductDetailsID = productDetailsID;
                operation.ProductID = productID;

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
                    return Ok((List<ProductSubjectType>)result);
                }
            }
            [Route("Delete")]
            [HttpPost]
            public IApiResult Delete(DeleteProductsSubjecttype operation)
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
            public IApiResult DeleteMultiple(DeleteProductsSubjecttypies operation)
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