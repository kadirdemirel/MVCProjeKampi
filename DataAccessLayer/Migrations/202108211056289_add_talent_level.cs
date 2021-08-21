namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_talent_level : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Talents", "TalentLevel", c => c.String(maxLength: 25));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Talents", "TalentLevel");
        }
    }
}
