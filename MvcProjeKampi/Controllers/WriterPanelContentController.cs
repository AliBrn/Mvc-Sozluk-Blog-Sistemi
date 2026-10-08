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
    [Authorize]
    public class WriterPanelContentController : Controller
    {
        ContentManager ctm = new ContentManager(new EfContentDal());
        WriterManager wm = new WriterManager(new EfWriterDal());

        // Yazarın Kendi Yazıları (İçerikleri)
        public ActionResult MyContent()
        {
            string mail = (string)Session["WriterMail"] ?? User.Identity.Name;
            var writer = wm.GetWriterByMail(mail);
            if (writer == null)
            {
                return RedirectToAction("WriterLogin", "Login");
            }
            var contents = ctm.GetListByWriter(writer.WriterID);
            return View(contents);
        }

        // Başlığa Yeni İçerik Yazma (GET)
        [HttpGet]
        public ActionResult ContentAdd(int id)
        {
            ViewBag.deger = id;
            return View();
        }

        // Başlığa Yeni İçerik Yazma (POST)
        [HttpPost]
        public ActionResult ContentAdd(Content cnt)
        {
            string mail = (string)Session["WriterMail"] ?? User.Identity.Name;
            var writer = wm.GetWriterByMail(mail);
            if (writer == null)
            {
                return RedirectToAction("WriterLogin", "Login");
            }

            cnt.WriterID = writer.WriterID;
            cnt.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            cnt.ContentStatus = true;
            ctm.ContentAdd(cnt);
            return RedirectToAction("MyHeading", "WriterPanel");
        }
    }
}