using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class ErrorPageController : Controller
    {
        // 403 - Yetkisiz Erişim
        public ActionResult Page403()
        {
            Response.StatusCode = 403;
            Response.TrySkipIisCustomErrors = true;
            return View("Page404");
        }

        // 404 - Sayfa Bulunamadı
        public ActionResult Page404()
        {
            Response.StatusCode = 404;
            Response.TrySkipIisCustomErrors = true;
            return View();
        }
    }
}