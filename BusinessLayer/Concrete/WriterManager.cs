using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDal _writerdal;

        public WriterManager(IWriterDal writerdal)
        {
            _writerdal = writerdal;
        }

        public List<Writer> GetWriterList()
        {
            return _writerdal.List();
        }

        public void WriterAdd(Writer wrt)
        {
           _writerdal.Insert(wrt);
        }

        public void WriterUpdate(Writer wrt)
        {
           _writerdal.Update(wrt);
        }

        public Writer WriterGetByID(int id)
        {
           return _writerdal.Get(x=>x.WriterID==id);
        }

        public void WriterRemove(Writer wrt)
        {
            _writerdal.Delete(wrt);
        }

        public Writer GetWriterByUserNamePassword(string mail, string password)
        {
            return _writerdal.Get(x => x.WriterMail == mail && x.WriterPassword == password);
        }

        public Writer GetWriterByMail(string mail)
        {
            return _writerdal.Get(x => x.WriterMail == mail);
        }
    }
}
