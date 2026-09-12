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

       
        public List<Message> GetListSendbox() // Gönderen Admin mailiyse listeliyor
        {
            return _messagedal.List(x => x.SenderMail == "admin@gmail.com");
        }

        public Message GetMessageById(int id)
        {
           return _messagedal.Get(x=>x.MessageID == id);
        }

        public List<Message> GetListInbox()
        { // Alıcı mali karşıdaki adminse listeliyor

            return _messagedal.List(x => x.ReceiverMail == "admin@gmail.com");
        }

        public void MessageAdd(Message message)
        {
            _messagedal.Insert(message);
        }

        public void MessageRemove(Message message)
        {
            throw new NotImplementedException();
        }

        public void MessageUpdate(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
