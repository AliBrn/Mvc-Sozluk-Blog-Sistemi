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
    [Authorize(Roles = "B,C")]
    public class AdminCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());

        // Kategori listesi
        public ActionResult Index()
        {
            var deger = cm.GetCategoryList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult CategoryAdd()
        {
            return View();
        }

        // Yeni kategori ekleme (POST)
        [HttpPost]
        public ActionResult CategoryAdd(Category nesne)
        {
            CategoryValidator cmv = new CategoryValidator();
            ValidationResult results = cmv.Validate(nesne);
            if (results.IsValid)
            {
                cm.CategoryAdd(nesne);
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

        // Kategori silme
        public ActionResult CategoryDelete(int id)
        {
            var silincek_id = cm.GetByID(id);
            cm.CategoryRemove(silincek_id);
            return RedirectToAction("Index");
        }

        // Kategori güncelleme (GET)
        [HttpGet]
        public ActionResult CategoryEdit(int id)
        {
            var guncellencek_id = cm.GetByID(id);
            return View(guncellencek_id);
        }

        // Kategori güncelleme (POST)
        [HttpPost]
        public ActionResult CategoryEdit(Category ctg)
        {
            cm.CategoryUpdate(ctg);
            return RedirectToAction("Index");
        }

        // Kategoriye ait başlıkları listeler
        public ActionResult ListHeadingsByCategory(int id)
        {
            var deger = hm.GetListByCategory(id);
            return View(deger);
        }
    }
}