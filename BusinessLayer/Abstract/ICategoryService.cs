using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        // Burda kullanılan metotlar imza metot arayüzde çağrılmak için  bu çağrılan metotlar CategoryManager kullanılıyor
        // CategoryManager doldurulurken ise CategoryDal sayesinde IRepositoryde çağrılan metot sayesinde dolduruluyor
        // Burda parametreyle  artık class özgüyken ı repositoryde  genel tanımlanıyor.

        // Aslında burda arayüzde kullandıgın var   Manager dolduruluyor  .Manager doldurulan cATEGORYDAL (Irepository) yöntemi kullanıyor  manager tanımlıyor
        // Controller çağıracağı işlemler
        // İnterface tanımla  manager doldur
        List<Category> GetCategoryList(); // Get List yerine isimlendirmede GetCategoryList böyle yaptım

        void CategoryAdd(Category ctg); // Service manager isimlendirme aynı olur metot ancak içinde ekleme   generic repository göre

        void CategoryRemove(Category ctg); // IrEPOSİTORY  tanımlı burda category silme için ekledik id ye göre nesne bulduk  nesneyi silcez şimdi.
        Category GetByID(int id); // Dışardan bir id değeri alacaksın  

        void CategoryUpdate(Category ctg); // Nesne alcak update için yine
    }
}
