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
        public IActionResult LoadSubjectType(long? langId, long? productDetailID , long? LineOfBusiness , long? SubLine )
        {
           
            GetSubjectTypies subjectType = new GetSubjectTypies();
            GetProductSubjectTypies prodSubjectTypes = new GetProductSubjectTypies();
         
            prodSubjectTypes.ProductDetailsID = productDetailID;

            prodSubjectTypes.LineOfBusniess = LineOfBusiness;
            if (langId.HasValue)
            {
            
                subjectType.LangID = langId;
                prodSubjectTypes.LangID = langId;
            }
            else
            { 
                subjectType.LangID = 1;
                prodSubjectTypes.LangID = 1;
            }


       
          
            List<ProductSubjectType> RelatedSubject = new List<ProductSubjectType>();
            List<SubjectType> UnRelatedSubject = new List<SubjectType>();

          

              
                subjectType.LineOfBusniessID = LineOfBusiness;
                var subject = subjectType.QueryAsync().Result;
                var SubjectsTypes = (List<SubjectType>)subject;
                var productSubjectTypesResult = (List<ProductSubjectType>)prodSubjectTypes.QueryAsync().Result;
            if (productSubjectTypesResult.Count > 0)
            {
                RelatedSubject = productSubjectTypesResult.Where(p => SubjectsTypes.Any(s => s.ID == p.SubjectTypeID && (s.SubLineOfBusniessID == SubLine || s.SubLineOfBusniessID == null))).ToList();
                UnRelatedSubject = SubjectsTypes.Where(s => productSubjectTypesResult.Any(p => p.SubjectTypeID != s.ID &&
             (s.SubLineOfBusniessID == SubLine || s.SubLineOfBusniessID == null))).ToList();

                UnRelatedSubject = UnRelatedSubject.Where(un => !RelatedSubject.Exists(re => un.ID == re.SubjectTypeID)).ToList();
            } else
            {
                UnRelatedSubject = SubjectsTypes.Where(s=> s.SubLineOfBusniessID == SubLine || s.SubLineOfBusniessID == null).ToList();
            }



            if (subject is ValidationsOutput)
            {
                return Ok(new ApiResult<List<ValidationItem>>() { Data = ((ValidationsOutput)subject).Errors });
            }
            else
            {
                return Ok(new { RelatedSubject, UnRelatedSubject });
            }

        }

 
        [Route("Delete")]
        [HttpPost]
        public IApiResult Delete(DeleteProductDetail operation)
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