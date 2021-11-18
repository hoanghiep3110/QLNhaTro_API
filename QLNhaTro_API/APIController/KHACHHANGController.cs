﻿using QLNhaTro_API.Models;
using System;
using System.Linq;
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
        public IHttpActionResult Post(KhachHang khachHang)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Ok(new Message(0, "Thêm khách hàng không thành công. Vui lòng thử lại"));
                }
                db.KhachHangs.Add(khachHang);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return Ok(new Message(0, "Thêm khách hàng không thành công. Vui lòng thử lại"));
            }
            return Ok(new Message(1, "Thêm khách hàng thành công"));
        }

        // PUT: api/KHACHHANG/5
        [HttpPut]
        public IHttpActionResult Put(int id, KhachHang khachHang)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new Message(0, "Thay đổi thông tin thất bại. Vui lòng kiểm tra và thử lại"));
            }
            var khachhang = db.KhachHangs.Find(id);
            if (khachhang == null)
            {
                return Ok(new Message(2, "Không tìm khách hàng cần thay đổi thông tin. Vui lòng kiểm tra và thử lại"));
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

        // DELETE: api/KHACHHANG/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new Message(0, "Xoá thất bại. Vui lòng kiểm tra và thử lại"));
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return Ok(new Message(2, "Không tìm phòng cần xoá. Vui lòng kiểm tra và thử lại"));
            }
            db.KhachHangs.Remove(khachHang);
            db.SaveChanges();
            return Ok(new Message(1, "Xoá thành công"));
        }
    }
}