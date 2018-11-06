using Common.Controllers;
using Common.Interfaces;
using Common.Validations;
using Domain.Operations.Organization.LockUps;
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
    public class LockUpsController : ControllerBase
    {
        [Route("Create")]
        [HttpPost]
        public IApiResult Create(CreateLockUp operation)
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
        public IApiResult Update(UpdateLockUp operation)
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
        public IApiResult LoadLockUpStatus(GetLockUps operation)
        {
            operation.MajorCode = 1;
            operation.LangID = 1;
         
            var result = operation.Query().Result;
            if (result is ValidationsOutput)
            {
                return new ApiResult<List<ValidationItem>>() { Data = ((ValidationsOutput)result).Errors };
            }
            else
            {
                var ReturnResult = (List<Lockup>)result;
                ReturnResult.RemoveAt(0);
                return new ApiResult<List<Lockup>>() { Status = ApiResult<List<Lockup>>.ApiStatus.Success, Data = ReturnResult };
            }
        }
        [Route("LoadLockUps")]
        [HttpPost]
        public IApiResult LoadLockUps(GetLockUps operation)
        {
           
            var result = operation.Query().Result;
            if (result is ValidationsOutput)
            {
                return new ApiResult<List<ValidationItem>>() { Data = ((ValidationsOutput)result).Errors };
            }
            else
            {
              
                return new ApiResult<List<Lockup>>() { Status = ApiResult<List<Lockup>>.ApiStatus.Success, Data = (List<Lockup>)result};
            }
        }
        [Route("LoadLockUpsMinorCode")]
        [HttpPost]
        public IApiResult LoadLockUpsMinorCode(GetLockUps operation)
        {

            var result = operation.Query().Result;
            if (result is ValidationsOutput)
            {
                return new ApiResult<List<ValidationItem>>() { Data = ((ValidationsOutput)result).Errors };
            }
            else
            {
                var ReturnResult = (List<Lockup>)result;
                List<Lockup> ReturnedLockups = new List<Lockup>();
                foreach (var item in ReturnResult)
                {
                    if (item.MinorCode != 0)
                        ReturnedLockups.Add(item);
                }

                return new ApiResult<List<Lockup>>() { Status = ApiResult<List<Lockup>>.ApiStatus.Success, Data = ReturnedLockups };
            }
        }

        [Route("Delete")]
        [HttpPost]
        public IApiResult Delete(DeleteLockUp operation)
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
