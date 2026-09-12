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
    public class AboutController : Controller
    {
        // GET: About

        AboutManager abm = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            var deger=abm.AboutList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult AboutAdd()
        {
            return View();
        }
        [HttpPost]

        public ActionResult AboutAdd(About abt)
        {
            abm.AboutAdd(abt);
            return RedirectToAction("Index");
        }

        // Parçalı ViewDöndürme anı, View oluşturuken de   partial view create tıklarsın
        public PartialViewResult AboutPartial()  
        {
            return PartialView();
        }

    }
}