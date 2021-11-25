using QLNhaTro_API.Helper;
using QLNhaTro_API.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace QLNhaTro_API.APIController
{
    public class TAIKHOANController : ApiController
    {
        DBQLNhaTro db = new DBQLNhaTro();
        // GET: api/TAIKHOAN
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(db.TaiKhoans.ToList());
        }

        // GET: api/TAIKHOAN/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            TaiKhoan taiKhoan = db.TaiKhoans.SingleOrDefault(p => p.IdTaiKhoan == id);
            if (taiKhoan == null)
            {
                return BadRequest();
            }
            return Ok(taiKhoan);
        }

        // POST: api/TAIKHOAN
        [HttpPost]
        public IHttpActionResult Post(TaiKhoan taiKhoan)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Ok(new Message(0, "Thêm tài khoản không thành công. Vui lòng thử lại"));
                }
                taiKhoan.Password = MD5Helper.MD5Hash(taiKhoan.Password);
                db.TaiKhoans.Add(taiKhoan);
                db.SaveChanges();

                //Return
                return Ok(new Message(1, "Thêm tài khoản thành công"));
            }
            catch (Exception)
            {
                return Ok(new Message(0, "Thêm tài khoản không thành công. Vui lòng thử lại"));
            }
        }

        // PUT: api/TAIKHOAN/5
        [HttpPut]
        public IHttpActionResult Put(int id, TaiKhoan newTaikhoan)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Ok(new Message(0, "Thay đổi thông tin thất bại. Vui lòng kiểm tra và thử lại"));
                }
                var taiKhoan = db.TaiKhoans.Find(id);
                if (taiKhoan == null)
                {
                    return Ok(new Message(2, "Không tìm tài khoản cần thay đổi thông tin. Vui lòng kiểm tra và thử lại"));
                }
                taiKhoan.HoTen = newTaikhoan.HoTen;
                taiKhoan.Sdt = newTaikhoan.Sdt;
                taiKhoan.DiaChi = newTaikhoan.DiaChi;
                taiKhoan.Username = newTaikhoan.Username;
                taiKhoan.Password = MD5Helper.MD5Hash(newTaikhoan.Password);
                db.SaveChanges();

                //Return
                return Ok(new Message(1, "Thay đổi thông tin thành công"));
            }
            catch (Exception)
            {
                return Ok(new Message(0, "Thay đổi thông tin thất bại. Vui lòng kiểm tra và thử lại"));
            }
        }

        // DELETE: api/TAIKHOAN/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Ok(new Message(0, "Xoá thất bại. Vui lòng kiểm tra và thử lại"));
                }
                TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
                if (taiKhoan == null)
                {
                    return Ok(new Message(2, "Không tìm thấy tài khoản cần xoá. Vui lòng kiểm tra và thử lại"));
                }
                db.TaiKhoans.Remove(taiKhoan);
                db.SaveChanges();

                //Return
                return Ok(new Message(1, "Xoá thành công"));
            }
            catch (Exception)
            {
                return Ok(new Message(0, "Xoá thất bại. Vui lòng kiểm tra và thử lại"));
            }
        }
    }
}
