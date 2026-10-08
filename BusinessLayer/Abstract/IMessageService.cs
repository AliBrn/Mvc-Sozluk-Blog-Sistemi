using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    /// <summary>
    /// Mesajlaşma işlemleri için servis arayüzü
    /// </summary>
    public interface IMessageService
    {
        List<Message> GetListInbox(string mail);
        List<Message> GetListSendbox(string mail);
        void MessageAdd(Message message);
        void MessageRemove(Message message);
        void MessageUpdate(Message message);
        Message GetMessageById(int id);
        List<Message> GetListDraft(string mail);
    }
}
