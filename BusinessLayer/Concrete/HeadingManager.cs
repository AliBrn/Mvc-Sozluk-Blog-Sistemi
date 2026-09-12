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
        public void HeadingAdd(Heading heading)
        {
            _headingdal.Insert(heading); // İçindeki insert burdan gelmiyor  IRepositoryden geliyor doldurulmuş hali işleme alınan Generic
        }

        public Heading HeadingGetByID(int id)
        {
            return _headingdal.Get(x=>x.HeadingID==id);
        }

        public List<Heading> HeadingList()
        {
            return  _headingdal.List();
        }

        public void HeadingRemove(Heading heading) // Direk silme yerine false yapcaz
        {
             // Heading status burda kullanmamalıyız id çağırabiliriz en fazla entity kullanamayız  sadece update kullancanz delete yerine
            //_headingdal.Delete(heading);
            _headingdal.Update(heading);  // False değiştir status sonra update yap removeda
        }

        public void HeadingUpdate(Heading heading)
        {
            _headingdal.Update(heading);
        }
    }
}
