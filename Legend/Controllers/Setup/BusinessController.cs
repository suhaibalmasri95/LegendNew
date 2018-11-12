using Common.Controllers;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.Organization;
using Domain.Entities.Setup;
using Domain.Operations.Setup.Business;
using Infrastructure.Attributes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers.Setup
{
    [Route("api/[controller]")]
    [ApiController]
    [ExceptionsHandling]
    public class BusinessController : ControllerBase
    {
        [Route("Create")]
        [HttpPost]
        public IApiResult Create(CreateBusines operation)
        {
            var result = operation.Execute().Result;
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
        public IApiResult Update(UpdateBusniess operation)
        {
            var result = operation.Execute().Result;
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
        public IActionResult Load(long? ID, string Code, long? LineOfBusiness, long? langId)
        {
            GetBusniess operation = new GetBusniess();
            operation.ID = ID;
            operation.Code = Code;
            operation.LineOfBusiness = LineOfBusiness;

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
                return Ok((List<BusinesLine>)result);
            }
        }
    }
}
