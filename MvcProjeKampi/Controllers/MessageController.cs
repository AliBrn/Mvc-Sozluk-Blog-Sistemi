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
    public class MessageController : Controller
    {
        // GET: Message

        // İletişim contact tablosunda mesaj atılan yer birine
        // Gelen ve giden de gelen admin olmalı giden de adminden gelmeli karşılıgı var

        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator msw = new MessageValidator();
        public ActionResult Inbox()
        {
            var message_value = mm.GetListInbox();
            return View(message_value);
        }
        public ActionResult Sendbox()
        {
            var message_value = mm.GetListSendbox();
            return View(message_value);
        }

        public ActionResult MessageInboxDetails(int id)  //  Gelen Mesajların Detayları
        {
            var message_value = mm.GetMessageById(id);
            return View(message_value);
        }
        public ActionResult MessageSendboxDetails(int id)  //  Gelen Mesajların Detayları
        {
            var message_value = mm.GetMessageById(id);
            return View(message_value);
        }
        [HttpGet]
        public ActionResult MessageAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MessageAdd(Message message)
        {
            ValidationResult results = msw.Validate(message); 
            if (results.IsValid)
            {
                message.MessageDate =DateTime.Parse(DateTime.Now.ToShortDateString().ToString()); // Bugünün tarihini alcak
                mm.MessageAdd(message);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

            }
         
            return View();
        }
    }
}