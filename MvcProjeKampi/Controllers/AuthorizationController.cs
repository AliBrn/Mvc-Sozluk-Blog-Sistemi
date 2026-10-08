using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.EntityFramework;
using Context = DataAccessLayer.Concrete.Context;

namespace MvcProjeKampi.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    [Authorize(Roles = "B,C")]
    public class AuthorizationController : Controller
    {
        AdminManager adm = new AdminManager(new EfAdminDal());

        // 1. Admin Listeleme (A, B ve C görebilir):
        public ActionResult Index()
        {
            var deger = adm.GetAllAdmins();
            return View(deger);
        }

        // 2. Yeni Admin Ekleme (SADECE B ve C ekleyebilir):
        [Authorize(Roles = "B,C")]
        [HttpGet]
        public ActionResult AdminAdd()
        {
            List<SelectListItem> roller;
            if (User.IsInRole("C"))
            {
                // Kurucu (C), A (Editör) veya B (Yönetici) rolünde admin ekleyebilir:
                roller = new List<SelectListItem>
                {
                    new SelectListItem { Text = "A - Editör", Value = "A" },
                    new SelectListItem { Text = "B - Yönetici", Value = "B" }
                };
            }
            else
            {
                // B rolü sadece A (Editör) ekleyebilir:
                roller = new List<SelectListItem>
                {
                    new SelectListItem { Text = "A - Editör", Value = "A" }
                };
            }
            ViewBag.Roller = roller;
            return View();
        }

        [Authorize(Roles = "B,C")]
        [HttpPost]
        public ActionResult AdminAdd(Admin admin)
        {
            // B rolü ekleme yapıyorsa rolü mutlaka 'A' (Editör) olarak sabitlenir:
            if (User.IsInRole("B") && !User.IsInRole("C"))
            {
                admin.AdminRole = "A";
            }
            else if (string.IsNullOrEmpty(admin.AdminRole) || admin.AdminRole == "C")
            {
                // Kurucu (C) tektir, yeni eklenen admin C olamaz, varsayılan B yapılır:
                admin.AdminRole = "B";
            }

            admin.AdminStatus = true; // Yeni eklenen admin varsayılan aktif başlar
            adm.AddAdmin(admin);      // Şifreyi otomatik PBKDF2 ile hashleyip kaydeder
            TempData["SweetAlertSuccess"] = "Yeni admin başarıyla eklendi.";
            return RedirectToAction("Index");
        }

        // 3. Yetki Değiştirme (SADECE C rolü yapabilir):
        [Authorize(Roles = "C")]
        [HttpGet]
        public ActionResult AdminUpdate(int id)
        {
            var admin = adm.GetAdminById(id);

            // Kurucu Admin (C) kendi rolünü veya başka bir C'yi değiştiremez:
            if (admin != null && admin.AdminRole == "C")
            {
                return RedirectToAction("Index");
            }

            // Güvenlik ve temiz arayüz için şifre kutusunda hash gösterilmesin:
            if (admin != null)
            {
                admin.AdminPassword = "";
            }

            List<SelectListItem> roller = new List<SelectListItem>
            {
                new SelectListItem { Text = "A - Editör", Value = "A" },
                new SelectListItem { Text = "B - Yönetici", Value = "B" }
            };
            ViewBag.Roller = roller;

            return View(admin);
        }

        [Authorize(Roles = "C")]
        [HttpPost]
        public ActionResult AdminUpdate(Admin admin)
        {
            var mevcutAdmin = adm.GetAdminById(admin.AdminID);

            // Kurucu C'nin rolü değiştirilemez
            if (mevcutAdmin != null && mevcutAdmin.AdminRole != "C")
            {
                mevcutAdmin.AdminUserName = admin.AdminUserName;
                mevcutAdmin.AdminRole = admin.AdminRole;

                // Eğer yeni bir şifre girilmişse hashleyip güncelle (boş bırakıldıysa eski şifre aynen kalır):
                if (!string.IsNullOrWhiteSpace(admin.AdminPassword))
                {
                    mevcutAdmin.AdminPassword = BusinessLayer.Helpers.PasswordHasher.HashPassword(admin.AdminPassword);
                }

                adm.UpdateAdmin(mevcutAdmin);
                TempData["SweetAlertSuccess"] = "Admin yetkisi ve bilgileri başarıyla güncellendi.";
            }

            return RedirectToAction("Index");
        }

        // 4. Admin Aktif Yapma (Hakkımızda sayfasındaki gibi sade ve güvenilir POST):
        [Authorize(Roles = "C")]
        [HttpPost]
        public ActionResult AktifYap(int id)
        {
            var admin = adm.GetAdminById(id);
            if (admin != null)
            {
                admin.AdminStatus = true;
                adm.UpdateAdmin(admin);
                TempData["SweetAlertSuccess"] = "Admin başarıyla aktif yapıldı.";
            }
            return RedirectToAction("Index");
        }

        // 5. Admin Pasif Yapma (Hakkımızda sayfasındaki gibi sade ve güvenilir POST):
        [Authorize(Roles = "C")]
        [HttpPost]
        public ActionResult PasifYap(int id)
        {
            var admin = adm.GetAdminById(id);
            // Kurucu Admin (C) pasif yapılamaz:
            if (admin != null && (string.IsNullOrWhiteSpace(admin.AdminRole) || admin.AdminRole.Trim().ToUpper() != "C"))
            {
                admin.AdminStatus = false;
                adm.UpdateAdmin(admin);
                TempData["SweetAlertSuccess"] = "Admin başarıyla pasif yapıldı.";
            }
            return RedirectToAction("Index");
        }

        // Geriye dönük uyumluluk için AdminDelete:
        [Authorize(Roles = "C")]
        public ActionResult AdminDelete(int id)
        {
            var admin = adm.GetAdminById(id);
            if (admin != null && (string.IsNullOrWhiteSpace(admin.AdminRole) || admin.AdminRole.Trim().ToUpper() != "C"))
            {
                admin.AdminStatus = !admin.AdminStatus;
                adm.UpdateAdmin(admin);
                TempData["SweetAlertSuccess"] = "Admin durumu başarıyla değiştirildi.";
            }
            return RedirectToAction("Index");
        }
    }
}