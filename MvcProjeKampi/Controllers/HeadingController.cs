using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.WebPages.Html;
using SelectListItem = System.Web.Mvc.SelectListItem;


namespace MvcProjeKampi.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Head

        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm= new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var hm_liste = hm.HeadingList();
            return View(hm_liste);
        }
        [HttpGet]
       public ActionResult HeadingAdd()
        {
            // Kullanım mantıgı  Category Başlık Seçcen liste olarak diyelim
            // Listeden seç değer adı (nerden seçcen hm.Liste olarak()  yeni item oluşturup{ text value } atıp ToList yapcan)  
            List<SelectListItem> categoryvalue = (from x in cm.GetCategoryList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName, // Display kullanıcı görceği
                                                      Value = x.CategoryID.ToString() // Value member arka planda kullanılan
                                                  }).ToList();

            List<SelectListItem> writervalue = (from x in wm.GetWriterList()  // Kendi nesneden listele x. değeri o listeden seçiyor
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName,
                                                    Value = x.WriterID.ToString()
                                                }).ToList();
            
            ViewBag.ctgrvalue = categoryvalue;
            ViewBag.wrtvalue=writervalue;
            return View();

        }
        [HttpPost]
        public ActionResult HeadingAdd(Heading  hdg)
        {
            hdg.HeadingDate =DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingAdd(hdg);

            return RedirectToAction("Index");

        }

        [HttpGet]

        // hEADİNG İLE CONTENTDE STATUS EKLE add migrationla
        public ActionResult HeadingEdit(int id)
        {
            List<SelectListItem> category_deger = (from x in cm.GetCategoryList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();

            ViewBag.ctgrvalue = category_deger;


            var heading_value = hm.HeadingGetByID(id);
            return View(heading_value);

        }
           [HttpPost]
           public ActionResult HeadingEdit(Heading hdg)
           {
               hm.HeadingUpdate(hdg);
                return RedirectToAction("Index");
           }
        public ActionResult HeadingDelete(int id)
        {
            var heading_delete=hm.HeadingGetByID(id);
            heading_delete.HeadingStatus = false; // Burda false yaparız
            hm.HeadingRemove(heading_delete); // HeadingRemove update koydugumuz ordan güncellediğimizi çağrıyoruz
            return RedirectToAction("Index");
        }


        
    }
}