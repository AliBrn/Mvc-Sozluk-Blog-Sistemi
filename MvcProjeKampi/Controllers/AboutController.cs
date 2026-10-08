using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [Authorize(Roles = "A,B,C")]
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager(new EfAboutDal());

        // Hakkımızda yazıları listesi
        public ActionResult Index()
        {
            var deger = abm.AboutList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult AboutAdd()
        {
            return View();
        }

        // Yeni hakkımızda yazısı ekleme
        [HttpPost]
        public ActionResult AboutAdd(About abt)
        {
            abt.AboutStatus = true;
            abm.AboutAdd(abt);
            return RedirectToAction("Index");
        }

        // Ekleme modalı için partial view
        public PartialViewResult AboutPartial()  
        {
            return PartialView();
        }

        // Hakkımızda kaydını aktif duruma getirir
        [HttpPost]
        public ActionResult AktifYap(int id)
        {
            var deger = abm.AboutGetByID(id);
            deger.AboutStatus = true;
            abm.AboutUpdate(deger);
            return RedirectToAction("Index");
        }

        // Hakkımızda kaydını pasif duruma getirir
        [HttpPost]
        public ActionResult PasifYap(int id)
        {
            var deger = abm.AboutGetByID(id);
            deger.AboutStatus = false;
            abm.AboutUpdate(deger);
            return RedirectToAction("Index");
        }
    }
}