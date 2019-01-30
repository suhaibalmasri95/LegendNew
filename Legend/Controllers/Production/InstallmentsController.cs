using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Controllers;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.Production;
using Domain.Operations.Production.Documents;
using Domain.Operations.Production.Installments;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Production
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstallmentsController : ControllerBase
    {





        [Route("Create")]
        [HttpPost]
        public IApiResult Create(CreateInstallment operation)
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
        public IApiResult Update(CreateInstallment operation)
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
        public IActionResult Load(long? ID,long? DocumentId, long? langId)
        {
            GetInstallments operation = new GetInstallments();
            operation.ID = ID;
    
            operation.DocumentID = DocumentId;

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
                return Ok((List<Installment>)result);
            }
        }



        [Route("test")]
        [HttpGet]
        public IActionResult test()
        {
            CreateInstallment operation = new CreateInstallment();
          

            operation.DocumentID = 201;
            operation.CommissionAmount = 1.2;
            operation.CommissionAmountLc = 1.3;
            operation.CreationDate = DateTime.Now;
            operation.CreatedBy = "admin";
            operation.DueDate = DateTime.Now;
            operation.Exrate = 1.2;
            operation.FeesAmount = 1.0;
            operation.FeesAmountLC = 1.2;
            operation.GrossAmount = 1.3;
            operation.GrossAmountLc = 1.4;
            operation.Percent = 1.4;

         

            var result = operation.ExecuteAsync().Result;
            if (result is ValidationsOutput)
            {
                return Ok(new ApiResult<List<ValidationItem>>() { Data = ((ValidationsOutput)result).Errors });
            }
            else
            {
                return Ok((List<Cover>)result);
            }
        }
        [Route("Delete")]
        [HttpPost]
        public IApiResult Delete(DeleteInstallment operation)
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
        public IApiResult DeleteMultiple(DeleteInstallments operation)
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