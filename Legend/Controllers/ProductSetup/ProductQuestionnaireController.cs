using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Controllers;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.ProductSetup;
using Domain.Entities.Setup;
using Domain.Operations.ProductSetup.ProductQuestionnaires;
using Domain.Operations.ProductSetup.ProductsDetails;
using Domain.Operations.Setup.Questionnaires;
using Domain.Operations.Setup.SubBusiness;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.ProductSetup
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductQuestionnaireController : ControllerBase
    {

        [Route("Create")]
        [HttpPost]
        public IApiResult Create(CreateProductQuestionears operation)
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
        public IApiResult Update(UpdateProductQuestionears operation)
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
        public IActionResult Load(long? ID, long? productID, long? productDetailedID, long? langId)
        {
            GetProductQuestionears operation = new GetProductQuestionears();
            operation.ID = ID;
            operation.ProductID = productID;
            operation.ProductDetailedID = productDetailedID;

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
                return Ok((List<ProductQuestionnaire>)result);
            }
        }
        [Route("LoadRelatedQuestionnaire")]
        [HttpGet]
        public IActionResult LoadRelatedQuestionnaire(long? langId, long? productID, long? productDetailedID)
        {
            GetProductsDetails operation = new GetProductsDetails();
            GetProductQuestionears questionears = new GetProductQuestionears();
            
            operation.ID = productDetailedID;

            if (langId.HasValue)
            {
                operation.LangID = langId;
                questionears.LangID = langId;
            }
            else
            {
                operation.LangID = 1;
                questionears.LangID = 1;
            }


            var result = operation.QueryAsync().Result;
            var qus = questionears.QueryAsync().Result;
    
            var ProductDetails = (List<ProductDetails>)result;
     
            var productQuestionnaires = (List<ProductQuestionnaire>)qus;
            List<ProductQuestionnaire> RelatedQuestionnaires = new List<ProductQuestionnaire>();
            List<ProductQuestionnaire> UnRelatedQuestionnaires = new List<ProductQuestionnaire>();

            if (productQuestionnaires.Count > 0)
            {

                foreach (var prod in ProductDetails)
                {
                   
                        foreach (var item in productQuestionnaires)
                    {
                        

                     
                        if (prod.ID == item.ProductDetailedID )
                        {
                            bool alreadyExist = RelatedQuestionnaires.Contains(item);
                            bool alreadyExistInSecondList = UnRelatedQuestionnaires.Contains(item);
                            if (!alreadyExist && !alreadyExistInSecondList)
                            {

                                RelatedQuestionnaires.Add(item);
                            }
                            else
                            {

                                RelatedQuestionnaires.Add(item);
                                UnRelatedQuestionnaires.Remove(item);
                            }
                        }
                        else 
                        {
                            bool alreadyExist = RelatedQuestionnaires.Contains(item);
                            bool alreadyExistInFirstList = UnRelatedQuestionnaires.Contains(item);
                            if (!alreadyExist && !alreadyExistInFirstList)
                            {

                                UnRelatedQuestionnaires.Add(item);
                            }
                        }
                    }

                    
                }
            }
            else
            {
                UnRelatedQuestionnaires = productQuestionnaires;
            }
            if (result is ValidationsOutput)
            {
                return Ok(new ApiResult<List<ValidationItem>>() { Data = ((ValidationsOutput)result).Errors });
            }
            else
            {
                return Ok(new {  RelatedQuestionnaires, UnRelatedQuestionnaires });
            }

        }
        [Route("LoadQuestionnaire")]
        [HttpGet]
        public IActionResult LoadQuestionnaire(long? langId, long? productID, long? productDetailedID)
        {
            GetProductsDetails operation = new GetProductsDetails();
            GetQuestionnaire questionears = new GetQuestionnaire();

            operation.ProductID = productID;

            if (langId.HasValue)
            {
                operation.LangID = langId;
                questionears.LangID = langId;
            }
            else
            {
                operation.LangID = 1;
                questionears.LangID = 1;
            }


            var result = operation.QueryAsync().Result;
            var qus = questionears.QueryAsync().Result;

            var ProductDetails = (List<ProductDetails>)result;

            var productQuestionnaires = (List<Questionnaire>)qus;
            List<Questionnaire> RelatedQuestionnaires = new List<Questionnaire>();
            List<Questionnaire> UnRelatedQuestionnaires = new List<Questionnaire>();

            if (productQuestionnaires.Count > 0)
            {

                foreach (var prod in ProductDetails)
                {

                    foreach (var item in productQuestionnaires)
                    {



                        if (prod.LineOfBusniess == item.LineOfBusiness &&  item.SubLineOfBusiness == null)
                        {
                            bool alreadyExist = UnRelatedQuestionnaires.Contains(item);
                            bool alreadyExistInSecondList = RelatedQuestionnaires.Contains(item);
                            if (!alreadyExist && !alreadyExistInSecondList)
                            {
                                
                                UnRelatedQuestionnaires.Add(item);
                            }
                            else
                            {
                                UnRelatedQuestionnaires.Add(item);
                          
                                RelatedQuestionnaires.Remove(item);
                            }
                        }
                        else 
                        {
                            bool alreadyExist = RelatedQuestionnaires.Contains(item);
                            bool alreadyExistInFirstList = UnRelatedQuestionnaires.Contains(item);
                            if (!alreadyExist && !alreadyExistInFirstList)
                            {

                                RelatedQuestionnaires.Add(item);
                            }
                        }
                    }


                }
            }
            else
            {
                UnRelatedQuestionnaires = productQuestionnaires;
            }
            if (result is ValidationsOutput)
            {
                return Ok(new ApiResult<List<ValidationItem>>() { Data = ((ValidationsOutput)result).Errors });
            }
            else
            {
                return Ok(new { RelatedQuestionnaires, UnRelatedQuestionnaires });
            }

        }
        [Route("Delete")]
        [HttpPost]
        public IApiResult Delete(DeleteProductQuestionear operation)
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
        public IApiResult DeleteMultiple(DeleteProductQuestionears operation)
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