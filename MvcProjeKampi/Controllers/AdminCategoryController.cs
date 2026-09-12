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
    public class AdminCategoryController : Controller
    {
        // GET: AdminCategory
        // Farklı bileşene geçtikçe dapper ya da api vs  az kod düzenlemesi için newden nesne alıyoruz

        CategoryManager cm = new CategoryManager(new EfCategoryDal());
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
        [HttpPost]
        public ActionResult CategoryAdd(Category nesne)
        {
            CategoryValidator cmv = new CategoryValidator();
            ValidationResult results = cmv.Validate(nesne);
            if(results.IsValid) {
                cm.CategoryAdd(nesne);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage); //  ismi ile mesaj getircek
                }
            }
                return View();
        }

        public ActionResult CategoryDelete(int id)
        {
            var silincek_id=cm.GetByID(id); // İlk başta kullanıcı controllerdan girdiği id karşılık nesneyi bulcaz daha sonra nesne silcez
            cm.CategoryRemove(silincek_id); // CategoryManager  kullandıgımız Iservice imza metot ismi
            // Aslında işlevi yapan  ICATEGORY dal  ancak burda gösterdiğimiz EF  sorgusu gibi kendi metotlarımız ISERVİCE tanımladıgımız
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CategoryEdit(int id) // Controller ismi ne olcağı önemsiz
        {
            var guncellencek_id= cm.GetByID(id);  // İçindeki metot  Service metot 

            return View(guncellencek_id); // Guncellencek id yi sayfaya yönlendiriyoruz o sayfada tüm bilgileri gösteriyoruz
        }
        [HttpPost]
        public ActionResult CategoryEdit(Category ctg)
        {
            cm.CategoryUpdate(ctg);
            return RedirectToAction("Index");
        }
    }
}