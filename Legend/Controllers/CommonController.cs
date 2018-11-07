using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Organization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {

        [HttpPost]
        [Route("AddImages")]
        public async Task<IActionResult> AddImages([FromForm] Photo image)
        {

            string pathToReturn = "";

            var file = image.File;


            if (file != null)
            {
                Random rand = new Random();
                int guid = rand.Next();
                string ext = Path.GetExtension(file.FileName);
                string imagepath = Path.GetFileNameWithoutExtension(file.FileName) + guid.ToString() + ext.ToString();

                var path = Path.Combine(
                       Directory.GetCurrentDirectory(), "wwwroot/Images",
                       imagepath);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }


                pathToReturn = Request.Scheme + "://" + Request.Host.Value + "/" + "Images/" + imagepath;

            }
            return Ok(pathToReturn);


        }


    }
}