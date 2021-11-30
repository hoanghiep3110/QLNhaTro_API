﻿using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using QLNhaTro_API.Models;

namespace QLNhaTro_API.Controllers
{
    public class ChiTietHoaDonsController : BaseController
    {
        private DBQLNhaTro db = new DBQLNhaTro();

        // GET: ChiTietHoaDons
        public ActionResult Index()
        {
            var result = db.ChiTietHoaDons.ToList();
            foreach (var item in result)
            {
                int id = item.IdDichVu;
                int idhd = item.IdHoaDon;
                int tien = db.DichVus.Where(t => t.IdDichVu == id).Select(t => t.DonGia).FirstOrDefault();
                //int chisocu = int.Parse(db.ChiTietHoaDons.Where(c => c.IdDichVu == id).Select(c => c.ChiSoCu).ToString());
                //int chisomoi = int.Parse(db.ChiTietHoaDons.Where(c => c.IdDichVu == id).Select(c => c.ChiSoMoi).ToString());
                int thanhtien = tien;
                ChiTietHoaDon hoadon = db.ChiTietHoaDons.SingleOrDefault(h => h.IdHoaDon == idhd && h.IdDichVu == id);
                hoadon.ThanhTien = thanhtien;
                db.SaveChanges();
            }
            var chiTietHoaDons = db.ChiTietHoaDons.Include(c => c.DichVu).Include(c => c.HoaDonDichVu);
            return View(chiTietHoaDons.ToList());
        }
        //GET: ChiTietHoaDons/Create
        public ActionResult Create()
        {
            ViewBag.IdDichVu = new SelectList(db.DichVus, "IdDichVu", "TenDichVu");
            ViewBag.IdHoaDon = new SelectList(db.HoaDonDichVus, "IdHoaDon","IdHoaDon");
            return View();
        }

        // POST: ChiTietHoaDons/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdHoaDon,IdDichVu,TuNgay,ToiNgay,ChiSoCu,ChiSoMoi")] ChiTietHoaDon chiTietHoaDon)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietHoaDons.Add(chiTietHoaDon);
                db.SaveChanges();
                return RedirectToAction("Detail", "HoaDonDichVus");
            }

            ViewBag.IdDichVu = new SelectList(db.DichVus, "IdDichVu", "TenDichVu", chiTietHoaDon.IdDichVu);
            ViewBag.IdHoaDon = new SelectList(db.HoaDonDichVus, "IdHoaDon", "TienThanhToan", chiTietHoaDon.IdHoaDon);
            return View(chiTietHoaDon);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
