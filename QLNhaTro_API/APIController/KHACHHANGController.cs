using QLNhaTro_API.Helper;
using QLNhaTro_API.ModelAPI;
using QLNhaTro_API.Models;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace QLNhaTro_API.APIController
{
    public class KHACHHANGController : ApiController
    {
        private DBQLNhaTro db = new DBQLNhaTro();
        // GET: api/KHACHHANG
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(db.KhachHangs.ToList());
        }

        // GET: api/KHACHHANG/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            KhachHang khachHang = db.KhachHangs.SingleOrDefault(p => p.IdKhachHang == id);
            if (khachHang == null)
            {
                return BadRequest();
            }
            return Ok(khachHang);
        }

        // POST: api/KHACHHANG
        [HttpPost]
        public IHttpActionResult Post()
        {
            var file = HttpContext.Current.Request.Files[0].FileName;
            try
            {
                //if (!ModelState.IsValid)
                //{
                //    //if (fileUpload != null)
                //    //{
                //    //    var extension = Path.GetExtension(fileUpload.FileName);
                //    //    String _FileName = null;
                //    //    _FileName = Path.GetFileName(RemoveVietnamese.convertToSlug(khachHang.HoTen.ToLower()) + "-anhCMND" + extension);
                //    //    string _path = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/imgCMND/"), _FileName);
                //    //    fileUpload.SaveAs(_path);
                //    //    khachHang.SoCMND ="/Content/imgCMND/" + _FileName;
                //    //    db.KhachHangs.Add(khachHang);
                //    //    db.SaveChanges();
                //    //}
                //    //return Ok(new Message(0, "Thêm khách hàng không thành công. Vui lòng thử lại"));
                //}
                //Return
                return Ok(new Message(1, "Thêm khách hàng thành công"));
            }
            catch (Exception)
            {
                return Ok(new Message(0, "Thêm khách hàng không thành công. Vui lòng thử lại"));
            }
        }

        // PUT: api/KHACHHANG/5
        [HttpPut]
        public IHttpActionResult Put(int id, KhachHang khachHang)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Ok(new Message(0, "Thay đổi thông tin thất bại. Vui lòng kiểm tra và thử lại"));
                }
                var khachhang = db.KhachHangs.Find(id);
                if (khachhang == null)
                {
                    return Ok(new Message(2, "Không tìm thấy khách hàng cần thay đổi thông tin. Vui lòng kiểm tra và thử lại"));
                }
                khachhang.HoTen = khachHang.HoTen;
                khachhang.Sdt = khachHang.Sdt; ;
                khachhang.GioiTinh = khachHang.GioiTinh;
                khachhang.QueQuan = khachHang.QueQuan;
                khachhang.HKTT = khachHang.HKTT;
                khachhang.SoCMND = khachHang.SoCMND;
                db.SaveChanges();

                return Ok(new Message(1, "Thay đổi thông tin thành công"));
            }
            catch (Exception)
            {
                return Ok(new Message(0, "Thay đổi thông tin thất bại. Vui lòng kiểm tra và thử lại"));
            }
        }

        // DELETE: api/KHACHHANG/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Ok(new Message(0, "Xoá thất bại. Vui lòng kiểm tra và thử lại"));
                }
                KhachHang khachHang = db.KhachHangs.Find(id);
                if (khachHang == null)
                {
                    return Ok(new Message(2, "Không tìm thấy phòng cần xoá. Vui lòng kiểm tra và thử lại"));
                }
                db.KhachHangs.Remove(khachHang);
                db.SaveChanges();

                //Ret
                return Ok(new Message(1, "Xoá thành công"));
            }
            catch (Exception)
            {
                return Ok(new Message(0, "Xoá thất bại. Vui lòng kiểm tra và thử lại"));
            }
        }
    }
}
