namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_about_status_bool : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Abouts", "AboutStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Abouts", "AboutStatus", c => c.String(maxLength: 10));
        }
    }
}
