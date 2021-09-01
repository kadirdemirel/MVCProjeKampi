namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_isactivated_admin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "IsActivated", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "IsActivated");
        }
    }
}
