namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1_writer_edit : DbMigration
    {
        // Entity değişiklik yaptıktan  sonra add-migration  mig1(İşlem) adı yap burası gelcek Context nerdeyse orda yapcan unutma
        // Eğer onaylarsan update-database yapcan veritabanına kaydedilcek
        public override void Up()  // Up güncellencek kısım
        {
            AddColumn("dbo.Writers", "WriterAbout", c => c.String(maxLength: 100));
            AlterColumn("dbo.Writers", "WriterMail", c => c.String(maxLength: 200));
            AlterColumn("dbo.Writers", "WriterPassword", c => c.String(maxLength: 200));
        }
        
        public override void Down() // Down güncelleme yapmazsan  kalcak kısım
        {
            AlterColumn("dbo.Writers", "WriterPassword", c => c.String(maxLength: 20));
            AlterColumn("dbo.Writers", "WriterMail", c => c.String(maxLength: 50));
            DropColumn("dbo.Writers", "WriterAbout");
        }
    }
}
