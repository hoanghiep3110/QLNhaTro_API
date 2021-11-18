using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using QLNhaTro_API.Models;

namespace QLNhaTro_API.APIController
{
    public class THUEPHONGController : ApiController
    {
        private DBQLNhaTro db = new DBQLNhaTro();
        // GET: api/THUEPHONG
        public IEnumerable<ThuePhong> Get()
        {
            return db.ThuePhongs.ToList();
        }

        // GET: api/THUEPHONG/5
        public ThuePhong Get(int id)
        {
            return db.ThuePhongs.SingleOrDefault(t => t.IdThue == id);
        }

        // POST: api/THUEPHONG
        public int Post(ThuePhong thuePhong)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return 0;
                }
                db.ThuePhongs.Add(thuePhong);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }
            return 1;
        }

        // PUT: api/THUEPHONG/5
        public int Put(int id, ThuePhong newThuePhong)
        {
            if (!ModelState.IsValid)
            {
                return 0;
            }
            var thuephong = db.ThuePhongs.Find(id);
            if (thuephong == null)
            {
                return -1;
            }
            thuephong.IdKhachHang = newThuePhong.IdKhachHang;
            thuephong.IdPhong = newThuePhong.IdPhong;
            thuephong.TienDatCoc = newThuePhong.TienDatCoc;
            thuephong.NgayBatDau = newThuePhong.NgayBatDau;
            thuephong.NgayKetThuc = newThuePhong.NgayKetThuc;
            db.SaveChanges();
            return 1;
        }

        // DELETE: api/THUEPHONG/5
        public int Delete(int id)
        {
            ThuePhong thuePhong = db.ThuePhongs.Find(id);
            db.ThuePhongs.Remove(thuePhong);
            db.SaveChanges();
            return 1;
        }
    }
}
