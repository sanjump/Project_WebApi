using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Project_WebApi.DAL;

namespace Project_WebApi.Controllers
{
    public class ValuesController : ApiController
    {
        Customer_DAL dl = new Customer_DAL();
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet]
        [ActionName("CustomerGet1")]
        public customer CustomerGet1(string id)
        {
            customer obj1 = dl.GetCustomerById(id);
            return obj1;
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
