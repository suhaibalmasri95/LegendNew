﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Operations.Others;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExportController : ControllerBase
    {

        [HttpPost]
        [Route("Export")]
        public IActionResult Export(ExportOperation operation)
        {
            var result = operation.Execute();
            string filePath = Request.Scheme + "://" + Request.Host.Value + "/" + "Documents/" + result.file;
            return Ok(new { FilePath = filePath});
        }
    }
}