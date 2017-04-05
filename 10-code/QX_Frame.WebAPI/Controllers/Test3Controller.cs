using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QX_Frame.WebAPI.Controllers
{
    public class Test3Controller : ApiController
    {
        // GET: api/Test3
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Test3/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Test3
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Test3/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Test3/5
        public void Delete(int id)
        {
        }
    }
}
