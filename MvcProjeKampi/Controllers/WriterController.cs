using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [Authorize(Roles = "A,B,C")]
    public class WriterController : Controller
    {
        WriterManager wrt = new WriterManager(new EfWriterDal());
        WriterValidator wm = new WriterValidator();
        HeadingManager hm = new HeadingManager(new EfHeadingDal());

        // Yazarlar listesi
        public ActionResult Index()
        {
            var writer_deger = wrt.GetWriterList();
            return View(writer_deger);
        }

        // Yeni yazar ekleme (GET)
        [HttpGet]
        public ActionResult WriterAddCt()
        {
            return View();
        }

        // Yeni yazar ekleme (POST)
        [HttpPost]
        public ActionResult WriterAddCt(Writer wt_nesnesi)
        {
            ValidationResult results = wm.Validate(wt_nesnesi);
            if (results.IsValid)
            {
                wrt.WriterAdd(wt_nesnesi);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }

        // Yazar profili düzenleme (GET)
        [HttpGet]
        public ActionResult WriterEdit(int id)
        {
            var writer_id = wrt.WriterGetByID(id);
            return View(writer_id);
        }

        // Yazar profili düzenleme (POST)
        [HttpPost]
        public ActionResult WriterEdit(Writer wt_nesne)
        {
            ValidationResult results = wm.Validate(wt_nesne);
            if (results.IsValid)
            {
                wrt.WriterUpdate(wt_nesne);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }

        // Seçilen yazara ait başlıkları listeler
        public ActionResult ListHeadingsByWriter(int id)
        {
            var writer = wrt.WriterGetByID(id);
            if (writer != null)
            {
                ViewBag.WriterName = writer.WriterName + " " + writer.WriterSurName;
            }
            var deger = hm.GetListByWriter(id);
            return View(deger);
        }
    }
}