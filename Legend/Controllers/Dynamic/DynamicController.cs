using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Controllers;
using Common.Validations;
using Domain.Entities.ProductDynamic;
using Domain.Operations.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Dynamic
{
    [Route("api/[controller]")]
    [ApiController]
    public class DynamicController : ControllerBase
    {

        [Route("Load")]
        [HttpGet]
        public IActionResult Load(long? ID, long? CategoryID, long? ProductID, long? ProductDetailID, long? CategoryLevel , long? LineOfBuisness, long? SubLineOfBuisness, long? LangID )
        {

            GetDynamicCategory operation = new GetDynamicCategory();
            operation.ID = ID;
            operation.CategoryID = CategoryID;
            operation.ProductID = ProductID;
            operation.CategoryLevel = CategoryLevel;
            operation.LineOfBuisness = LineOfBuisness;
            operation.SubLineOfBuisness = SubLineOfBuisness;
            if (LangID.HasValue)
                operation.LangID = LangID;
            else
                operation.LangID = 1;

            var result = operation.QueryAsync().Result;

            var Categories = (List<ProductDynmicCategory>)result;
            foreach (var item in Categories)
            {
                GetDynamicColumns columns = new GetDynamicColumns();
                columns.CategoryID = item.CategoryID;
                columns.ProductID = item.ProductID;
                columns.ProductDetailID = item.ProductDetailID;
                columns.ColumnType = null;
                columns.LineOfBuisness = item.LineOfBuisness;
                columns.SubLineOfBuisness = item.SubLineOfBuisness;
                columns.ExecludedColumn = 4;
                columns.LangID = LangID;
                item.Columns = (List<ProductDynamicColumn>)columns.QueryAsync().Result;
                GetDynamicColumns dropDownList = new GetDynamicColumns();
                columns.CategoryID = item.CategoryID;
                columns.ProductID = item.ProductID;
                columns.ProductDetailID = item.ProductDetailID;
                columns.ColumnType = 4;
                columns.LineOfBuisness = item.LineOfBuisness;
                columns.SubLineOfBuisness = item.SubLineOfBuisness;
                columns.ExecludedColumn = null;
                columns.LangID = LangID;
                item.Lists = (List<ProductDynamicColumn>)dropDownList.QueryAsync().Result;
            }

            if (result is ValidationsOutput)
            {
                return Ok(new ApiResult<List<ValidationItem>>() { Data = ((ValidationsOutput)result).Errors });
            }
            else
            {
                return Ok((List<ProductDynmicCategory>)result);
            }

        }
    }
}