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
    public class WriterController : Controller
    {
        WriterManager wrt = new WriterManager(new EfWriterDal()); // AdminCategory ile yapı aynısı aslında
        WriterValidator wm = new WriterValidator();  // Addeydi ancak kuralları kullanmak için updatede kontrol etsin diye
        public ActionResult Index()
        {
            var  writer_deger=wrt.GetWriterList();
            return View(writer_deger);
        }
        [HttpGet]
        public ActionResult WriterAddCt()
        {
             return View();
        }
        [HttpPost]
        public ActionResult WriterAddCt(Writer wt_nesnesi)
        {
            // WriterValidation EN üstte tanımladım update de kullancak ortak nesne olsun
            ValidationResult results=wm.Validate(wt_nesnesi); // Üstteki doğrulamayı istediğim bilgileri result nesnesine validate olarak atıyorum.
            if (results.IsValid)
            {
                wrt.WriterAdd(wt_nesnesi);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
                return View();
            }
               
        }
        [HttpGet]
        public ActionResult WriterEdit(int id)
        {
            var writer_id=wrt.WriterGetByID(id);
            return View(writer_id);
        }
        [HttpPost]
        public ActionResult WriterEdit(Writer wt_nesne) // Hata var bakarsın
        {
            ValidationResult results = wm.Validate(wt_nesne);  // wm üstteki  Writervalidatordan geliyor
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
                
            }
            return View();
        }


    }
}