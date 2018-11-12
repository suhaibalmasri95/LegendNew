using Common.Controllers;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.Organization;
using Domain.Operations.Organization.Reports;
using Infrastructure.Attributes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers.Organizations
{
    [Route("api/[controller]")]
    [ApiController]
    [ExceptionsHandling]
    public class ReportController : ControllerBase
    {
        [Route("Create")]
        [HttpPost]
        public IApiResult Create(CreateReport operation = null)
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
        public IApiResult Update(UpdateReport operation)
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
        public IActionResult Load(long? ID , long? ReportGroupID,long? LanguageID )
        {

            GetReport operation = new GetReport();
            operation.ID = ID;
            operation.ReportGroupID = ReportGroupID;

            if (LanguageID.HasValue)
                operation.LangID = LanguageID;
            else
                operation.LangID = 1;

            var result = operation.QueryAsync().Result;
            if (result is ValidationsOutput)
            {
                return Ok( new ApiResult<List<ValidationItem>>() { Data = ((ValidationsOutput)result).Errors });
            }
            else
            {
                return Ok((List<Report>)result);
            }
        }
    }
}
