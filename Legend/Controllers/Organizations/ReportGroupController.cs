using Common.Controllers;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.Organization;
using Domain.Operations.Organization.Areas;
using Domain.Operations.Organization.MenuDetails;
using Domain.Operations.Organization.ReportGroups;
using Domain.Entities.Organization;
using Infrastructure.Attributes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers.Organizations
{
    [Route("api/[controller]")]
    [ApiController]
    [ExceptionsHandling]
    public class ReportGroupController : ControllerBase
    {
        [Route("Create")]
        [HttpPost]
        public IApiResult Create(CreateReportGroup operation)
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
        public IApiResult Update(UpdateReportGroup operation)
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
        [HttpPost]
        public IApiResult Load(GetReportGroups operation)
        {
            var result = operation.QueryAsync().Result;
            if (result is ValidationsOutput)
            {
                return new ApiResult<List<ValidationItem>>() { Data = ((ValidationsOutput)result).Errors };
            }
            else
            {
                return new ApiResult<List<ReportGroup>>() { Status = ApiResult<List<ReportGroup>>.ApiStatus.Success, Data = (List<ReportGroup>)result };
            }
        }
    }
}
