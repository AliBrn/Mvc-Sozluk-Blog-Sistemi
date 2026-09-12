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
    public class EfCategoryDal:GenericRepository<Category>,ICategoryDal
    {
        // IrEPOSİTORY ÖZEL  category classı ise ona özel ıcategory oluşturdul şimdi EF kullanmak için class 
        /*
      * Bu DAL class'ı veritabanı işlemlerini Entity Framework ile yapıyor.
      Yani EfCategoryDal demek: Entity Framework kullanan Category Data Access Layer class'ı
        
Neden Ayrı EntityFramework Klasörü Var?
Çünkü DataAccessLayer içinde ileride farklı veri erişim teknolojileri olabilir.
Mesela bugün:
Entity Framework
kullanıyorsun.
Ama başka projede ya da ileride şunlar da olabilir:
Dapper,ADO.NET,NHibernate,MongoDB,API'den veri çekme

Bu yüzden klasör ismiyle şunu ayırıyorsun:
DataAccessLayer
    Abstract
        ICategoryDal.cs
    Concrete
        Context.cs
        Repositories
            GenericRepository.cs
    EntityFramework
        EfCategoryDal.cs

Buradaki anlam:
Abstract:
Sözleşmeler.

Concrete / Repositories:
Ortak çalışan repository kodları.

EntityFramework:
Entity Framework teknolojisiyle çalışan DAL class'ları.

Peki EfCategoryDal Ne İş Yapıyor?
Projendeki kod:
public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
{
}
Bu class’ın içi boş ama anlamı dolu.
Şunu söylüyor:
Ben Category için veri erişim class'ıyım.Bu işi Entity Framework altyapısıyla yapacağım.
Hazır CRUD kodlarını GenericRepository<Category>den alıyorum.ICategoryDal sözleşmesine de uyuyorum.
// eF ALT YAPISI KULLANCAĞINI,gENERİC CRUD KODUNA UYCAĞINI VE ı categorydal ssözleşmesine uyucağını anlatıyor

Yani aslında EfCategoryDal, Category için özel isimlendirilmiş bir kapı.
Neden Direkt GenericRepository<Category> Demedik?
Çünkü GenericRepository<Category> genel bir class.
Ama EfCategoryDal daha açık bir anlam taşır:
Bu Category için DAL class'ı.
Bu Entity Framework kullanan DAL class'ı.
Manager içine bunu verdiğinde:
CategoryManager cm = new CategoryManager(new EfCategoryDal());
şu olmuş olur:
CategoryManager'a Category verisini Entity Framework ile yöneten class verdim.
İleride Başka Teknoloji Olsa
Mesela Entity Framework yerine Dapper kullansaydın şöyle bir class yazabilirdin:
public class DapperCategoryDal : ICategoryDal
{
}
O zaman manager değişmeden şu yapılabilir:
CategoryManager cm = new CategoryManager(new DapperCategoryDal());
Çünkü manager sadece bunu bekliyor:
ICategoryDal
Teknolojinin adı manager’ı ilgilendirmiyor.
Kısacası
EntityFramework klasörü ve EfCategoryDal şunun için var:
Veri erişiminin hangi teknolojiyle yapıldığını ayırmak için.
ICategoryDal der ki:
Category verisine erişebilen bir şey istiyorum.
EfCategoryDal der ki:
Ben bunu Entity Framework ile yapan gerçek class'ım.
Bu yüzden adı EfCategoryDal.
Yani isimdeki mantık:
Ef       -> Hangi veri erişim teknolojisi?
Category -> Hangi entity?
Dal      -> Hangi katman/görev?
EfCategoryDal = Category tablosuna/verisine Entity Framework ile erişen DAL class’ı.
         */

        // EfCategoryDal class oluştrup ı categorydal,generic repository kalıtım almasan tüm metodu burda tanımlasan yarın getir adında metot oluştursan
        // 100 tane sınıf varsa bu 100 sınıfa getir için tek tek kopyala yapıştırla tekrar mı düşcen bunn yerine imza ve uygula ortak olsun ondan çekse nasıl olurdu
        // Bu etkisi de var
    }
}
