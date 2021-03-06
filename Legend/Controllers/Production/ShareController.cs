﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Operations.Production.Shares;
using Common.Validations;
using Common.Controllers;
using Common.Operations;
using Domain.Entities.Production;
using Domain.Operations.Financial.CustomerTypes;
using Domain.Entities.Financial;

namespace API.Controllers.Production
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShareController : ControllerBase
    {
        [Route("Create")]
        [HttpPost]
        public IApiResult Create(CreateShare operation)
        {
            // check if the customer has type if not add it then add it on share
            // check if the document contain more than one policy holder ben then allow update share type 
            GetCustomerTypes customerTypes = new GetCustomerTypes();
            customerTypes.CustomerID = operation.CustomerId;
            var typesResult=customerTypes.QueryAsync().Result;
            var types = (List <CustomerType>) typesResult;
           int index = types.FindIndex(item => item.LocCustomerType == operation.LocShareType);
           if(index>= 0 )
            {
                var result = operation.ExecuteAsync().Result;
                if (result is ValidationsOutput)
                {
                    return new ApiResult<List<ValidationItem>>() { Data = ((ValidationsOutput)result).Errors };
                }
                else
                {
                    return new ApiResult<object>() { Status = ApiResult<object>.ApiStatus.Success, ID = ((ComplateOperation<int>)result).ID.Value };
                }
            }
            else
            {
              
                    CustomerType policyHolder = new CustomerType();

                policyHolder.CustomerID = operation.CustomerId;
                    policyHolder.LocCustomerType = operation.LocShareType;
                    policyHolder.CreatedBy = operation.CreatedBy;
                    policyHolder.CreationDate = operation.CreationDate;
                    // insert customer as policy holder 
                    var policyHolderResult = AddUpdateCustomerContacts.AddUpdateMode(policyHolder);
                var result = operation.ExecuteAsync().Result;
                if (result is ValidationsOutput)
                {
                    return new ApiResult<List<ValidationItem>>() { Data = ((ValidationsOutput)result).Errors };
                }
                else
                {
                    return new ApiResult<object>() { Status = ApiResult<object>.ApiStatus.Success, ID = ((ComplateOperation<int>)result).ID.Value };
                }

            }

        
          
          
        }

        [Route("Update")]
        [HttpPost]
        public IApiResult Update(UpdateShare operation)
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
        public IActionResult Load(long? ID, long? ShareType, long? UWDocumentID, long? CustomerId , long? StLOB, long? StSubLOB,  long? langId)
        {
            GetShare operation = new GetShare();
            operation.ID = ID;
            operation.LocShareType = ShareType;
            operation.DocumentID = UWDocumentID;
            operation.CustomerId = CustomerId;
            operation.StLOB = StLOB;
            operation.StSubLOB = StSubLOB;

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
                return Ok((List<Share>)result);
            }
        }
        [Route("Delete")]
        [HttpPost]
        public IApiResult Delete(DeleteShare operation)
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
        public IApiResult DeleteMultiple(DeletesShare operation)
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