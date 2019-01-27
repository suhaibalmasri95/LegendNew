using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Controllers;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.Financial;
using Domain.Operations.Financial.CustomerGroupRelation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Financial
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerGroupRelationController : ControllerBase
    {
        [Route("Create")]
        [HttpPost]
        public IApiResult Create(CreateCustomerGrRelation operation)
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
        public IApiResult Update(CreateCustomerGrRelation operation)
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
        public IActionResult Load(long? ID, long? ProductDetailID, long? CustomerID, long? langId)
        {

            GetCustomerGrRelation operation = new GetCustomerGrRelation();
            operation.ID = ID;
            operation.ProductDetailId = ProductDetailID;
            operation.CustomerID = CustomerID;

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
                return Ok((List<CustomerGroupRelation>)result);
            }

        }

        [Route("Delete")]
        [HttpPost]
        public IApiResult Delete(DeleteCustomerGrRelation operation)
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
        public IApiResult DeleteMultiple(DeleteCustomerGrRelations operation)
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