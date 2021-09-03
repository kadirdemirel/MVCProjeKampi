namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_admin_salt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminSalt", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "AdminSalt");
        }
    }
}
