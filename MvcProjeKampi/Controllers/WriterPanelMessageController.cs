using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [Authorize]
    public class WriterPanelMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator msw = new MessageValidator();

        // 1. Gelen Mesajlar (Arama kelimesi destekli):
        public ActionResult WriterInbox(string kelime)
        {
            string mail = (string)Session["WriterMail"] ?? User.Identity.Name;
            var gelen_message = mm.GetListInbox(mail);

            // Arama yapıldıysa kelimeye göre filtreler:
            if (!string.IsNullOrEmpty(kelime))
            {
                kelime = kelime.ToLower();
                gelen_message = gelen_message.Where(x =>
                    (x.Subject != null && x.Subject.ToLower().Contains(kelime)) ||
                    (x.MessageContent != null && x.MessageContent.ToLower().Contains(kelime)) ||
                    (x.SenderMail != null && x.SenderMail.ToLower().Contains(kelime))
                ).ToList();
            }

            return View(gelen_message);
        }

        // 2. Giden Mesajlar (Arama kelimesi destekli):
        public ActionResult WriterSendbox(string kelime)
        {
            string mail = (string)Session["WriterMail"] ?? User.Identity.Name;
            var giden_message = mm.GetListSendbox(mail);

            // Arama yapıldıysa kelimeye göre filtreler:
            if (!string.IsNullOrEmpty(kelime))
            {
                kelime = kelime.ToLower();
                giden_message = giden_message.Where(x =>
                    (x.Subject != null && x.Subject.ToLower().Contains(kelime)) ||
                    (x.MessageContent != null && x.MessageContent.ToLower().Contains(kelime)) ||
                    (x.ReceiverMail != null && x.ReceiverMail.ToLower().Contains(kelime))
                ).ToList();
            }

            return View(giden_message);
        }

        // 3. Gelen Mesaj Detayı (Açıldığında OTOMATİK OKUNDU yapılır):
        public ActionResult WriterMessageInboxDetails(int id)
        {
            var message_value = mm.GetMessageById(id);
            if (message_value == null)
            {
                return RedirectToAction("WriterInbox");
            }
            // Mesaj okunmamışsa otomatik okundu olarak işaretlenir:
            if (!message_value.MessageIsRead)
            {
                message_value.MessageIsRead = true;
                mm.MessageUpdate(message_value);
            }
            return View(message_value);
        }

        // 4. Giden Mesaj Detayı:
        public ActionResult WriterMessageSendboxDetails(int id)
        {
            var message_value = mm.GetMessageById(id);
            if (message_value == null)
            {
                return RedirectToAction("WriterSendbox");
            }
            return View(message_value);
        }

        // 5. Yazar Gelen Kutusundaki Okundu/Okunmadı Kutucuğu İçin POST Metodu (Yazar panelinde kalır):
        [HttpPost]
        public ActionResult MessageIsRead(int id, bool status)
        {
            var deger = mm.GetMessageById(id);
            if (deger != null)
            {
                deger.MessageIsRead = status;
                mm.MessageUpdate(deger);
            }
            return RedirectToAction("WriterInbox");
        }

        // 6. Sol Mesaj Menüsü (Toplam, giden, taslak sayıları):
        public PartialViewResult WriterMessageListMenu()
        {
            string mail = (string)Session["WriterMail"] ?? User.Identity.Name;

            // Gelen mesaj sayısı:
            var ToplamMesajGelen = mm.GetListInbox(mail).Count();
            ViewBag.Toplam_Mesaj = ToplamMesajGelen;

            // Giden mesaj sayısı:
            var ToplamMesajGonderilen = mm.GetListSendbox(mail).Count();
            ViewBag.Toplam_Mesaj_Gonderilen = ToplamMesajGonderilen;

            // Taslak mesaj sayısı:
            var ToplamTaslak = mm.GetListDraft(mail).Count();
            ViewBag.Toplam_Taslak = ToplamTaslak;

            return PartialView();
        }

        // 7. Yeni Mesaj Oluşturma (GET):
        [HttpGet]
        public ActionResult WriterMessageAdd()
        {
            return View();
        }

        // 8. Yeni Mesaj Oluşturma / Taslak Kaydetme (POST):
        [HttpPost]
        public ActionResult WriterMessageAdd(Message message, string btnAction)
        {
            string sendermail = (string)Session["WriterMail"] ?? User.Identity.Name;
            message.SenderMail = sendermail;
            message.MessageDate = DateTime.Now;

            if (btnAction == "draft")
            {
                // Taslak olarak kaydet:
                message.IsDraft = true;
                mm.MessageAdd(message);
                return RedirectToAction("WriterDraft");
            }
            else
            {
                // Normal mesaj olarak gönder:
                message.IsDraft = false;
                ValidationResult results = msw.Validate(message);
                if (results.IsValid)
                {
                    mm.MessageAdd(message);
                    return RedirectToAction("WriterSendbox");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                    return View(message);
                }
            }
        }

        // 9. Taslaklar Listesi (Arama kelimesi destekli):
        public ActionResult WriterDraft(string kelime)
        {
            string mail = (string)Session["WriterMail"] ?? User.Identity.Name;
            var draft_messages = mm.GetListDraft(mail);

            if (!string.IsNullOrEmpty(kelime))
            {
                kelime = kelime.ToLower();
                draft_messages = draft_messages.Where(x =>
                    (x.Subject != null && x.Subject.ToLower().Contains(kelime)) ||
                    (x.MessageContent != null && x.MessageContent.ToLower().Contains(kelime)) ||
                    (x.ReceiverMail != null && x.ReceiverMail.ToLower().Contains(kelime))
                ).ToList();
            }

            return View(draft_messages);
        }

        // 10. Taslak Düzenleme Sayfası (GET):
        [HttpGet]
        public ActionResult WriterDraftEdit(int id)
        {
            var message = mm.GetMessageById(id);
            if (message == null)
            {
                return RedirectToAction("WriterDraft");
            }
            return View(message);
        }

        // 11. Taslak Düzenleme / Gönderme (POST):
        [HttpPost]
        public ActionResult WriterDraftEdit(Message message, string btnAction)
        {
            string mail = (string)Session["WriterMail"] ?? User.Identity.Name;
            message.SenderMail = mail;
            message.MessageDate = DateTime.Now;

            if (btnAction == "draft")
            {
                // Tekrar taslak olarak günceller:
                message.IsDraft = true;
                mm.MessageUpdate(message);
                return RedirectToAction("WriterDraft");
            }
            else
            {
                // Normal mesaj gibi gönderilir:
                message.IsDraft = false;
                ValidationResult results = msw.Validate(message);
                if (results.IsValid)
                {
                    mm.MessageUpdate(message);
                    return RedirectToAction("WriterSendbox");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                    return View(message);
                }
            }
        }

        // 12. Taslak Silme:
        public ActionResult WriterDraftDelete(int id)
        {
            var message = mm.GetMessageById(id);
            if (message != null)
            {
                mm.MessageRemove(message);
            }
            return RedirectToAction("WriterDraft");
        }
    }
}