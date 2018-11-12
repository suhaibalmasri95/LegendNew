using Common.Controllers;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.Organization;
using Domain.Operations.Organization.Areas;
using Domain.Operations.Organization.MenuDetails;
using Infrastructure.Attributes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers.Organizations
{
    [Route("api/[controller]")]
    [ApiController]
    [ExceptionsHandling]
    public class MenusController : ControllerBase
    {
        [Route("Create")]
        [HttpPost]
        public IApiResult Create(CreateMenu operation)
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
        public IApiResult Update(UpdateMenu operation)
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
        public IActionResult Load(long? ID , long? Type, long? SubMenuID , long? LanguageID )
        {
            GetMenus operation = new GetMenus();
            operation.ID = ID;
            operation.SubMenuID = SubMenuID;
            operation.Type = Type;

            if (LanguageID.HasValue)
                operation.LangID = LanguageID;
            else
                operation.LangID = 1;




            var result = operation.QueryAsync().Result;
            if (result is ValidationsOutput)
            {
                return Ok(new ApiResult<List<ValidationItem>>() { Data = ((ValidationsOutput)result).Errors });
            }
            else
            {
                return Ok((List<Menu>)result);
             
            }
        }

        [Route("Delete")]
        [HttpPost]
        public IApiResult Delete(DeleteMenu operation)
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
