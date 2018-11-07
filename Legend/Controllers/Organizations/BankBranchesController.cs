using Common.Controllers;
using Common.Interfaces;
using Common.Validations;
using Domain.Operations.Organization.BankBranches;
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
    public class BankBranchesController : ControllerBase
    {
        [Route("Create")]
        [HttpPost]
        public IApiResult Create(CreateBankBranch operation)
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
        public IApiResult Update(UpdateBankBranch operation)
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
        public IActionResult Load(long? ID, long? BankId, long? languageID = 1)
        {
            GetBankBranches operation = new GetBankBranches();
            operation.ID = ID;
            operation.BankID = BankId;

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
                return Ok(new ApiResult<List<BankBranch>>() { Status = ApiResult<List<BankBranch>>.ApiStatus.Success, Data = (List<BankBranch>)result });
            }
        }

        [Route("Delete")]
        [HttpPost]
        public IApiResult Delete(DeleteBankBranch operation)
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
