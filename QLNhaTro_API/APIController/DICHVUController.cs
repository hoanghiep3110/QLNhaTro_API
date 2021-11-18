using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using QLNhaTro_API.Models;

namespace QLNhaTro_API.APIController
{
    public class DICHVUController : ApiController
    {
        private DBQLNhaTro db = new DBQLNhaTro();
        // GET: api/DICHVU
        public IEnumerable<DichVu> Get()
        {
            return db.DichVus.ToList();
        }

        // GET: api/DICHVU/5
        public DichVu Get(int id)
        {
            return db.DichVus.SingleOrDefault(d => d.IdDichVu == id);
        }

        // POST: api/DICHVU
        public int Post(DichVu dichVu)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return 0;
                }
                db.DichVus.Add(dichVu);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }
            return 1;
        }

        // PUT: api/DICHVU/5
        public int Put(int id, DichVu newDichVu)
        {
            if (!ModelState.IsValid)
            {
                return 0;
            }
            var dichvu = db.DichVus.Find(id);
            if (dichvu == null)
            {
                return -1;
            }
            dichvu.TenDichVu = newDichVu.TenDichVu;
            dichvu.DonGia = newDichVu.DonGia;
            db.SaveChanges();
            return 1;
        }

        // DELETE: api/DICHVU/5
        public int Delete(int id)
        {
            DichVu dichVu = db.DichVus.Find(id);
            db.DichVus.Remove(dichVu);
            db.SaveChanges();
            return 1;
        }
    }
}
