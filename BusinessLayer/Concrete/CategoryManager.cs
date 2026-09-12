using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    // Her katman önceki katmanın  referans alır buda entity ve data acces aldı
    public class CategoryManager : ICategoryService
    {
        // CategoryDal gibi  burdada   nesne türetcez 

        // Generic repostiory  consturctor oluşturduk ya burdada aynı yapıyı oluşturcaz

        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal) // Category verisine İMZA METOTLARA erişmek için ICategoryDal kullanır.
        {
            _categoryDal = categoryDal;
        }

        public void CategoryAdd(Category ctg)
        {
           _categoryDal.Insert(ctg); // Category validatior kuralarını da eklemeliyiz
        }

        public void CategoryRemove(Category ctg)
        {
            // Silme tamamlandı şimdi Delete kısmı  Irepository geliyor  içerik Irepository Dışı mvc kullancağımız metot adı
            _categoryDal.Delete(ctg);  
        }

        public void CategoryUpdate(Category ctg)
        {
            _categoryDal.Update(ctg);
        }

        public Category GetByID(int id)
        {
            return _categoryDal.Get(x=>x.CategoryID==id); // Aldıgım id değerine eşit olcaksın 
        }

        public List<Category> GetCategoryList()
        {
            return _categoryDal.List(); // Generic repository ait metotlar geldi burda
        }
        //// Class adı burda kullanılmaya başlıyor   repo adında nesneye atanıyor BL  göre kurallar tanımlanıyor   metotlar kurala uygun yazılıyor 
        //GenericRepository<Category> repo = new GenericRepository<Category>();

        //public List<Category> GetAllBL()
        //  {
        //    return repo.List();
        //}

        //public void CategoryAddBL(Category p)
        //{
        //    //if (p.CategoryName == "" || p.CategoryName.Length <= 3 || p.CategoryDescription == "" || p.CategoryName.Length >= 51)
        //    //{

        //    //    // Hata Mesajı

        //    //}
        //    //else
        //    //{
        //        repo.Insert(p);   
        //    //}
        //}

        // 

    }

}
