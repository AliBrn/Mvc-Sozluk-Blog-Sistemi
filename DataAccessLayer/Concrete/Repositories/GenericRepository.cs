using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    // Tek seferde tüm interface ait metotları tanımladıgın class  Hangi class seçtiğide ı repository gelen varlıga göre class seçiyor 
    public class GenericRepository<T>:IRepository<T> where T : class
    {
        Context c = new Context();
        DbSet<T> _object; // T ye karşılık gelen sınıfı nasıl bulcaz DbSet<Writer> _object    writer alıyor değeri
                          // DbSet<Category>  Categories ;   Categoris=c.Set<Category>(); Koddaki set edilen  category veritabanına yansıyor
        public GenericRepository()
        {
            _object=c.Set<T>(); // Object değerin context bağlı olarak gönderilen T değerine bağlı. gelen değeri objeye gönderiyoruz
        }
        public void Delete(T p)  // Gerçek delete burda yapıyor CategoryManager doldurdugumuz burdaki metotla 
        {
            // Silme içinde aynısını yapıyoruz EntityState.Deleted 
            var deletedEntity=c.Entry(p);
            deletedEntity.State = EntityState.Deleted;
            //_object.Remove(p);
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter); // Tek değer için kullanılan metot
        }

        public void Insert(T p)
        {
            // Entity State ile   ekleme yaptık   EntityState.Added  hazır olan metot
            var addedEntity=c.Entry(p);
            addedEntity.State = EntityState.Added;
            //_object.Add(p);
            c.SaveChanges();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

       

        public void Update(T p) 
        {
            // Update işlemi burda gerçekleşmiyor çünkü tam kaydedilmiyor
            // Entity State kullancaz Veritabannıa tam kaydetmediği için baştan bidaha aynısını listeliyor.

            var updatedEntity=c.Entry(p);
            updatedEntity.State = EntityState.Modified; //Entity güncellenmiş olduğunu bildiriyor.
            c.SaveChanges();
        }
    }

    
}
