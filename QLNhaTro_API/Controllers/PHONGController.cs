using QLNhaTro_API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace QLNhaTro_API.Controllers
{
    public class PHONGController : ApiController
    {
        DBQLNhaTro db = new DBQLNhaTro();
        // GET: api/PHONG
        public IEnumerable<Phong> Get()
        {
            return db.Phongs.ToList();
        }

        // GET: api/PHONG/5
        public Phong Get(int id)
        {
            return db.Phongs.SingleOrDefault(p=>p.IdPhong == id);
        }

        // POST: api/PHONG
        public int Post(Phong phong)
        {
            db.Phongs.Add(phong);
            db.SaveChanges();
            return 1;
        }

        // PUT: api/PHONG/5
        public int Put(int id, Phong newPhong)
        {
            var phong = db.Phongs.Find(id);
            phong.TenPhong = newPhong.TenPhong;
            phong.TrangThai = newPhong.TrangThai;
            db.SaveChanges();
            return 1;
        }

        // DELETE: api/PHONG/5
        public int Delete(int id)
        {
            Phong phong = db.Phongs.Find(id);
            db.Phongs.Remove(phong);
            db.SaveChanges();
            return 1;
        }
    }
}
