﻿using System;
using System.Collections.Generic;
using Common.Controllers;
using Common.Validations;
using Domain.Entities.Production;
using Domain.Operations.Production.DictionariyColumns;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Production
{
    [Route("api/[controller]")]
    [ApiController]
    public class DictionaryColumnsController : ControllerBase
    {
       
        [Route("Load")]
        [HttpGet]
        public IActionResult Load(long? ID, long? DictionaryID, long? langId)
        {
            GetDictionaryColumns operation = new GetDictionaryColumns();
            operation.ID = ID;
            operation.DictionaryID = DictionaryID;
           
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
                return Ok((List<DictionaryColumn>)result);
            }
        }
       
    }
}