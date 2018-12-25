using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Controllers;
using Common.Validations;
using Domain.Entities.Financial;
using Domain.Operations.Financial.Customers;
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
        public IActionResult getCustomer(string Name, string CusNo, long? languageID, long? CustomerType)
        {
            GetCustomers operation = new GetCustomers();
            operation.Name = Name;
            operation.CustomerNo = CusNo;
            operation.CustomerType = CustomerType;
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
    }
}