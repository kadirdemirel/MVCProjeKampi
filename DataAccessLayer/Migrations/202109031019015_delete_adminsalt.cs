namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delete_adminsalt : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Admins", "AdminSalt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "AdminSalt", c => c.String(maxLength: 50));
        }
    }
}
