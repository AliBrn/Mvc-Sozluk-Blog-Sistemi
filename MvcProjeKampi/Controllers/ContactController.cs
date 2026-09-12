using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact

        ContactManager cm=new ContactManager(new EfContactDal());
        ContactValidator cv_valid = new ContactValidator();
        public ActionResult Index()
        {
             var deger=cm.GetContactList();
            return View(deger);
        }

        // Update get metodunda nasıl mesajlar  ilk ilgil isayfaya yükleniyorsa bundada ilgili id ait mesaj contact details yüklencek sadece
        // Detay aslında update ilk adımı bunu yaptık.
        public ActionResult ContactDetails(int id)
        {
            var contact_value=cm.ContactGetByID(id);
            return View(contact_value);
        }

      

        public PartialViewResult MessageListMenu()   // Soldaki menü partial view taşıycaz Contactdeki
        { 
            return PartialView();
        }
    }
}