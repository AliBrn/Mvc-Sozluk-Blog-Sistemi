using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    /// <summary>
    /// Yazar işlemleri için servis arayüzü
    /// </summary>
    public interface IWriterService
    {
        void WriterAdd(Writer wrt);
        void WriterRemove(Writer wrt);
        void WriterUpdate(Writer wrt);
        Writer WriterGetByID(int id);
        List<Writer> GetWriterList();
        Writer GetWriterByUserNamePassword(string mail, string password);
        Writer GetWriterByMail(string mail);
    }
}
