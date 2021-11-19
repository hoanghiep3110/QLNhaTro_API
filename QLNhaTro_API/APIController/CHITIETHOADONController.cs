using QLNhaTro_API.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace QLNhaTro_API.APIController
{
    public class CHITIETHOADONController : ApiController
    {
        private DBQLNhaTro db = new DBQLNhaTro();
        // GET: api/CHITIETHOADON
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CHITIETHOADON/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CHITIETHOADON
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CHITIETHOADON/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CHITIETHOADON/5
        public void Delete(int id)
        {
        }
    }
}
