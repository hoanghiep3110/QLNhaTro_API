using QLNhaTro_API.Helper;
using QLNhaTro_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLNhaTro_API.Controllers
{
    public class AuthController : Controller
    {
        DBQLNhaTro db = new DBQLNhaTro();
        // GET: Auth
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection frm)
        {
            var userName = frm["userName"];
            var password = MD5Helper.MD5Hash(frm["password"]);

            if (String.IsNullOrEmpty(userName))
            {
                ViewData["Loi1"] = "Phải nhập tên đăng nhập";

            }
            else if (String.IsNullOrEmpty(password))
            {
                ViewData["Loi2"] = "Phải nhập mật khẩu";
            }
            else
            {
                TaiKhoan user = db.TaiKhoans.SingleOrDefault(u => u.Username == userName && u.Password == password );
                if (user != null)
                {

                    Session["UserAdmin"] = user.IdTaiKhoan;
                    Session["fullName"] = user.HoTen;
                    return RedirectToAction("Index", "Phongs");
                }
                else
                    ViewBag.ThongBao = "Sai tài khoản hoặc mật khẩu";
            }
            return View();

        }
        public ActionResult Logout()
        {
            Session["UserAdmin"] = "";
            Session["fullName"] = null;
            return RedirectToAction("Login", "Auth");

        }
    }
}