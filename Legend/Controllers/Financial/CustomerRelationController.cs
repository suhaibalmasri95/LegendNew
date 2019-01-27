using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Controllers;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.Financial;
using Domain.Operations.Financial.CustomerRelation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Financial
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerRelationController : ControllerBase
    {
        [Route("Create")]
        [HttpPost]
        public IApiResult Create(CreateCustomerRelation operation)
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
        public IApiResult Update(CreateCustomerRelation operation)
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
        public IActionResult Load(long? ID, long? CustomerID, long? CustomerID2,
            long? RelType, long? langId)
        {

            GetCustomerRelation operation = new GetCustomerRelation();
            operation.ID = ID;
            operation.LocRelationType = RelType;
            operation.CustomerID = CustomerID;
            operation.CustomerID2 = CustomerID2;
   
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
                return Ok((List<CustomerRelation>)result);
            }

        }

        [Route("Delete")]
        [HttpPost]
        public IApiResult Delete(DeleteCustomerRelation operation)
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
        public IApiResult DeleteMultiple(DeleteCustomerRelations operation)
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