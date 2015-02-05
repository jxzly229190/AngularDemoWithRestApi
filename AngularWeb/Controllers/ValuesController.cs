using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeamManager.Models;

namespace AngularWeb.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public ResponseModel Get()
        {
            var strs = new string[] { "value1", "value2" };

            return new ResponseModel() { state = 0, data = strs, msg="ok" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
