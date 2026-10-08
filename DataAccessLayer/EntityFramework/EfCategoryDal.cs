using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    /// <summary>
    /// Kategori tablosu için Entity Framework veri erişim sınıfı
    /// </summary>
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
    }
}
