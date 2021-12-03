using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using QLNhaTro_API.ModelAPI;
using QLNhaTro_API.Models;

namespace QLNhaTro_API.APIController
{
    public class THUEPHONGController : ApiController
    {
        private DBQLNhaTro db = new DBQLNhaTro();

        // GET: api/THUEPHONG
        [HttpGet]
        public IHttpActionResult Get()
        {
            List<ThuePhongAPI> list = new List<ThuePhongAPI>();
            var result = db.ThuePhongs.ToList();
            foreach (var item in result)
            {
                var thuephong = new ThuePhongAPI();
                thuephong.IdThue = item.IdThue;
                thuephong.IdKhachHang = item.IdKhachHang;
                thuephong.HoTen = item.KhachHang.HoTen;
                thuephong.IdPhong = item.IdPhong;
                thuephong.TenPhong = item.Phong.TenPhong;
                thuephong.TienDatCoc = item.TienDatCoc;
                thuephong.NgayBatDau = item.NgayBatDau;
                thuephong.NgayKetThuc = item.NgayKetThuc;
                thuephong.FileHopDong = item.FileHopDong;
                list.Add(thuephong);
            }
            return Ok(list);
        }

        // GET: api/THUEPHONG/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            ThuePhongAPI hopdong = new ThuePhongAPI();
            var result = db.ThuePhongs.SingleOrDefault(p => p.IdThue == id);
            if (result == null)
            {
                return NotFound();
            }
            hopdong.IdThue = result.IdThue;
            hopdong.IdKhachHang = result.IdKhachHang;
            hopdong.HoTen = result.KhachHang.HoTen;
            hopdong.IdPhong = result.IdPhong;
            hopdong.TenPhong = result.Phong.TenPhong;
            hopdong.TienDatCoc = result.TienDatCoc;
            hopdong.NgayBatDau = result.NgayBatDau;
            hopdong.NgayKetThuc = result.NgayKetThuc;
            hopdong.FileHopDong = result.FileHopDong;
            hopdong.LinkDownLoad = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + result.FileHopDong;
            //hopdong.LinkDownLoad = "https://f906-2402-800-6312-e032-29ca-d06e-69ff-2c47.ngrok.io" + result.FileHopDong;
            // Return
            return Ok(hopdong);
        }

        // POST: api/THUEPHONG
        [HttpPost]
        public IHttpActionResult Post(ThuePhong thuePhong)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Ok(new Message(0, "Thêm hợp đồng không thành công. Vui lòng thử lại"));
                }
                db.ThuePhongs.Add(thuePhong);

                db.SaveChanges();

                //Return
                return Ok(new Message(1, "Thêm phòng thành công"));
            }
            catch (Exception)
            {
                return Ok(new Message(0, "Thêm hợp đồng không thành công. Vui lòng thử lại"));
            }
        }

        // PUT: api/THUEPHONG/5
        [HttpPut]
        public IHttpActionResult Put(int id, ThuePhong newThuePhong)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Ok(new Message(0, "Thay đổi thông tin thất bại. Vui lòng kiểm tra và thử lại"));
                }
                var thuephong = db.ThuePhongs.Find(id);
                if (thuephong == null)
                {
                    return Ok(new Message(2, "Không tìm thấy hợp đồng cần thay đổi thông tin. Vui lòng kiểm tra và thử lại"));
                }
                thuephong.IdKhachHang = newThuePhong.IdKhachHang;
                thuephong.IdPhong = newThuePhong.IdPhong;
                thuephong.TienDatCoc = newThuePhong.TienDatCoc;
                thuephong.NgayBatDau = newThuePhong.NgayBatDau;
                thuephong.NgayKetThuc = newThuePhong.NgayKetThuc;
                db.SaveChanges();

                // Return
                return Ok(new Message(1, "Thay đổi thông tin thành công"));
            }
            catch (Exception)
            {
                return Ok(new Message(0, "Thay đổi thông tin thất bại. Vui lòng kiểm tra và thử lại"));
            }
        }

        // DELETE: api/THUEPHONG/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Ok(new Message(0, "Xoá thất bại. Vui lòng kiểm tra và thử lại"));
                }
                ThuePhong thuePhong = db.ThuePhongs.Find(id);
                if (thuePhong == null)
                {
                    return Ok(new Message(2, "Không tìm thấy hợp đồng cần xoá. Vui lòng kiểm tra và thử lại"));
                }
                db.ThuePhongs.Remove(thuePhong);
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
