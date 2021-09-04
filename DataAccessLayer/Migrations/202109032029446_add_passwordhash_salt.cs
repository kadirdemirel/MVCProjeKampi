namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_passwordhash_salt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "PasswordHash", c => c.Binary());
            AddColumn("dbo.Admins", "PasswordSalt", c => c.Binary());
            DropColumn("dbo.Admins", "AdminPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "AdminPassword", c => c.String(maxLength: 50));
            DropColumn("dbo.Admins", "PasswordSalt");
            DropColumn("dbo.Admins", "PasswordHash");
        }
    }
}
