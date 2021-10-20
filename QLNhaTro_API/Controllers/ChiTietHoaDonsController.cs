using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLNhaTro_API.Models;

namespace QLNhaTro_API.Controllers
{
    public class ChiTietHoaDonsController : Controller
    {
        private DBQLNhaTro db = new DBQLNhaTro();

        // GET: ChiTietHoaDons
        public ActionResult Index()
        {
            var chiTietHoaDons = db.ChiTietHoaDons.Include(c => c.DichVu).Include(c => c.HoaDonDichVu);
            return View(chiTietHoaDons.ToList());
        }
        // GET: ChiTietHoaDons/Create
        public ActionResult Create()
        {
            ViewBag.IdDichVu = new SelectList(db.DichVus, "IdDichVu", "TenDichVu");
            ViewBag.IdHoaDon = new SelectList(db.HoaDonDichVus, "IdHoaDon", "TienThanhToan");
            return View();
        }

        // POST: ChiTietHoaDons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdHoaDon,IdDichVu,TuNgay,ToiNgay,ChiSoCu,ChiSoMoi")] ChiTietHoaDon chiTietHoaDon)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietHoaDons.Add(chiTietHoaDon);
                db.SaveChanges();
                return RedirectToAction("Index");
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
