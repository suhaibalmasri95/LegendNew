using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Operations.Organization.Cities;
using Domain.Operations.Organization.Counrties;
using Domain.Organization.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Legend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        [Route("Create")]
        [HttpGet]
        public async void  CreateAsync()
        {
            CreateCountry ex = new CreateCountry();
            ex.Name = "tessdsds";
            ex.Nationality = "jod";
            ex.CurrencyCode = "JOD";
            ex.PhoneCode = "test";
            ex.Status = 1;
            await ex.Execute();
          
           
            
        }


        [Route("Create2")]
        [HttpGet]
        public List<Country> C()
        {
            var test = new List<Country>();
            test.Add(new Country() {ID = 5 });
            test.Add(new Country() { ID = 5 });
            test.Add(new Country() { ID = 5 });
            test.Add(new Country() { ID = 5 });
            test.Add(new Country() { ID = 5 });
            return test;
        }


        //[Route("Create2")]
        //[HttpGet]
        //public async Task<IEnumerable> CreateAsync2()
        //{
        //    GetCountries ex = new GetCountries();
        //    ex.ID = 42;
        //    ex.LangID = 1;
        //    var ss = await ex.Query().i;
            
        //}


        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
