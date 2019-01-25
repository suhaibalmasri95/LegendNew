using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Controllers;
using Common.Interfaces;
using Common.Validations;
using Domain.Entities.Setup;
using Domain.Entities.ProductSetup;
using Domain.Operations.ProductSetup.ProductCategory;
using Domain.Operations.Setup.Categories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DeleteCategories = Domain.Operations.ProductSetup.ProductCategory.DeleteCategories;
using DeleteCategory = Domain.Operations.ProductSetup.ProductCategory.DeleteCategory;

namespace API.Controllers.ProductSetup
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        [Route("Create")]
        [HttpPost]
        public IApiResult Create(CreateProductCategory operation)
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
        public IApiResult Update(CreateProductCategory operation)
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
        public IActionResult Load(long? ID,long? CategoryID, long? ProductID,long? ProductDetailID,
            long? CategoryLevel, long? LineOfBusniess, long? SubLineOfBusniess,  long? langId)
        {
            GetProductCategory operation = new GetProductCategory();
            operation.ID = ID;
            operation.ProductID = ProductID;
            operation.CategoryID = CategoryID;
            operation.ProductDetailID = ProductDetailID;
            operation.CategoryLevel = CategoryLevel;
            operation.LineOfBusniess = LineOfBusniess;
            operation.SubLineOfBusniess = SubLineOfBusniess;
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
                return Ok((List<ProductCategory>)result);
            }
        }


        [Route("LoadUnRelatedCategory")]
        [HttpGet]
        public IActionResult LoadUnRelatedCategory(long? ID, long? CategoryID, long? ProductID, long? ProductDetailID,
          long? CategoryLevel, long? LineOfBusniess, long? SubLineOfBusniess, long? langId)
        {
            GetProductCategory operation = new GetProductCategory();
            GetCategories operation2 = new GetCategories();
            operation.ID = ID;
            operation.ProductID = ProductID;
            operation.CategoryID = CategoryID;
            operation.ProductDetailID = ProductDetailID;
            operation.CategoryLevel = CategoryLevel;
            operation.LineOfBusniess = LineOfBusniess;
            operation.SubLineOfBusniess = SubLineOfBusniess;
            operation2.LineOfBusniess = LineOfBusniess;
            operation2.SubLineOfBusniess = SubLineOfBusniess;
            operation2.CategoryLevel = CategoryLevel;
            if (langId.HasValue)
            {
                operation.LangID = langId;
                operation2.LangID = langId;            }
            else { 
                operation.LangID = 1;
                operation2.LangID = 1;
            }


            var result = operation.QueryAsync().Result;
            var productCategories = (List<ProductCategory>)result;
            var categories = (List<Category>) operation2.QueryAsync().Result;
            List<ProductCategory> RelatedCategories = new List<ProductCategory>();
            List<Category> UnRelatedCategories = new List<Category>();
            if (productCategories.Count > 0)
            {
                RelatedCategories = productCategories.Where(p => categories.Any(s => s.ID == p.CategoryID && (s.SubLineOfBusniess == SubLineOfBusniess || s.SubLineOfBusniess == null))).ToList();
                UnRelatedCategories = categories.Where(s => productCategories.Any(p => p.CategoryID != s.ID &&
             (s.SubLineOfBusniess == SubLineOfBusniess || s.SubLineOfBusniess == null))).ToList();

                UnRelatedCategories = UnRelatedCategories.Where(un => !RelatedCategories.Exists(re => un.ID == re.CategoryID)).ToList();
            }
            else
            {
                UnRelatedCategories = categories.Where(s => s.SubLineOfBusniess == SubLineOfBusniess || s.SubLineOfBusniess == null).ToList();
            }


            if (result is ValidationsOutput)
            {
                return Ok(new ApiResult<List<ValidationItem>>() { Data = ((ValidationsOutput)result).Errors });
            }
            else
            {
                return Ok(new { UnRelatedCategories  , RelatedCategories });
            }
        }
        [Route("Delete")]
        [HttpPost]
        public IApiResult Delete(DeleteCategory operation)
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
        public IApiResult DeleteMultiple(DeleteCategories operation)
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