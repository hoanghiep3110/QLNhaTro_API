using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QLNhaTro_API.Models;

namespace QLNhaTro_API.APIController
{
    public class HOADONController : ApiController
    {
        private DBQLNhaTro db = new DBQLNhaTro();
        // GET: api/HOADON
        public IEnumerable<HoaDonDichVu> Get()
        {
            return db.HoaDonDichVus.ToList();
        }

        // GET: api/HOADON/5
        public HoaDonDichVu Get(int id)
        {
            return db.HoaDonDichVus.SingleOrDefault(h => h.IdHoaDon == id);
        }

        // POST: api/HOADON
        public int Post(HoaDonDichVu hoaDon)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return 0;
                }
                db.HoaDonDichVus.Add(hoaDon);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }
            return 1;
        }

        // PUT: api/HOADON/5
        public int Put(int id, HoaDonDichVu newHoaDon)
        {
            if (!ModelState.IsValid)
            {
                return 0;
            }
            var hoadon = db.HoaDonDichVus.Find(id);
            if (hoadon == null)
            {
                return -1;
            }
            hoadon.IdTaiKhoan = newHoaDon.IdTaiKhoan;
            hoadon.IdPhong = newHoaDon.IdPhong;
            hoadon.IdKhachHang = newHoaDon.IdKhachHang;
            hoadon.TienThanhToan = newHoaDon.TienThanhToan;
            hoadon.TrangThaiThanhToan = newHoaDon.TrangThaiThanhToan;
            db.SaveChanges();
            return 1;
        }

        // DELETE: api/HOADON/5
        public int Delete(int id)
        {
            HoaDonDichVu hoaDon = db.HoaDonDichVus.Find(id);
            db.HoaDonDichVus.Remove(hoaDon);
            db.SaveChanges();
            return 1;
        }
    
    }
}
