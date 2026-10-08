using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    /// <summary>
    /// Tüm entityler için temel CRUD ve filtreleme metotlarını tanımlayan generic repository arayüzü
    /// </summary>
    /// <typeparam name="T">İlgili veritabanı entity sınıfı</typeparam>
    public interface IRepository<T>
    {
        List<T> List();
        void Insert(T p);
        T Get(Expression<Func<T, bool>> filter);
        void Update(T p);
        void Delete(T p);
        List<T> List(Expression<Func<T, bool>> filter);
    }
}
