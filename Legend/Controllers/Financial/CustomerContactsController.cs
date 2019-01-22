using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Controllers;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.Financial;
using Domain.Operations.Financial.Customer_Contacts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Financial
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerContactsController : ControllerBase
    {
        [Route("Create")]
        [HttpPost]
        public IApiResult Create(CreateCustomerContacts operation)
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
        public IApiResult Update(CreateCustomerContacts operation)
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
        public IActionResult Load(long? ID, long? CustomerID, long? LangID)
        {

            GetCustomerContacts operation = new GetCustomerContacts();
            operation.ID = ID;
            operation.CustomerID = CustomerID;
            operation.LangID = LangID;

            if (LangID.HasValue)
                operation.LangID = LangID;
            else
                operation.LangID = 1;

            var result = operation.QueryAsync().Result;
            if (result is ValidationsOutput)
            {
                return Ok(new ApiResult<List<ValidationItem>>() { Data = ((ValidationsOutput)result).Errors });
            }
            else
            {
                return Ok((List<CustomerContact>)result);
            }

        }

        //[Route("Delete")]
        //[HttpPost]
        //public IApiResult Delete(DeleteArea operation)
        //{
        //    var result = operation.ExecuteAsync().Result;
        //    if (result is ValidationsOutput)
        //    {
        //        return new ApiResult<List<ValidationItem>>() { Data = ((ValidationsOutput)result).Errors };
        //    }
        //    else
        //    {
        //        return new ApiResult<object>() { Status = ApiResult<object>.ApiStatus.Success };
        //    }
        //}
        //[Route("DeleteMultiple")]
        //[HttpPost]
        //public IApiResult DeleteMultiple(DeleteAreas operation)
        //{
        //    var result = operation.ExecuteAsync().Result;
        //    if (result is ValidationsOutput)
        //    {
        //        return new ApiResult<List<ValidationItem>>() { Data = ((ValidationsOutput)result).Errors };
        //    }
        //    else
        //    {
        //        return new ApiResult<object>() { Status = ApiResult<object>.ApiStatus.Success };
        //    }
        //}
    }
}