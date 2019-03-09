using System;
using System.Collections.Generic;
using Common.Controllers;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.Production;
using Domain.Operations.Production.FactorDetails;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Production
{

    [Route("api/[controller]")]
    [ApiController]
    public class FactorDetailController : ControllerBase
    {
        [Route("Create")]
        [HttpPost]
        public IApiResult Create(CreateFactorDetails operation)
        {
            var result = operation.ExecuteAsync().Result;
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
        public IApiResult Update(CreateFactorDetails operation)
        {
            var result = operation.ExecuteAsync().Result;
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
        public IActionResult Load(long? ID, long? DictionaryID,long? EntryType, long? FactorID, long? ChargeID, long? ProductID, long? ProductDetailID , long? ProductFacdID,  long? langId)
        {
            GetFactorDetails operation = new GetFactorDetails();
            operation.ID = ID;
            operation.DictionaryID = DictionaryID;
            operation.FactorID = FactorID;
            operation.ChargeID = ChargeID;
            operation.ProductID = ProductID;
            operation.ProductDetailID = ProductDetailID;
            operation.ProductFacdID = ProductFacdID;
            operation.EntryType = EntryType;
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
                return Ok((List<FactorDetail>)result);
            }
        }
        [Route("Delete")]
        [HttpPost]
        public IApiResult Delete(DeleteFactorDetail operation)
        {
            var result = operation.ExecuteAsync().Result;
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
        public IApiResult DeleteMultiple(DeleteFactorDetails operation)
        {
            var result = operation.ExecuteAsync().Result;
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