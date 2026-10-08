using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [Authorize(Roles = "A,B,C")]
    public class GalleryController : Controller
    {
        ImageFileManager ifm=new ImageFileManager(new EfImageFileDal());
        public ActionResult Index()
        {
            var liste= ifm.GetImageFileList();
            return View(liste);
        }
    }
}