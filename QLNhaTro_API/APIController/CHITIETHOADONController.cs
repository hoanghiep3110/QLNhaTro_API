using QLNhaTro_API.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace QLNhaTro_API.APIController
{
    public class CHITIETHOADONController : ApiController
    {
        private DBQLNhaTro db = new DBQLNhaTro();
        // GET: api/CHITIETHOADON
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(db.ChiTietHoaDons.ToList());
        }

        // GET: api/CHITIETHOADON
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            ChiTietHoaDon chiTietHoaDon = db.ChiTietHoaDons.SingleOrDefault(p => p.IdHoaDon == id);
            if (chiTietHoaDon == null)
            {
                return NotFound();
            }
            return Ok(chiTietHoaDon);
        }
        //POST: api/CHITIETHOADON
       [HttpPost]
        public IHttpActionResult Post(int id, ChiTietHoaDon chiTietHoaDon)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Ok(new Message(0, "Thêm hoá đơn không thành công. Vui lòng thử lại"));
                }
                chiTietHoaDon.IdHoaDon = id;
                db.ChiTietHoaDons.Add(chiTietHoaDon);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return Ok(new Message(0, "Thêm hoá đơn không thành công. Vui lòng thử lại"));
            }
            return Ok(new Message(1, "Thêm hoá đơn thành công"));
        }
        // PUT: api/CHITIETHOADON/5
        [HttpPut]
        public IHttpActionResult Put(int id, ChiTietHoaDon newchiTietHoaDon)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Ok(new Message(0, "Thay đổi thông tin thất bại. Vui lòng kiểm tra và thử lại"));
                }
                var chitiethoadon = db.ChiTietHoaDons.Find(id);
                if (chitiethoadon == null)
                {
                    return Ok(new Message(2, "Không tìm thấy hoá đơn cần thay đổi thông tin. Vui lòng kiểm tra và thử lại"));
                }
                chitiethoadon.IdDichVu = newchiTietHoaDon.IdDichVu;
                chitiethoadon.TuNgay = newchiTietHoaDon.TuNgay;
                chitiethoadon.ToiNgay = newchiTietHoaDon.ToiNgay;
                chitiethoadon.ChiSoCu = newchiTietHoaDon.ChiSoCu;
                chitiethoadon.ChiSoMoi = newchiTietHoaDon.ChiSoMoi;
                db.SaveChanges();

                //Return
                return Ok(new Message(1, "Thay đổi thông tin thành công"));
            }
            catch (Exception)
            {
                return Ok(new Message(0, "Thay đổi thông tin thất bại. Vui lòng kiểm tra và thử lại"));
            }

        }
        // DELETE: api/CHITIETHOADON/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Ok(new Message(0, "Xoá thất bại. Vui lòng kiểm tra và thử lại"));
                }
                ChiTietHoaDon chiTietHoaDon = db.ChiTietHoaDons.Find(id);
                if (chiTietHoaDon == null)
                {
                    return Ok(new Message(2, "Không tìm thấy hoá đơn cần xoá. Vui lòng kiểm tra và thử lại"));
                }
                db.ChiTietHoaDons.Remove(chiTietHoaDon);
                db.SaveChanges();
                return Ok(new Message(1, "Xoá thành công"));
            }
            catch (Exception)
            {
                return Ok(new Message(0, "Xoá thất bại. Vui lòng kiểm tra và thử lại"));
            }
        }
    }
}
