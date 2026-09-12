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
    public class AboutManager:IAboutService
    {
        IAboutDal _aboutdal;

        public AboutManager(IAboutDal about)
        {
            _aboutdal = about;
        }

        public void AboutAdd(About about)
        {
            _aboutdal.Insert(about);
        }

        public About AboutGetByID(int id)
        {
            return _aboutdal.Get(x=>x.AboutID==id);
        }

        public List<About> AboutList()
        {
            return _aboutdal.List();
        }

        public void AboutRemove(About about)
        {
             _aboutdal.Delete(about);
        }

        public void AboutUpdate(About about)
        {
           _aboutdal.Update(about);
        }
    }
}
