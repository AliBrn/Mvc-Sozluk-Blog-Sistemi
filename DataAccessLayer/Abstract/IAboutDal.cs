using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    /// <summary>
    /// Hakkımızda modülü için veri erişim arayüzü
    /// </summary>
    public interface IAboutDal : IRepository<About>
    {
    }
}
