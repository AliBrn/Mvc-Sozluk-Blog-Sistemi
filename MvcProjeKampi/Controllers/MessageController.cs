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
    [Authorize(Roles = "A,B,C")]
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator msw = new MessageValidator();

        // Gelen mesaj detayı (Açıldığında okundu olarak işaretlenir)
        public ActionResult MessageInboxDetails(int id)
        {
            var message_value = mm.GetMessageById(id);
            if (message_value != null && !message_value.MessageIsRead)
            {
                message_value.MessageIsRead = true;
                mm.MessageUpdate(message_value);
            }
            return View(message_value);
        }

        // Giden mesaj detayı
        public ActionResult MessageSendboxDetails(int id)
        {
            var message_value = mm.GetMessageById(id);
            return View(message_value);
        }

        [HttpGet]
        public ActionResult MessageAdd()
        {
            return View();
        }

        // Yeni mesaj gönderme veya taslağa kaydetme (POST)
        [HttpPost]
        public ActionResult MessageAdd(Message message, string btnAction) 
        {
            string adminMail = (string)Session["AdminUserName"];
            message.SenderMail = adminMail;
            message.MessageDate = DateTime.Now;

            if (btnAction == "draft")
            {
                message.IsDraft = true;
                mm.MessageAdd(message);
                return RedirectToAction("Draft");
            }
            else
            {
                message.IsDraft = false;
                ValidationResult results = msw.Validate(message);
                if (results.IsValid)
                {
                    mm.MessageAdd(message);
                    return RedirectToAction("Sendbox");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                    return View();
                }
            }
        }

        // Taslak mesajlar listesi (Arama kelimesi destekli)
        [Authorize]
        public ActionResult Draft(string kelime)
        {
            string mail = (string)Session["AdminUserName"];
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

        // Taslak düzenleme (GET)
        [HttpGet]
        public ActionResult DraftEdit(int id)
        {
            var message = mm.GetMessageById(id);
            return View(message);
        }

        // Taslak güncelleme veya gönderme (POST)
        [HttpPost]
        public ActionResult DraftEdit(Message message, string btnAction)
        {
            string adminMail = (string)Session["AdminUserName"];
            message.SenderMail = adminMail;
            message.MessageDate = DateTime.Now;

            if (btnAction == "draft")
            {
                message.IsDraft = true;
                mm.MessageUpdate(message);
                return RedirectToAction("Draft");
            }
            else
            {
                message.IsDraft = false;
                ValidationResult results = msw.Validate(message);
                if (results.IsValid)
                {
                    mm.MessageUpdate(message);
                    return RedirectToAction("Sendbox");
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

        // Taslak silme
        public ActionResult DraftDelete(int id)
        {
            var message = mm.GetMessageById(id);
            if (message != null)
            {
                mm.MessageRemove(message);
            }
            return RedirectToAction("Draft");
        }

        // Mesajın okundu/okunmadı durumunu günceller
        [HttpPost]
        public ActionResult MessageIsRead(int id, bool status)
        {
            var deger = mm.GetMessageById(id);
            if (deger != null)
            {
                deger.MessageIsRead = status;
                mm.MessageUpdate(deger);
            }
            return RedirectToAction("Inbox");
        }

        // Gelen kutusu (Arama destekli)
        [Authorize]
        public ActionResult Inbox(string kelime) 
        {
            string mail = (string)Session["AdminUserName"];
            var message_value = mm.GetListInbox(mail);

            if (!string.IsNullOrEmpty(kelime))
            {
                kelime = kelime.ToLower();
                message_value = message_value.Where(x =>
                    (x.Subject != null && x.Subject.ToLower().Contains(kelime)) ||
                    (x.MessageContent != null && x.MessageContent.ToLower().Contains(kelime)) ||
                    (x.SenderMail != null && x.SenderMail.ToLower().Contains(kelime))
                ).ToList();
            }

            return View(message_value);
        }

        // Giden kutusu (Arama destekli)
        [Authorize]
        public ActionResult Sendbox(string kelime)
        {
            string mail = (string)Session["AdminUserName"];
            var message_value = mm.GetListSendbox(mail);

            if (!string.IsNullOrEmpty(kelime))
            {
                kelime = kelime.ToLower();
                message_value = message_value.Where(x =>
                    (x.Subject != null && x.Subject.ToLower().Contains(kelime)) ||
                    (x.MessageContent != null && x.MessageContent.ToLower().Contains(kelime)) ||
                    (x.ReceiverMail != null && x.ReceiverMail.ToLower().Contains(kelime))
                ).ToList();
            }

            return View(message_value);
        }
    }
}