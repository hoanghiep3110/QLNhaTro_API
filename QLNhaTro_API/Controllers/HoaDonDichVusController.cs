using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using QLNhaTro_API.Models;

namespace QLNhaTro_API.Controllers
{
    public class HoaDonDichVusController : BaseController
    {
        private DBQLNhaTro db = new DBQLNhaTro();

        // GET: HoaDonDichVus
        public ActionResult Index()
        {
            var hoaDonDichVus = db.HoaDonDichVus.Include(h => h.KhachHang).Include(h => h.Phong).Include(h => h.TaiKhoan);
            return View(hoaDonDichVus.ToList());
        }

        // GET: HoaDonDichVus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<ChiTietHoaDon> chiTietHoaDon = db.ChiTietHoaDons.Where(u => u.IdHoaDon == id).ToList();
            if (chiTietHoaDon == null)
            {
                return HttpNotFound();
            }
            return View(chiTietHoaDon);
        }

        // GET: HoaDonDichVus/Create
        public ActionResult Create()
        {
            ViewBag.IdKhachHang = new SelectList(db.KhachHangs, "IdKhachHang", "HoTen");
            ViewBag.IdPhong = new SelectList(db.Phongs, "IdPhong", "TenPhong");
            ViewBag.IdTaiKhoan = new SelectList(db.TaiKhoans, "IdTaiKhoan", "HoTen");
            return View();
        }

        // POST: HoaDonDichVus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdHoaDon,IdDichVu,IdTaiKhoan,IdPhong,IdKhachHang,TienThanhToan,TrangThaiThanhToan")] HoaDonDichVu hoaDonDichVu)
        {
            if (ModelState.IsValid)
            {
                db.HoaDonDichVus.Add(hoaDonDichVu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdKhachHang = new SelectList(db.KhachHangs, "IdKhachHang", "HoTen", hoaDonDichVu.IdKhachHang);
            ViewBag.IdPhong = new SelectList(db.Phongs, "IdPhong", "TenPhong", hoaDonDichVu.IdPhong);
            ViewBag.IdTaiKhoan = new SelectList(db.TaiKhoans, "IdTaiKhoan", "HoTen", hoaDonDichVu.IdTaiKhoan);
            return View(hoaDonDichVu);
        }

        // GET: HoaDonDichVus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonDichVu hoaDonDichVu = db.HoaDonDichVus.Find(id);
            if (hoaDonDichVu == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdKhachHang = new SelectList(db.KhachHangs, "IdKhachHang", "HoTen", hoaDonDichVu.IdKhachHang);
            ViewBag.IdPhong = new SelectList(db.Phongs, "IdPhong", "TenPhong", hoaDonDichVu.IdPhong);
            ViewBag.IdTaiKhoan = new SelectList(db.TaiKhoans, "IdTaiKhoan", "HoTen", hoaDonDichVu.IdTaiKhoan);
            return View(hoaDonDichVu);
        }

        // POST: HoaDonDichVus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdHoaDon,IdDichVu,IdTaiKhoan,IdPhong,IdKhachHang,TienThanhToan,TrangThaiThanhToan")] HoaDonDichVu hoaDonDichVu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoaDonDichVu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdKhachHang = new SelectList(db.KhachHangs, "IdKhachHang", "HoTen", hoaDonDichVu.IdKhachHang);
            ViewBag.IdPhong = new SelectList(db.Phongs, "IdPhong", "TenPhong", hoaDonDichVu.IdPhong);
            ViewBag.IdTaiKhoan = new SelectList(db.TaiKhoans, "IdTaiKhoan", "HoTen", hoaDonDichVu.IdTaiKhoan);
            return View(hoaDonDichVu);
        }

        // GET: HoaDonDichVus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonDichVu hoaDonDichVu = db.HoaDonDichVus.Find(id);
            if (hoaDonDichVu == null)
            {
                return HttpNotFound();
            }
            return View(hoaDonDichVu);
        }

        // POST: HoaDonDichVus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HoaDonDichVu hoaDonDichVu = db.HoaDonDichVus.Find(id);
            List<ChiTietHoaDon> chiTietHoaDon = db.ChiTietHoaDons.Where(u => u.IdHoaDon == id).ToList();
            foreach (var item in chiTietHoaDon)
            {
                db.ChiTietHoaDons.Remove(item);
            }
            db.HoaDonDichVus.Remove(hoaDonDichVu);
            db.SaveChanges();
            return RedirectToAction("Index");
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
