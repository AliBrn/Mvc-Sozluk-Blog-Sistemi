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
    // Yanlış kullanım kısmınada implemente etmeliydik
    public class CategoryRepository : ICategoryDal
    { // Ne görev yaptıklarını burda tanımladık
        
        Context db=new Context();
        DbSet<Category> _object; // _object  isimlendirme nesne de diyebilirsin
        public void Delete(Category p)
        {
            _object.Remove(p);
            db.SaveChanges();
           
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Insert(Category p)
        {
            _object.Add(p);
            db.SaveChanges();
        }

        public List<Category> List()
        {
            return _object.ToList();
        }

        public List<Category> List(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Category> Liste()
        {
            throw new NotImplementedException();
        }

        public void Update(Category p)
        {
            db.SaveChanges();
        }
    }
}
