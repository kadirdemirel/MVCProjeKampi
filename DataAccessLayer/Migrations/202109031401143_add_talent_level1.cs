namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_talent_level1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Talents", "TalentLevel", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Talents", "TalentLevel", c => c.String(maxLength: 25));
        }
    }
}
