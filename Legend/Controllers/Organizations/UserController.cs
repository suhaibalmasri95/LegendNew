using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Controllers;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.Organization;
using Domain.Operations.Organization.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Organizations
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [Route("Create")]
        [HttpPost]
        public IApiResult Create(CreateUser operation)
        {
            //check if userName and email exist 
            GetUsers loadUser = new GetUsers();
            
            loadUser.LangID = 1;

            var loadUserResult = loadUser.QueryAsync().Result;
            List<User> users = (List<User>)loadUserResult;
            bool emailExist = users.Exists(user => user.Email == operation.Email);
            if (emailExist)
                return new ApiResult<object>() { ErrorMessageEn = ApiResult<object>.ApiMessage.exist };
            bool userNameExist = users.Exists(user => user.UserName == operation.UserName);
            if (userNameExist)
                return new ApiResult<object>() { ErrorMessageEn = ApiResult<object>.ApiMessage.exist };


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
        public IApiResult Update(UpdateUser operation)
        {
            GetUsers loadUser = new GetUsers();

            loadUser.LangID = 1;
            loadUser.ID = operation.ID;
            var loadUserResult = loadUser.QueryAsync().Result;
            List<User> users = (List<User>)loadUserResult;
            if(users.Count > 0)
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
            else
            {
                return new ApiResult<object>() { ErrorMessageEn = ApiResult<object>.ApiMessage.notExist };
            }
        }

        [Route("Load")]
        [HttpGet]
        public IActionResult Load(Int64? userID, Int64? langId)
        {

            GetUsers operation = new GetUsers();
            operation.ID = userID;
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
                return Ok((List<User>)result);
            }

        }

        [Route("Delete")]
        [HttpPost]
        public IApiResult Delete(DeleteUser operation)
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
        public IApiResult DeleteMultiple(DeleteUsers operation)
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
