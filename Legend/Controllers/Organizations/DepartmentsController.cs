using Common.Controllers;
using Common.Interfaces;
using Common.Validations;
using Domain.Operations.Organization.Departments;
using Domain.Entities.Organization;
using Infrastructure.Attributes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers.Organizations
{
    [Route("api/[controller]")]
    [ApiController]
    [ExceptionsHandling]
    public class DepartmentsController : ControllerBase
    {
        [Route("Create")]
        [HttpPost]
        public IApiResult Create(CreateDepartment operation)
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
        public IApiResult Update(UpdateDepartment operation)
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
        public IActionResult Load(long? ID, long? CompanyId, long? languageID = 1)
        {
            GetDepartment operation = new GetDepartment();
            operation.ID = ID;
            operation.CompanyID = CompanyId;
            if (languageID.HasValue)
                operation.LangID = languageID;
            else
                operation.LangID = 1;
            var result = operation.QueryAsync().Result;
            if (result is ValidationsOutput)
            {
                return Ok(new ApiResult<List<ValidationItem>>() { Data = ((ValidationsOutput)result).Errors });
            }
            else
            {
                return Ok( (List<Department>)result);
            }
        }

        [Route("Delete")]
        [HttpPost]
        public IApiResult Delete(DeleteDepartment operation)
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
        [Route("DeleteMultiple")]
        [HttpPost]
        public IApiResult DeleteMultiple(DeleteDepartments operation)
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
