using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    /// <summary>
    /// Kategori işlemleri için servis arayüzü
    /// </summary>
    public interface ICategoryService
    {
        List<Category> GetCategoryList();
        void CategoryAdd(Category ctg);
        void CategoryRemove(Category ctg);
        Category GetByID(int id);
        void CategoryUpdate(Category ctg);
    }
}
