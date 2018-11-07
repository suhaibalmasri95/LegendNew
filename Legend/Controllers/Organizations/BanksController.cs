using Common.Controllers;
using Common.Interfaces;
using Common.Validations;
using Domain.Operations.Organization.Banks;
using Domain.Organization.Entities;
using Infrastructure.Attributes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers.Organizations
{
    [Route("api/[controller]")]
    [ApiController]
    [ExceptionsHandling]
    public class BanksController : ControllerBase
    {
        [Route("Create")]
        [HttpPost]
        public IApiResult Create(CreateBank operation)
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
        public IApiResult Update(UpdateBank operation)
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
        public IActionResult Load(long? ID, long? languageID = 1)
        {
            GetBanks operation = new GetBanks();
            operation.ID = ID;
            if (languageID.HasValue)
                operation.LangID = languageID;
            else
                operation.LangID = 1;
            var result = operation.Query().Result;
            if (result is ValidationsOutput)
            {
                return Ok( new ApiResult<List<ValidationItem>>() { Data = ((ValidationsOutput)result).Errors });
            }
            else
            {
                return Ok((List<Bank>)result);
            }
        }

        [Route("Delete")]
        [HttpPost]
        public IApiResult Delete(DeleteBank operation)
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
    }
}
