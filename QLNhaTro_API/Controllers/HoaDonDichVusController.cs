using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using QLNhaTro_API.Models;
using SelectPdf;

namespace QLNhaTro_API.Controllers
{
    public class HoaDonDichVusController : BaseController
    {
        private DBQLNhaTro db = new DBQLNhaTro();

        // GET: HoaDonDichVus
        public ActionResult Index()
        {
            var result = db.ChiTietHoaDons.ToList();
            foreach (var item in result)
            {
                int id = item.IdHoaDon;
                int tientong = db.ChiTietHoaDons.Where(p => p.IdHoaDon == id).Select(p => p.ThanhTien).Sum();
                HoaDonDichVu hoadon = db.HoaDonDichVus.SingleOrDefault(h => h.IdHoaDon == id);
                hoadon.TienThanhToan = tientong;
                db.SaveChanges();
            }
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



        //// GET: HoaDonDichVus/Create
        //public ActionResult Create()
        //{
        //    ViewBag.IdKhachHang = new SelectList(db.KhachHangs, "IdKhachHang", "HoTen");
        //    ViewBag.IdPhong = new SelectList(db.Phongs, "IdPhong", "TenPhong");
        //    ViewBag.IdTaiKhoan = new SelectList(db.TaiKhoans, "IdTaiKhoan", "HoTen");
        //    return View();
        //}

        //// POST: HoaDonDichVus/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "IdHoaDon,IdDichVu,IdTaiKhoan,IdPhong,IdKhachHang,TienThanhToan,TrangThaiThanhToan")] HoaDonDichVu hoaDonDichVu)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.HoaDonDichVus.Add(hoaDonDichVu);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.IdKhachHang = new SelectList(db.KhachHangs, "IdKhachHang", "HoTen", hoaDonDichVu.IdKhachHang);
        //    ViewBag.IdPhong = new SelectList(db.Phongs, "IdPhong", "TenPhong", hoaDonDichVu.IdPhong);
        //    ViewBag.IdTaiKhoan = new SelectList(db.TaiKhoans, "IdTaiKhoan", "HoTen", hoaDonDichVu.IdTaiKhoan);
        //    return View(hoaDonDichVu);
        //}

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

        public ActionResult Export()
        {
            HtmlToPdf converter = new HtmlToPdf();

            // set converter options
            converter.Options.PdfPageSize = PdfPageSize.A4;
            converter.Options.PdfPageOrientation = PdfPageOrientation.Portrait;
            converter.Options.MarginLeft = 10;
            converter.Options.MarginRight = 10;
            converter.Options.MarginTop = 20;
            converter.Options.MarginBottom = 20;

            var chitiethoadon = db.ChiTietHoaDons.ToList();

            var htmlPdf = base.RenderPartialToString("~/Views/Shared/PartialViewPdf.cshtml", chitiethoadon, ControllerContext);
            // create a new pdf document converting an html string
            PdfDocument doc = converter.ConvertHtmlString(htmlPdf);
            string fileName = string.Format("{0}.pdf", DateTime.Now.ToString("dd-MM-yyyy"));
            string pathFile = string.Format("{0}/{1}", Server.MapPath("~/Content/filePDF/"), fileName);
            doc.Save(pathFile);
            return Json(fileName, JsonRequestBehavior.AllowGet);
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
