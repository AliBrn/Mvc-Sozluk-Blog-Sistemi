using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        HeadingManager hdm = new HeadingManager(new EfHeadingDal());
        ContentManager cm = new ContentManager(new EfContentDal());

        // Sözlük Vitrini: Tüm başlıkları listeler
        public ActionResult Headings()
        {
            var deger = hdm.HeadingList();
            return View(deger);
        }

        // Seçilen başlığa ait içerikleri (entry listesi) getirir
        public PartialViewResult Index(int id = 2)
        {
            var contentlist = cm.GetListByHeadingID(id);
            return PartialView(contentlist);
        }
    }
}
