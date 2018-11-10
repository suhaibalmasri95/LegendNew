using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Common.Controllers;
using Common.Interfaces;
using Common.Validations;
using Domain.Operations.Organization.Counrties;
using Domain.Entities.Organization;
using Microsoft.AspNetCore.Mvc;

namespace Legend.Controllers
{
    public class ExportOperation
    {
        public string FieldName;
        public List<dynamic> items;
    }

    public static class FakeClass
    {
        public static void Test<T>(List<T> f)
        {
            var sdssdf = f.First().GetType().Name;
            var count = f.Count();
        }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {

//            {
//                "items":

//        [
//	    	{"ID":1,"Name": "ahmad","CurrencyCode":"A"},
//	    	{"ID":2,"Name": "mohamamd","CurrencyCode":"A"},
//	    	{"ID":3,"Name": "sqhaib","CurrencyCode":"A"}
//		],
//		"FieldName":"Area"
//}
            return new string[] { "value1", "value2" };
        }
        [Route("Create")]
        [HttpPost]
        public IApiResult Create(ExportOperation operation)
        {
            var assemply = Assembly.Load("Domain");
            var type = assemply.GetType("Domain.Organization.Entities." + operation.FieldName);
            var listType = typeof(List<>).MakeGenericType(type);
            var newList = Activator.CreateInstance(listType) as IList;
            foreach (var item in operation.items)
            {
                var itemString = item.ToString();
                var testJson = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(itemString);
                // var test = testJson["ID"].ToString();
                // var tests = testJson["Name"].ToString();
                var newItem = Activator.CreateInstance(type);
                //Mapping Part
                newList.Add(newItem);
            }
            var ienumerableObject = newList as IEnumerable<object>;
            FakeClass.Test(ienumerableObject.ToList());
            throw new Exception();
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
