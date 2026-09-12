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
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MvcProjeKampi.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category  Geçiçi sürelik işlemden aldık

        CategoryManager cm=new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCategoryList()  // Listelemek için
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
        public ActionResult CategoryAdd(Category  ct)
        {
            //1- CategoryValidator Controller’da şu satır validator nesnesi oluşturuyor:
            // Şu satır formdan gelen ct nesnesini kontrol ediyor: ValidationResult validationResult = cvr.Validate(ct);
            CategoryValidator cvr = new CategoryValidator(); //  Boş bıraktıgımıda category validator kuralla
                                                             //  rı eklemen lazım burda bunu kullanmak lazım
            ValidationResult validationResult = cvr.Validate(ct); // Fluent Validaiton seçmezsen diğerini seçersen hata fırlatır kullancıya
            // Category Validator gele değere göre validate yapcak  ct yi
            if (validationResult.IsValid) // Doğrulanmışsa 
            {
                cm.CategoryAdd(ct);
                return RedirectToAction("GetCategoryList");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage); // Hatanın neden oldugunu bulamk için
                }
            }
            return View();
            //cm.CategoryAddBL(ct);
            // return RedirectToAction("GetCategoryList"); // GetCategoryList view gönderdik
            

//            CategoryValidator kuralları tanımlar.
//Controller formdan gelen veriyi validator ile kontrol eder.
//Hataları ModelState'e ekler.
//View da ValidationMessageFor ile bu hataları kullanıcıya gösterir.
        }
    }
}