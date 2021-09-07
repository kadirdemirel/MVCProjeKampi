namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delete_lastheading : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Headings", "LastHeadingDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Headings", "LastHeadingDate", c => c.DateTime(nullable: false));
        }
    }
}
