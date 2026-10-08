using Antlr.Runtime.Misc;
using BusinessLayer.Concrete;
using BusinessLayer.Helpers;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Services.Description;
using System.Web.UI.WebControls;
namespace MvcProjeKampi.Controllers
{

    [AllowAnonymous]
    public class LoginController : Controller
    {
        // Admin Giriş Sayfası (GET)
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // Admin Giriş İşlemi (POST)
        [HttpPost]
        public ActionResult Index(Admin deger)
        {
            AdminManager adm = new AdminManager(new EfAdminDal());

            var admin_nesnesi = adm.GetAdminByUserNamePassword(
                deger.AdminUserName,
                deger.AdminPassword
            );

            if (admin_nesnesi != null)
            {
                FormsAuthentication.SetAuthCookie(admin_nesnesi.AdminUserName, false);
                Session["AdminUserName"] = admin_nesnesi.AdminUserName;
                Session["AdminRole"] = admin_nesnesi.AdminRole;

                // Editör (A) rolü kategorileri göremediği için doğrudan Başlıklar'a yönlenir:
                if (admin_nesnesi.AdminRole == "A")
                {
                    return RedirectToAction("Index", "Heading");
                }

                // Yönetici (B) ve Kurucu (C) kategoriler sayfasına yönlenir:
                return RedirectToAction("Index", "AdminCategory");
            }

            ViewBag.ErrorMessage = "Hatalı kullanıcı adı/şifre veya hesabınız pasif durumda!";
            return View();
        }

        // Yazar Giriş Sayfası (GET)
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }

        [HttpPost]

        public ActionResult WriterLogin(Writer wrt)
        {
            WriterManager wm = new WriterManager(new EfWriterDal());

            // Kullanıcı adı ve şifreye göre yazar kaydını doğrular
            var nesne = wm.GetWriterByUserNamePassword(wrt.WriterMail, wrt.WriterPassword);
            if (nesne != null)
            {
                FormsAuthentication.SetAuthCookie(nesne.WriterMail, false);
                Session["WriterMail"] = nesne.WriterMail;
                Session["WriterName"] = nesne.WriterName + " " + nesne.WriterSurName; // Menüde yazar adını dinamik göstermek için
                Session["WriterImage"] = nesne.WriterImage; // Menüde yazar görselini dinamik göstermek için
                return RedirectToAction("MyContent", "WriterPanelContent");
            }

            ViewBag.ErrorMessage = "Hatalı e-posta adresi veya şifre girdiniz!";
            return View();
        }

        // Çıkış Yapma İşlemi
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut(); /* Kullanıcının giriş oturumunu kapatır */
            Session.Abandon(); /* Kullanıcının Session bilgisini tamamen sonlandırır */
            Session.Clear();

            // Kimlik doğrulama biletini (cookie) tarayıcıdan kesin olarak siler:
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie);

            // Çıkış yapınca ana vitrin sayfasına yönlendirir:
            return RedirectToAction("HomePage", "Home");
        }

        // Yazar Şifremi Unuttum (GET)
        [HttpGet]
        public ActionResult WriterForgotPassword()
        {
            return View();
        }

        // Yazar Şifremi Unuttum (POST)
        [HttpPost]
        public ActionResult WriterForgotPassword(string writerMail, string newPassword, string confirmPassword)
        {
            if (string.IsNullOrWhiteSpace(writerMail) || string.IsNullOrWhiteSpace(newPassword) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                ViewBag.ErrorMessage = "Lütfen tüm alanları doldurunuz.";
                return View();
            }

            if (newPassword.Trim() != confirmPassword.Trim())
            {
                ViewBag.ErrorMessage = "Şifreler eşleşmiyor. Lütfen iki şifreyi de aynı giriniz.";
                return View();
            }

            if (newPassword.Trim().Length < 4)
            {
                ViewBag.ErrorMessage = "Şifre en az 4 karakter olmalıdır.";
                return View();
            }

            WriterManager wm = new WriterManager(new EfWriterDal());
            var writer = wm.GetWriterByMail(writerMail.Trim());

            if (writer == null)
            {
                ViewBag.ErrorMessage = "Bu e-posta adresine kayıtlı bir yazar hesabı bulunamadı!";
                return View();
            }

            writer.WriterPassword = newPassword.Trim();
            wm.WriterUpdate(writer);

            TempData["ResetSuccess"] = "Şifreniz başarıyla güncellendi. Yeni şifrenizle giriş yapabilirsiniz.";
            return RedirectToAction("WriterLogin");
        }

        // Admin Şifremi Unuttum (GET)
        [HttpGet]
        public ActionResult AdminForgotPassword()
        {
            return View();
        }

        // Admin Şifremi Unuttum (POST)
        [HttpPost]
        public ActionResult AdminForgotPassword(string adminUserName, string newPassword, string confirmPassword)
        {
            if (string.IsNullOrWhiteSpace(adminUserName) || string.IsNullOrWhiteSpace(newPassword) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                ViewBag.ErrorMessage = "Lütfen tüm alanları doldurunuz.";
                return View();
            }

            if (newPassword.Trim() != confirmPassword.Trim())
            {
                ViewBag.ErrorMessage = "Şifreler eşleşmiyor. Lütfen iki şifreyi de aynı giriniz.";
                return View();
            }

            if (newPassword.Trim().Length < 4)
            {
                ViewBag.ErrorMessage = "Şifre en az 4 karakter olmalıdır.";
                return View();
            }

            AdminManager adm = new AdminManager(new EfAdminDal());
            var admin = adm.GetAdminByUserName(adminUserName.Trim());

            if (admin == null)
            {
                ViewBag.ErrorMessage = "Bu kullanıcı adı / e-posta ile kayıtlı bir yönetici hesabı bulunamadı!";
                return View();
            }

            admin.AdminPassword = PasswordHasher.HashPassword(newPassword.Trim());
            adm.UpdateAdmin(admin);

            TempData["ResetSuccess"] = "Yönetici şifreniz başarıyla güncellendi. Yeni şifrenizle giriş yapabilirsiniz.";
            return RedirectToAction("Index");
        }
    }
}