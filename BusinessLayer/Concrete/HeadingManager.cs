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
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingdal;

        public HeadingManager(IHeadingDal headingdal)
        {
            _headingdal = headingdal;
        }

        // Kategoriye ait başlıkları listeler
        public List<Heading> GetListByCategory(int id)
        {
            return _headingdal.List(x => x.CategoryID == id);
        }

        // Belirtilen yazara ait başlıkları listeler
        public List<Heading> GetListByWriter(int id)
        {
            return _headingdal.List(x => x.WriterID == id);
        }

        // Yeni başlık ekler
        public void HeadingAdd(Heading heading)
        {
            _headingdal.Insert(heading);
        }

        // ID'ye göre tekil başlık kaydını getirir
        public Heading HeadingGetByID(int id)
        {
            return _headingdal.Get(x => x.HeadingID == id);
        }

        // Tüm başlıkları listeler
        public List<Heading> HeadingList()
        {
            return _headingdal.List();
        }

        // Başlığı pasife alır (Soft delete)
        public void HeadingRemove(Heading heading)
        {
            _headingdal.Update(heading);
        }

        // Başlık bilgilerini günceller
        public void HeadingUpdate(Heading heading)
        {
            _headingdal.Update(heading);
        }
    }
}
