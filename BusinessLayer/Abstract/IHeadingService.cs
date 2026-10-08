using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    /// <summary>
    /// Başlık işlemleri için servis arayüzü
    /// </summary>
    public interface IHeadingService
    {
        List<Heading> GetListByWriter(int id);
        List<Heading> HeadingList();
        void HeadingAdd(Heading heading);
        void HeadingRemove(Heading heading);    
        void HeadingUpdate(Heading heading);
        Heading HeadingGetByID(int id);
        List<Heading> GetListByCategory(int id);
    }
}
