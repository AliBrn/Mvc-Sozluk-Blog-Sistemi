using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messagedal;

        public MessageManager(IMessageDal messagedal)
        {
            _messagedal = messagedal;
        }

        // Belirtilen kullanıcının gönderdiği (giden) mesajları listeler
        public List<Message> GetListSendbox(string mail)
        { 
            return _messagedal.List(x => x.SenderMail == mail && x.IsDraft == false);
        }

        // ID'ye göre tekil mesaj kaydını getirir
        public Message GetMessageById(int id)
        {
           return _messagedal.Get(x => x.MessageID == id);
        }

        // Belirtilen kullanıcının gelen kutusu mesajlarını listeler
        public List<Message> GetListInbox(string mail)
        {
            return _messagedal.List(x => x.ReceiverMail == mail && x.IsDraft == false);
        }

        // Yeni mesaj ekler
        public void MessageAdd(Message message)
        {
            _messagedal.Insert(message);
        }

        // Mesajı siler
        public void MessageRemove(Message message)
        {
            _messagedal.Delete(message);
        }

        // Mesaj bilgilerini günceller
        public void MessageUpdate(Message message)
        {
            _messagedal.Update(message);
        }

        // Belirtilen kullanıcının taslak mesajlarını listeler
        public List<Message> GetListDraft(string mail)
        {
            return _messagedal.List(x => x.SenderMail == mail && x.IsDraft == true);
        }

    }
}
