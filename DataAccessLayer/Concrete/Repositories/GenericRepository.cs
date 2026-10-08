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
    /// <summary>
    /// Tüm entity modelleri için ortak CRUD işlemlerini gerçekleştiren generic repository sınıfı
    /// </summary>
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context c = new Context();
        DbSet<T> _object;

        public GenericRepository()
        {
            _object = c.Set<T>();
        }

        // EntityState.Deleted kullanarak varlığı siler
        public void Delete(T p)
        {
            var deletedEntity = c.Entry(p);
            deletedEntity.State = EntityState.Deleted;
            c.SaveChanges();
        }

        // Belirtilen filtreye uyan ilk veya varsayılan kaydı getirir
        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        // EntityState.Added kullanarak yeni varlık ekler
        public void Insert(T p)
        {
            var addedEntity = c.Entry(p);
            addedEntity.State = EntityState.Added;
            c.SaveChanges();
        }

        // Belirtilen filtreye göre şartlı listeleme yapar
        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        // Tüm kayıtları listeler
        public List<T> List()
        {
            return _object.ToList();
        }

        // EntityState.Modified kullanarak varlığı günceller
        public void Update(T p) 
        {
            var updatedEntity = c.Entry(p);
            updatedEntity.State = EntityState.Modified;
            c.SaveChanges();
        }
    }
}
