using Common.Controllers;
using Common.Interfaces;
using Common.Validations;
using Domain.Operations.Organization.LockUps;
using Domain.Entities.Organization;
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
        [HttpGet]
        public IActionResult LoadLockUpStatus(long? ID, long? MajorCode, long? MinorCode, long? LockupParentID, long? languageID)
        {
            GetLockUps operation = new GetLockUps();
            operation.MajorCode = MajorCode;

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
                var ReturnResult = (List<Lockup>)result;
              
                return Ok(ReturnResult);
            }
        }
        [Route("LoadLockUps")]
        [HttpGet]
        public IActionResult LoadLockUps(long? ID, long? MajorCode, long? MinorCode, long? LockupParentID, long? languageID = 1)
        {
            GetLockUps operation = new GetLockUps();
            operation.ID = ID;
            operation.MajorCode = MajorCode;
            operation.MajorCode = MinorCode;
            operation.LockUpID = LockupParentID;

            if (languageID.HasValue)
                operation.LangID = languageID;
            else
                operation.LangID = 1;
            var result = operation.QueryAsync().Result;
            if (result is ValidationsOutput)
            {
                return Ok( new ApiResult<List<ValidationItem>>() { Data = ((ValidationsOutput)result).Errors });
            }
            else
            {
              
                return Ok((List<Lockup>)result);
            }
        }
        [Route("LoadLockUpsMinorCode")]
        [HttpGet]
        public IActionResult LoadLockUpsMinorCode(long? ID, long? MajorCode, long? MinorCode, long? LockupParentID, long? languageID)
        {
            GetLockUps operation = new GetLockUps();
            operation.ID = ID;
            operation.MajorCode = MajorCode;
            operation.MajorCode = MinorCode;
            operation.LockUpID = LockupParentID;

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
                var ReturnResult = (List<Lockup>)result;
                List<Lockup> ReturnedLockups = new List<Lockup>();
                foreach (var item in ReturnResult)
                {
                    if (item.MinorCode != 0)
                        ReturnedLockups.Add(item);
                }

                return Ok( ReturnedLockups);
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
