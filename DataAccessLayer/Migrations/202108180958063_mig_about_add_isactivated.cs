namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_about_add_isactivated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "IsActivated", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Abouts", "IsActivated");
        }
    }
}
