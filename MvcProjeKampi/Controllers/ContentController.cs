using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        ContentManager ctm = new ContentManager(new EfContentDal());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ContentByHeading(int id) // Solidi ezmemek için buraya taşıdık başlıga göre içerik getiriyon bu yüzden içerikle işlem yapıyon.
        {

            var content_values=ctm.GetListByHeadingID(id); //gelen başlık id göre content listesi getircen
            return View(content_values);
        }
    }
}