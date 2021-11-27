using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLNhaTro_API.Helper;
using QLNhaTro_API.Models;

namespace QLNhaTro_API.Controllers
{
    public class ThuePhongsController : BaseController
    {
        private DBQLNhaTro db = new DBQLNhaTro();

        // GET: ThuePhongs
        public ActionResult Index()
        {
            var thuePhongs = db.ThuePhongs.Include(t => t.KhachHang).Include(t => t.Phong);
            return View(thuePhongs.ToList());
        }

        // GET: ThuePhongs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThuePhong thuePhong = db.ThuePhongs.Find(id);
            if (thuePhong == null)
            {
                return HttpNotFound();
            }
            return View(thuePhong);
        }

        // GET: ThuePhongs/Create
        public ActionResult Create()
        {
            ViewBag.IdKhachHang = new SelectList(db.KhachHangs, "IdKhachHang", "HoTen");
            ViewBag.IdPhong = new SelectList(db.Phongs, "IdPhong", "TenPhong");
            return View();
        }

        // POST: ThuePhongs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdThue,IdKhachHang,IdPhong,TienDatCoc,NgayBatDau,NgayKetThuc")] ThuePhong thuePhong, HttpPostedFileBase fileUpload)
        {
            if (ModelState.IsValid)
            {
                Phong phong = db.Phongs.Find(thuePhong.IdPhong);
                if (phong.IdPhong == thuePhong.IdPhong)
                {
                    phong.TrangThai = 1;
                }
                db.ThuePhongs.Add(thuePhong);
                if (fileUpload != null)
                {
                    string khachang = db.KhachHangs.Find(thuePhong.IdKhachHang).HoTen;
                    var extension = Path.GetExtension(fileUpload.FileName);
                    string fileName = Path.GetFileName(RemoveVietnamese.convertToSlug(khachang) + "-fileHopDong" + extension);
                    thuePhong.FileHopDong = "/Content/fileHopDong/" + fileName;
                    fileUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/fileHopDong/"), fileName));
                }
                AddInvoice(thuePhong.IdPhong, thuePhong.IdKhachHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdKhachHang = new SelectList(db.KhachHangs, "IdKhachHang", "HoTen", thuePhong.IdKhachHang);
            ViewBag.IdPhong = new SelectList(db.Phongs, "IdPhong", "TenPhong", thuePhong.IdPhong);
            return View(thuePhong);
        }

        // GET: ThuePhongs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThuePhong thuePhong = db.ThuePhongs.Find(id);
            if (thuePhong == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdKhachHang = new SelectList(db.KhachHangs, "IdKhachHang", "HoTen", thuePhong.IdKhachHang);
            ViewBag.IdPhong = new SelectList(db.Phongs, "IdPhong", "TenPhong", thuePhong.IdPhong);
            return View(thuePhong);
        }

        // POST: ThuePhongs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdThue,IdKhachHang,IdPhong,TienDatCoc,NgayBatDau,NgayKetThuc")] ThuePhong thuePhong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thuePhong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdKhachHang = new SelectList(db.KhachHangs, "IdKhachHang", "HoTen", thuePhong.IdKhachHang);
            ViewBag.IdPhong = new SelectList(db.Phongs, "IdPhong", "TenPhong", thuePhong.IdPhong);
            return View(thuePhong);
        }

        // GET: ThuePhongs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThuePhong thuePhong = db.ThuePhongs.Find(id);
            if (thuePhong == null)
            {
                return HttpNotFound();
            }
            return View(thuePhong);
        }

        // POST: ThuePhongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ThuePhong thuePhong = db.ThuePhongs.Find(id);
            db.ThuePhongs.Remove(thuePhong);
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

        //Hàm thêm hoá đơn
        public void AddInvoice(int idphong, int idkhachhang)
        {
            var hoadon = new HoaDonDichVu();
            //var user = new TaiKhoan();
            hoadon.IdTaiKhoan  = int.Parse(Session["UserAdmin"].ToString());
            hoadon.IdKhachHang = idkhachhang;
            hoadon.IdPhong = idphong;
            hoadon.TienThanhToan = 0;
            hoadon.TrangThaiThanhToan = false;
            db.HoaDonDichVus.Add(hoadon);
        }

        public ActionResult upFile(int id, HttpPostedFileBase fileUpload)
        {
            db.SaveChanges();
            return View(fileUpload);

        }
    }
}
