using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    // Concrete adı altında Context class oluşturduk entity framework paketini kurduk referenc entity layer katmanını ekledik ilk aşamda
    // Context sınıfında tablolar yazıyorda  web config string name o yüzden Context  bu contex değilde abc yapsan web configh name abc yapcaksın
    // Webconfig yaptık veritabanı adı  DbMvcKamp

    // Migrations code first mimarsiiyle oluşturdugumuz yapının  sql yansıtmak için kullandıgımız bileşen
    // Migrations yaparken context nerdeyse klasör o seçili olmalı enable-migrations   daha sonrasında  migrations klasörü geliyor orda configuration
    // true yapıyoruz daha sonrasında  update-database gerçekleştirmiş oluyoruz veriler.
    // Projede değişiklik yaptıkça c# ile sql arasında köprü görevi gören bir  ayar.

    // Migrations loglarıda tutar add-migration  migration ismi kullandıgında   her seferinde Migrations klasöründe  1 tane log kaydı tutuar
    // Değişikliği onaylayıp onaylamadıgna dair bu yapı sayesinde eğer onaylarsan update-database sonrasında migration  güncellersin önce ekle sonra güncelle
    public class Context:DbContext
    {
        public DbSet<About> Abouts { get; set; }  // Sol taraftaki  C# daki ismi s takısı olan  veritabanı ismi
        public DbSet<Category>  Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Heading> Headings { get; set; }     // Biri eksik olsa sql  o eksiği yazmaz buraya yazmak gerekir
        public DbSet<Writer> Writers { get; set; }

        public DbSet<Message> Messages { get; set; }

    }
}
