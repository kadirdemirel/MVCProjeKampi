namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_lastheading : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Headings", "LastHeadingDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Headings", "LastHeadingDate");
        }
    }
}
