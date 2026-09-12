using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        void WriterAdd(Writer wrt);
        void WriterRemove(Writer wrt);
        void WriterUpdate(Writer wrt);
        Writer WriterGetByID(int id); // Class döndürcen
        List<Writer> GetWriterList();
    }
}
