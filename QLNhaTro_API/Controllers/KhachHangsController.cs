using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using QLNhaTro_API.Helper;
using QLNhaTro_API.Models;
using System.Data.Entity.Migrations;

namespace QLNhaTro_API.Controllers
{
    public class KhachHangsController : BaseController
    {
        private DBQLNhaTro db = new DBQLNhaTro();

        // GET: KhachHangs
        public ActionResult Index()
        {
            return View(db.KhachHangs.ToList());
        }

        // GET: KhachHangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // GET: KhachHangs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KhachHangs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdKhachHang,HoTen,Sdt,GioiTinh,QueQuan,HKTT,SoCMND")] KhachHang khachHang, HttpPostedFileBase fileUpload)
        {
            if (ModelState.IsValid)
            {
                ////var khachhang = db.KhachHangs.Where(p => p.Sdt == khachHang.Sdt).SingleOrDefault();
                //if (khachhang!=null || fileUpload == null)
                //{
                //    ViewBag.Error = "Khách hàng đã tồn tại";
                //    return View(khachHang);
                //}
                if (fileUpload != null)
                {
                    var extension = Path.GetExtension(fileUpload.FileName);
                    if (!fileUpload.ContentType.Contains("image"))
                    { 
                        ViewBag.Error1 = "File hình không hợp lệ";
                        return View(khachHang);
                        throw new Exception("File hình không hợp lệ");
                    }
                    if (fileUpload.ContentLength > 3 * 1024 * 1024) throw new Exception("Hình ảnh vượt quá 3Mb");
                    String _FileName = null;
                    _FileName = Path.GetFileName(RemoveVietnamese.convertToSlug(khachHang.HoTen.ToLower()) + "-anhCMND" + extension);
                    string _path = Path.Combine(Server.MapPath("~/Content/imgCMND/"), _FileName);
                    fileUpload.SaveAs(_path);
                    khachHang.SoCMND ="/Content/imgCMND/" + _FileName;
                    db.KhachHangs.Add(khachHang);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(khachHang);
        }
            // GET: KhachHangs/Edit/5
            public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // POST: KhachHangs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdKhachHang,HoTen,Sdt,GioiTinh,QueQuan,HKTT,SoCMND")] KhachHang khachHang, HttpPostedFileBase fileUpload)
        {
            if (ModelState.IsValid)
            {
                KhachHang kh = db.KhachHangs.FirstOrDefault(p => p.IdKhachHang == khachHang.IdKhachHang);
                kh.HoTen = khachHang.HoTen;
                kh.Sdt = khachHang.Sdt;
                kh.GioiTinh = khachHang.GioiTinh;
                kh.QueQuan = khachHang.QueQuan;
                kh.HKTT = khachHang.HKTT;
                if (fileUpload != null)
                {
                    var extension = Path.GetExtension(fileUpload.FileName);
                    if (!fileUpload.ContentType.Contains("image"))
                    {
                        ViewBag.Error1 = "File hình không hợp lệ";
                        return View(khachHang);
                        throw new Exception("File hình không hợp lệ");
                    }
                    if (fileUpload.ContentLength > 3 * 1024 * 1024) throw new Exception("Hình ảnh vượt quá 3Mb");
                    String _FileName = null;
                    _FileName = Path.GetFileName(RemoveVietnamese.convertToSlug("-anhCMND" + extension));
                    string _path = Path.Combine(Server.MapPath("~/Content/imgCMND/"), _FileName);
                    fileUpload.SaveAs(_path);
                    kh.SoCMND = _FileName;

                }
                db.SaveChanges();
                return RedirectToAction("Index");
                //db.Entry(khachHang).State = EntityState.Modified;
                //db.SaveChanges();
                //return RedirectToAction("Index");
            }
            return View(khachHang);
        }

        // GET: KhachHangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // POST: KhachHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KhachHang khachHang = db.KhachHangs.Find(id);
            db.KhachHangs.Remove(khachHang);
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
