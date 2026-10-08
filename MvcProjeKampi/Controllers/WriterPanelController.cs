using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [Authorize]
    public class WriterPanelController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        WriterValidator writer_valid = new WriterValidator();

        [HttpGet]
        public ActionResult WriterProfile()
        {
            string mail = (string)Session["WriterMail"] ?? User.Identity.Name;
            var yazar_bilgi = wm.GetWriterByMail(mail);
            if (yazar_bilgi == null)
            {
                return RedirectToAction("WriterLogin", "Login");
            }
            return View(yazar_bilgi);
        }

        // Yazar Kendi Profilini Günceller
        [HttpPost]
        public ActionResult WriterProfile(Writer wrt)
        {
            ValidationResult results = writer_valid.Validate(wrt);
            if (results.IsValid)
            {
                wm.WriterUpdate(wrt);
                // Menüdeki isim ve görselin güncellenmesi sağlanır:
                Session["WriterName"] = wrt.WriterName + " " + wrt.WriterSurName;
                Session["WriterImage"] = wrt.WriterImage;
                ViewBag.SuccessMessage = "Yazar bilgileri başarıyla güncellendi.";
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(wrt);
        }

        // Yazar Giriş Ekranındaki başlıklar 
        public ActionResult MyHeading()
        {
            string mail = (string)Session["WriterMail"] ?? User.Identity.Name;
            var writer_nesne = wm.GetWriterByMail(mail);
            if (writer_nesne == null)
            {
                return RedirectToAction("WriterLogin", "Login");
            }
            var heading_nesne = hm.GetListByWriter(writer_nesne.WriterID).Where(x => x.HeadingStatus == true).ToList();
            return View(heading_nesne);
        }

        [HttpGet]
        public ActionResult NewHeading()
        {
            var valuecategory = (from x in cm.GetCategoryList()
                                 select new SelectListItem
                                 {
                                     Text = x.CategoryName,
                                     Value = x.CategoryID.ToString()
                                 }).ToList();

            ViewBag.vlc = valuecategory;
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading hdg)
        {
            string mail = (string)Session["WriterMail"] ?? User.Identity.Name;
            var writer_nesne = wm.GetWriterByMail(mail);
            if (writer_nesne == null)
            {
                return RedirectToAction("WriterLogin", "Login");
            }

            hdg.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hdg.WriterID = writer_nesne.WriterID;
            hdg.HeadingStatus = true;
            hm.HeadingAdd(hdg);
            return RedirectToAction("MyHeading");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            string mail = (string)Session["WriterMail"] ?? User.Identity.Name;
            var writer_nesne = wm.GetWriterByMail(mail);
            if (writer_nesne == null)
            {
                return RedirectToAction("WriterLogin", "Login");
            }

            var valuecategory = (from x in cm.GetCategoryList()
                                 select new SelectListItem
                                 {
                                     Text = x.CategoryName,
                                     Value = x.CategoryID.ToString()
                                 }).ToList();

            ViewBag.vlc = valuecategory;
            var headingvalue = hm.HeadingGetByID(id);
            if (headingvalue == null || headingvalue.WriterID != writer_nesne.WriterID)
            {
                return RedirectToAction("MyHeading");
            }

            return View(headingvalue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading hdg)
        {
            string mail = (string)Session["WriterMail"] ?? User.Identity.Name;
            var writer_nesne = wm.GetWriterByMail(mail);
            if (writer_nesne == null)
            {
                return RedirectToAction("WriterLogin", "Login");
            }

            var headingvalue = hm.HeadingGetByID(hdg.HeadingID);
            if (headingvalue == null || headingvalue.WriterID != writer_nesne.WriterID)
            {
                return RedirectToAction("MyHeading");
            }

            headingvalue.HeadingName = hdg.HeadingName;
            headingvalue.CategoryID = hdg.CategoryID;
            hm.HeadingUpdate(headingvalue);

            return RedirectToAction("MyHeading");
        }

        public ActionResult DeleteHeading(int id)
        {
            string mail = (string)Session["WriterMail"] ?? User.Identity.Name;
            var writer_nesne = wm.GetWriterByMail(mail);
            if (writer_nesne == null)
            {
                return RedirectToAction("WriterLogin", "Login");
            }

            var heading_delete = hm.HeadingGetByID(id);
            if (heading_delete == null || heading_delete.WriterID != writer_nesne.WriterID)
            {
                return RedirectToAction("MyHeading");
            }

            heading_delete.HeadingStatus = false;
            hm.HeadingRemove(heading_delete);
            return RedirectToAction("MyHeading");
        }

        // Tüm Başlıkları listeler
        public ActionResult AllHeading(int sayfa = 1)
        {
            var tam_liste = hm.HeadingList().ToPagedList(sayfa, 4);
            return View(tam_liste);
        }
    }
}
