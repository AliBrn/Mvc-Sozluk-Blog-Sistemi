using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [Authorize]
    public class ContentController : Controller
    {
        
        ContentManager ctm = new ContentManager(new EfContentDal());

        // Başlığa ait içerikleri listeler
        public ActionResult ContentByHeading(int id)
        {
            var content_values = ctm.GetListByHeadingID(id);
            return View(content_values);
        }

        // Arama parametresine göre tüm içerikleri listeler
        [Authorize(Roles = "A,B,C")]
        public ActionResult GetAllContent(string parametre)
        {
            var sonuc = ctm.ContentList(parametre);
            return View(sonuc);
        }
    }
}