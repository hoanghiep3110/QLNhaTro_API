using QLNhaTro_API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace QLNhaTro_API.Controllers
{
    public class PHONGController : ApiController
    {
        DBQLNhaTro db = new DBQLNhaTro();
        // GET: api/Phong
        public IEnumerable<Phong> Get()
        {
            return db.Phongs.ToList();
        }

        // GET: api/Phong/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Phong
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Phong/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Phong/5
        public void Delete(int id)
        {
        }
    }
}
