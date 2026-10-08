using Antlr.Runtime.Misc;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        ContactManager contactManager = new ContactManager(new EfContactDal());
        ContactValidator contactValidator = new ContactValidator();

        [AllowAnonymous]
        public ActionResult Index()
        {
            return RedirectToAction("HomePage");
        }

        [AllowAnonymous]
        public ActionResult HomePage()
        {
            using (var c = new DataAccessLayer.Concrete.Context())
            {
                ViewBag.HeadingCount = c.Headings.Count(x => x.HeadingStatus == true);
                ViewBag.ContentCount = c.Contents.Count(x => x.ContentStatus == true);
                ViewBag.WriterCount = c.Writers.Count(x => x.WriterStatus == true);
                ViewBag.MessageCount = c.Messages.Count();
            }

            return View();
        }


        // Vitrinden yeni yazar kayıt işlemi (POST)
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult WriterRegister(Writer writer, string WriterPasswordRepeat)
        {
            if (string.IsNullOrWhiteSpace(writer.WriterName) ||
                string.IsNullOrWhiteSpace(writer.WriterSurName) ||
                string.IsNullOrWhiteSpace(writer.WriterMail) ||
                string.IsNullOrWhiteSpace(writer.WriterPassword))
            {
                TempData["RegisterError"] = "Lütfen zorunlu alanları doldurunuz.";
                return RedirectToAction("HomePage");
            }

            if (writer.WriterPassword != WriterPasswordRepeat)
            {
                TempData["RegisterError"] = "Şifreler eşleşmiyor.";
                return RedirectToAction("HomePage");
            }

            var existingWriter = writerManager.GetWriterByMail(writer.WriterMail);

            if (existingWriter != null)
            {
                TempData["RegisterError"] = "Bu e-posta adresiyle zaten bir hesap var.";
                return RedirectToAction("HomePage");
            }

            writer.WriterStatus = true;
            writerManager.WriterAdd(writer);

            TempData["RegisterSuccess"] = true;

            return RedirectToAction("HomePage");
        }

        // Vitrinden iletişim/destek formu gönderimi (POST)
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult SupportRequest(Contact contact)
        {
            var result = contactValidator.Validate(contact);

            if (!result.IsValid)
            {
                TempData["ContactError"] = result.Errors.First().ErrorMessage;
                return RedirectToAction("HomePage");
            }

            contact.ContactDate = DateTime.Now;
            contact.IsRead = false;

            contactManager.ContactAdd(contact);

            TempData["ContactSuccess"] = true;

            return RedirectToAction("HomePage");
        }
    }
}