using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Controllers;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.ProductSetup;
using Domain.Entities.Setup;
using Domain.Operations.ProductSetup.ProductsDetails;
using Domain.Operations.ProductSetup.ProductsSubjectstypies;
using Domain.Operations.Setup.SubBusiness;
using Domain.Operations.Setup.SubjectTypies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.ProductSetup
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        [Route("Create")]
        [HttpPost]
        public IApiResult Create(CreateProductDetails operation)
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
        public IApiResult Update(UpdateProductDetails operation)
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
        public IActionResult Load(long? ID, long? langId, long? productID)
        {
            GetProductsDetails operation = new GetProductsDetails();
            operation.ID = ID;
            operation.ProductID = productID;

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
                return Ok((List<ProductDetails>)result);
            }
        }
        [Route("LoadRelatedProduct")]
        [HttpGet]
        public IActionResult LoadRelatedProduct( long? langId, long? productID)
        {
            GetProductsDetails operation = new GetProductsDetails();
            GetSubBusniess subBusniess = new GetSubBusniess();
            operation.ProductID = productID;

            if (langId.HasValue)
            {
                operation.LangID = langId;
                subBusniess.LangID = langId;
            }
            else
            {
                operation.LangID = 1;
                subBusniess.LangID = 1;
            }

           
            var result = operation.QueryAsync().Result;
            var sub = subBusniess.QueryAsync().Result;
            var ProductDetails = (List<ProductDetails>)result;
            var SubLineOfBusiness = (List<SubLineOfBusnies>)sub;
            List<SubLineOfBusnies> RelatedSubLine = new List<SubLineOfBusnies>();
            List<SubLineOfBusnies> UnSubLine = new List<SubLineOfBusnies>();
    
            if (SubLineOfBusiness.Count > 0)
            {
                 
                foreach (var prod in ProductDetails)
                {
                    foreach (var item in SubLineOfBusiness)
                    {
                        if (prod.SubLineOfBusniess == item.ID)
                        {
                            bool alreadyExist = RelatedSubLine.Contains(item);
                            bool alreadyExistInSecondList = UnSubLine.Contains(item);
                            if (!alreadyExist && !alreadyExistInSecondList)
                            {

                                RelatedSubLine.Add(item);
                            }
                            else
                            {

                                RelatedSubLine.Add(item);
                                UnSubLine.Remove(item);
                            }
                        }
                        else
                        {
                            bool alreadyExist = RelatedSubLine.Contains(item);
                            bool alreadyExistInFirstList = UnSubLine.Contains(item);
                            if (!alreadyExist && !alreadyExistInFirstList)
                            {

                                UnSubLine.Add(item);
                            }
                        }
                    }

                }
            }
            else
            {
                UnSubLine = SubLineOfBusiness;
            }
            if (result is ValidationsOutput)
            {
                return Ok(new ApiResult<List<ValidationItem>>() { Data = ((ValidationsOutput)result).Errors });
            }
            else
            {
                return Ok(new { RelatedSubLines = RelatedSubLine, UnRelatedSubLines = UnSubLine });
            }
         
        }
        [Route("LoadSubjectType")]
        [HttpGet]
        public IActionResult LoadSubjectType(long? langId, long? productDetailID)
        {
            GetProductsDetails operation = new GetProductsDetails();
            GetSubjectTypies subjectTyoe = new GetSubjectTypies();
            operation.ID = productDetailID;

            if (langId.HasValue)
            {
                operation.LangID = langId;
                subjectTyoe.LangID = langId;
            }
            else
            {
                operation.LangID = 1;
                subjectTyoe.LangID = 1;
            }


            var result = operation.QueryAsync().Result;
            var subject = subjectTyoe.QueryAsync().Result;
            var productSubjectTypes = (List<ProductDetails>)result;
            var SubjectsTypes = (List<SubjectType>)subject;
            List<SubjectType> RelatedSubject = new List<SubjectType>();
            List<SubjectType> UnRelatedSubject = new List<SubjectType>();

            if (SubjectsTypes.Count > 0)
            {

                foreach (var prod in productSubjectTypes)
                {
                    foreach (var item in SubjectsTypes)
                    {
                        if (prod.LineOfBusniess == item.LineOfBusniessID && item.SubLineOfBusniessID ==null)
                        {
                            bool alreadyExist = RelatedSubject.Contains(item);
                            bool alreadyExistInSecondList = UnRelatedSubject.Contains(item);
                            if (!alreadyExist && !alreadyExistInSecondList)
                            {

                                RelatedSubject.Add(item);
                            }
                            else
                            {

                                RelatedSubject.Add(item);
                                UnRelatedSubject.Remove(item);
                            }
                        }
                        else if (prod.LineOfBusniess != item.LineOfBusniessID && item.SubLineOfBusniessID == null)
                        {
                            bool alreadyExist = RelatedSubject.Contains(item);
                            bool alreadyExistInFirstList = UnRelatedSubject.Contains(item);
                            if (!alreadyExist && !alreadyExistInFirstList)
                            {

                                UnRelatedSubject.Add(item);
                            }
                        }
                    }

                }
            }
            else
            {
                UnRelatedSubject = SubjectsTypes;
            }
            if (result is ValidationsOutput)
            {
                return Ok(new ApiResult<List<ValidationItem>>() { Data = ((ValidationsOutput)result).Errors });
            }
            else
            {
                return Ok(new { RelatedSubject, UnRelatedSubject });
            }

        }


        [Route("Delete")]
        [HttpPost]
        public IApiResult Delete(DeleteProductDetails operation)
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
        public IApiResult DeleteMultiple(DeleteProductsDetails operation)
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