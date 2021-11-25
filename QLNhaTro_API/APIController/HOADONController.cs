﻿using System;
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
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(db.HoaDonDichVus.ToList());
        }

        // GET: api/HOADON/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            HoaDonDichVu hoaDonDichVu = db.HoaDonDichVus.SingleOrDefault(p => p.IdHoaDon == id);
            if(hoaDonDichVu == null)
            {
                return NotFound();
            }
            return Ok(hoaDonDichVu);
        }

        // POST: api/HOADON
        [HttpPost]
        public IHttpActionResult Post(HoaDonDichVu hoaDon)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Ok(new Message(0, "Thêm hoá đơn không thành công. Vui lòng thử lại"));
                }
                db.HoaDonDichVus.Add(hoaDon);
                db.SaveChanges();

                //Return
                return Ok(new Message(1, "Thêm hoá đơn thành công"));
            }
            catch (Exception)
            {
                return Ok(new Message(0, "Thêm hoá đơn không thành công. Vui lòng thử lại"));
            }
            
        }

        // PUT: api/HOADON/5
        [HttpPut]
        public IHttpActionResult Put(int id, HoaDonDichVu newHoaDon)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Ok(new Message(0, "Thay đổi thông tin thất bại. Vui lòng kiểm tra và thử lại"));
                }
                var hoadon = db.HoaDonDichVus.Find(id);
                if (hoadon == null)
                {
                    return Ok(new Message(2, "Không tìm thấy hoá đơn cần thay đổi thông tin. Vui lòng kiểm tra và thử lại"));
                }
                hoadon.IdTaiKhoan = newHoaDon.IdTaiKhoan;
                hoadon.IdPhong = newHoaDon.IdPhong;
                hoadon.IdKhachHang = newHoaDon.IdKhachHang;
                hoadon.TienThanhToan = newHoaDon.TienThanhToan;
                hoadon.TrangThaiThanhToan = newHoaDon.TrangThaiThanhToan;
                db.SaveChanges();

                //Return
                return Ok(new Message(1, "Thay đổi thông tin thành công"));
            }
            catch(Exception)
            {
                return Ok(new Message(0, "Thay đổi thông tin thất bại. Vui lòng kiểm tra và thử lại"));
            }
        }

        // DELETE: api/HOADON/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Ok(new Message(0, "Xoá thất bại. Vui lòng kiểm tra và thử lại"));
                }
                HoaDonDichVu hoaDon = db.HoaDonDichVus.Find(id);
                if (hoaDon == null)
                {
                    return Ok(new Message(2, "Không tìm thấy hoá đơn cần xoá. Vui lòng kiểm tra và thử lại"));
                }
                db.HoaDonDichVus.Remove(hoaDon);
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
