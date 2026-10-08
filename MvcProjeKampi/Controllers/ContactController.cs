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
    [Authorize(Roles = "A,B,C")]
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidator cv_valid = new ContactValidator();
        MessageManager mm = new MessageManager(new EfMessageDal());

        // Arama destekli ziyaretçi iletişim mesajları listesi
        public ActionResult Index(string kelime)
        {
            var deger = cm.GetContactList();

            if (!string.IsNullOrEmpty(kelime))
            {
                kelime = kelime.ToLower();
                deger = deger.Where(x =>
                    (x.UserName != null && x.UserName.ToLower().Contains(kelime)) ||
                    (x.UserMail != null && x.UserMail.ToLower().Contains(kelime)) ||
                    (x.Subject != null && x.Subject.ToLower().Contains(kelime)) ||
                    (x.Message != null && x.Message.ToLower().Contains(kelime))
                ).ToList();
            }

            return View(deger);
        }

        // İletişim mesajı detayı (Açıldığında otomatik okundu işaretlenir)
        public ActionResult ContactDetails(int id)
        {
            var contact_value = cm.ContactGetByID(id);
            if (contact_value != null && !contact_value.IsRead)
            {
                contact_value.IsRead = true;
                cm.ContactUpdate(contact_value);
            }
            return View(contact_value);
        }



        [HttpPost]
        public ActionResult ContactIsRead(int id, bool isRead)
        {
            var deger = cm.ContactGetByID(id);

            deger.IsRead = isRead;

            cm.ContactUpdate(deger);

            return RedirectToAction("Index");
        }


        // İletişim ve mesajlaşma sol menüsü (Sayaçlar)
        public PartialViewResult MessageListMenu()
        {
            // Burası tamamen Admin paneline ait olduğu için Admin'in mailini alıyoruz:
            string mail = (string)Session["AdminUserName"];

            var toplamMesaj = cm.GetContactList().Count();
            ViewBag.toplam_mesaj = toplamMesaj;

            var toplamMesajAdmin = mm.GetListInbox(mail).Count();
            ViewBag.toplam_mesaj_admin = toplamMesajAdmin;

            var toplamMesajGonderilen = mm.GetListSendbox(mail).Count();
            ViewBag.toplam_mesaj_gonderilen = toplamMesajGonderilen;

            // YENİ EKLENEN: Taslak mesajların toplam sayısı
            var toplamMesajTaslak = mm.GetListDraft(mail).Count();
            ViewBag.toplam_mesaj_taslak = toplamMesajTaslak;

            return PartialView();
        }



    }
}