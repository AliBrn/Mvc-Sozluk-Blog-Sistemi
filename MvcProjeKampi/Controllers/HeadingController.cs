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
    [Authorize(Roles = "A,B,C")]
    public class HeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());

        // Tüm başlıkları listeler
        public ActionResult Index()
        {
            var hm_liste = hm.HeadingList();
            return View(hm_liste);
        }

        // Yeni başlık ekleme (GET)
        [HttpGet]
        public ActionResult HeadingAdd()
        {
            List<SelectListItem> categoryvalue = (from x in cm.GetCategoryList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();

            List<SelectListItem> writervalue = (from x in wm.GetWriterList()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName,
                                                    Value = x.WriterID.ToString()
                                                }).ToList();
            
            ViewBag.ctgrvalue = categoryvalue;
            ViewBag.wrtvalue = writervalue;
            return View();
        }

        // Yeni başlık ekleme (POST)
        [HttpPost]
        public ActionResult HeadingAdd(Heading hdg)
        {
            hdg.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hdg.HeadingStatus = true;
            hm.HeadingAdd(hdg);

            return RedirectToAction("Index");
        }

        // Başlık düzenleme (GET)
        [HttpGet]
        public ActionResult HeadingEdit(int id)
        {
            List<SelectListItem> category_deger = (from x in cm.GetCategoryList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();

            ViewBag.ctgrvalue = category_deger;

            var yazar_listesi = (from x in wm.GetWriterList()
                                 select new SelectListItem
                                 {
                                     Text = x.WriterName,
                                     Value = x.WriterID.ToString()
                                 }).ToList();
            ViewBag.yzrvalue = yazar_listesi;

            var heading_value = hm.HeadingGetByID(id);
            return View(heading_value);
        }

        // Başlık düzenleme (POST)
        [HttpPost]
        public ActionResult HeadingEdit(Heading hdg)
        {
            hm.HeadingUpdate(hdg);
            return RedirectToAction("Index");
        }

        // Başlık silme (Pasife çekme)
        public ActionResult HeadingDelete(int id)
        {
            var heading_delete = hm.HeadingGetByID(id);
            heading_delete.HeadingStatus = false;
            hm.HeadingRemove(heading_delete);
            return RedirectToAction("Index");
        }

        // Başlık raporlama listesi
        public ActionResult HeadingReport()
        {
            var deger = hm.HeadingList();
            return View(deger);
        }
    }
}