using QLNhaTro_API.Helper;
using QLNhaTro_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace QLNhaTro_API.APIController
{
    public class TAIKHOANController : ApiController
    {
        DBQLNhaTro db = new DBQLNhaTro();
        // GET: api/TAIKHOAN
        public IEnumerable<TaiKhoan> Get()
        {
            return db.TaiKhoans.ToList();
        }

        // GET: api/TAIKHOAN/5
        public TaiKhoan Get(int id)
        {
            return db.TaiKhoans.SingleOrDefault(p => p.IdTaiKhoan == id);
        }

        // POST: api/TAIKHOAN
        public int Post(TaiKhoan taiKhoan)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return 0;
                }
                db.TaiKhoans.Add(taiKhoan);
                taiKhoan.Password = MD5Helper.MD5Hash(taiKhoan.Password);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }
            return 1;
        }

        // PUT: api/TAIKHOAN/5
        public int Put(int id, TaiKhoan newTaikhoan)
        {
            if (!ModelState.IsValid)
            {
                return 0;
            }
            var taiKhoan = db.TaiKhoans.Find(id);
            if(taiKhoan == null)
            {
                return -1;
            }
            taiKhoan.HoTen = newTaikhoan.HoTen;
            taiKhoan.Sdt = newTaikhoan.Sdt;
            taiKhoan.DiaChi = newTaikhoan.DiaChi;
            taiKhoan.Username = newTaikhoan.Username;
            taiKhoan.Password = MD5Helper.MD5Hash(newTaikhoan.Password);
            db.SaveChanges();
            return 1;
        }

        // DELETE: api/TAIKHOAN/5
        public int Delete(int id)
        {
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            db.TaiKhoans.Remove(taiKhoan);
            db.SaveChanges();
            return 1;
        }
    }
}
