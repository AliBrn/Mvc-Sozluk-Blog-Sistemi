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
    public class WriterManager : IWriterService
    {
        IWriterDal _writerdal; // W

        public WriterManager(IWriterDal writerdal)
        {
            _writerdal = writerdal;   // Iwriterdal  interface oluşturuyoruz ve ct oluşturuyoruz.Neden çünkü IWriterdal imzalar saklı.
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
    }
}
