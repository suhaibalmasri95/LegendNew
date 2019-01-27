using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Controllers;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.Financial;
using Domain.Operations.Financial.CustomerLicense;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Financial
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerLicenseController : ControllerBase
    {
        [Route("Create")]
        [HttpPost]
        public IApiResult Create(CreateCustomerLicense operation)
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
        public IApiResult Update(CreateCustomerLicense operation)
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
        public IActionResult Load(long? ID, string LicenseNo, long? CustomerID,
            long? SptID, long? ProviderType,long? Code, long? langId)
        {

            GetCustomerLicense operation = new GetCustomerLicense();
            operation.ID = ID;
            operation.LicenseNo = LicenseNo;
            operation.CustomerID = CustomerID;
            operation.LocSptID = SptID;
            operation.LocCode = Code;
            operation.LocProviderTyoe = ProviderType;
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
                return Ok((List<CustomerLicense>)result);
            }

        }

        [Route("Delete")]
        [HttpPost]
        public IApiResult Delete(DeleteCustomerLicense operation)
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
        public IApiResult DeleteMultiple(DeleteCustomerLicenses operation)
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