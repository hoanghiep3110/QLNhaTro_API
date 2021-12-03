using QLNhaTro_API.ModelAPI;
using QLNhaTro_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace QLNhaTro_API.APIController
{
    public class CHITIETHOADONController : ApiController
    {
        private DBQLNhaTro db = new DBQLNhaTro();
        // GET: api/CHITIETHOADON
        //[HttpGet]
        //public IHttpActionResult Get()

        //{
        //    List<ChiTietHoaDonAPI> list = new List<ChiTietHoaDonAPI>();
        //    var result = db.ChiTietHoaDons.ToList();
        //    foreach (var item in result)
        //    {
        //        var hoadon = new ChiTietHoaDonAPI();
        //        hoadon.IdHoaDon = item.IdHoaDon;
        //        hoadon.HoTen = item.HoaDonDichVu.KhachHang.HoTen;
        //        hoadon.IdDichVu = item.IdDichVu;
        //        hoadon.TenDichVu = item.DichVu.TenDichVu;
        //        hoadon.TuNgay = item.TuNgay;
        //        hoadon.ToiNgay = item.ToiNgay;
        //        hoadon.ChiSoCu = item.ChiSoCu;
        //        hoadon.ChiSoMoi = item.ChiSoMoi;
        //        hoadon.ThanhTien = item.ThanhTien;
        //        list.Add(hoadon);
        //    }
        //    return Ok(list);
        //}

        // GET: api/CHITIETHOADON
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var result = db.ChiTietHoaDons.Where(h => h.IdHoaDon == id).ToList();
            //ChiTietHoaDon chiTietHoaDon = db.ChiTietHoaDons.SingleOrDefault(p => p.IdHoaDon == id);
            if (result == null)
            {
                return NotFound();
            }
            List<ChiTietHoaDonAPI> list = new List<ChiTietHoaDonAPI>();
            foreach (var item in result)
            {
                var hoadon = new ChiTietHoaDonAPI();
                hoadon.IdHoaDon = item.IdHoaDon;
                hoadon.HoTen = item.HoaDonDichVu.KhachHang.HoTen;
                hoadon.IdDichVu = item.IdDichVu;
                hoadon.TenDichVu = item.DichVu.TenDichVu;
                hoadon.TuNgay = item.TuNgay;
                hoadon.ToiNgay = item.ToiNgay;
                hoadon.ChiSoCu = item.ChiSoCu;
                hoadon.ChiSoMoi = item.ChiSoMoi;
                hoadon.ThanhTien = item.ThanhTien;
                list.Add(hoadon);
            }
            return Ok(list);
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
                ChiTietHoaDon dichvu = db.ChiTietHoaDons.Where(d => d.IdHoaDon == id).FirstOrDefault();
                if (dichvu == null)
                {
                    int tien = db.DichVus.Where(t => t.IdDichVu == chiTietHoaDon.IdDichVu).Select(t => t.DonGia).FirstOrDefault();
                    chiTietHoaDon.IdHoaDon = id;
                    chiTietHoaDon.ThanhTien = (int)(tien * (chiTietHoaDon.ChiSoMoi - chiTietHoaDon.ChiSoCu));
                    db.ChiTietHoaDons.Add(chiTietHoaDon);
                }
                else if (dichvu.IdDichVu == chiTietHoaDon.IdDichVu)
                {
                    return Ok(new Message(3, "Hoá đơn đã tồn tại !"));

                }
                else
                {
                    int tien = db.DichVus.Where(t => t.IdDichVu == chiTietHoaDon.IdDichVu).Select(t => t.DonGia).FirstOrDefault();
                    chiTietHoaDon.IdHoaDon = id;
                    chiTietHoaDon.ThanhTien = (int)(tien * (chiTietHoaDon.ChiSoMoi - chiTietHoaDon.ChiSoCu));
                    db.ChiTietHoaDons.Add(chiTietHoaDon);

                }
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
        public IHttpActionResult Delete(int idhoadon, int iddichvu)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Ok(new Message(0, "Xoá thất bại. Vui lòng kiểm tra và thử lại"));
                }
                ChiTietHoaDon chiTietHoaDon = db.ChiTietHoaDons.Where(c => c.IdHoaDon== idhoadon && c.IdDichVu==iddichvu).FirstOrDefault();
                if (chiTietHoaDon == null)
                {
                    return Ok(new Message(2, "Không tìm thấy hoá đơn cần xoá. Vui lòng kiểm tra và thử lại"));
                }
                var hoadon = db.HoaDonDichVus.Where(c => c.IdHoaDon== idhoadon).FirstOrDefault();
                hoadon.TienThanhToan = hoadon.TienThanhToan - chiTietHoaDon.ThanhTien;
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
