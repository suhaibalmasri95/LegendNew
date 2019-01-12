using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Controllers;
using Common.Interfaces;
using Common.Operations;
using Common.Validations;
using Domain.Entities.Financial;
using Domain.Operations.Financial.Customers;
using Domain.Operations.Financial.CustomerTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Financial
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        [Route("getPolicyHolders")]
        [HttpGet]
        public IActionResult getCustomer(long? ID, string Name,string custOrName, string CusNo,string email,string mobile,string nationID, long? languageID, long? CustomerType)
        {
            GetCustomers operation = new GetCustomers();
            operation.ID = ID;
            operation.Name = Name;
            operation.Email = email;
            operation.Mobile = mobile;
            operation.ReferenceNo = nationID;
            operation.CustomerNo = CusNo;
            operation.CustomerType = CustomerType;
            operation.CustomerNoOrName = custOrName;
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
                var ReturnResult = (List<Customer>)result;

                return Ok(ReturnResult);
            }
        }


        [Route("Create")]
        [HttpPost]
        public IApiResult Create(CreateCustomer operation)
        {
            var result = operation.ExecuteAsync().Result;
            
            if (result is ValidationsOutput)
            {
                return new ApiResult<List<ValidationItem>>() { Data = ((ValidationsOutput)result).Errors };
            }
            else
            {
                if(operation.ShareType.HasValue) { 
                CustomerType policyHolder = new CustomerType();
                   
                policyHolder.CustomerID = ((ComplateOperation<int>)result).ID.Value;
                policyHolder.LocCustomerType = operation.ShareType;
                policyHolder.CreatedBy = operation.CreatedBy;
                policyHolder.CreationDate = operation.CreationDate;
                // insert customer as policy holder 
                var policyHolderResult = AddUpdateCustomerType.AddUpdateMode(policyHolder);
                }
                return new ApiResult<object>() { Status = ApiResult<object>.ApiStatus.Success };
            }
        }


    }
}