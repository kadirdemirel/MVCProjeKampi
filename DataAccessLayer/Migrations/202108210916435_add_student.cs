namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_student : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 25),
                        Surname = c.String(maxLength: 25),
                        School = c.String(maxLength: 50),
                        Section = c.String(maxLength: 25),
                        ImagePath = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.StudentId);
            
            AddColumn("dbo.Talents", "StudentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Talents", "StudentId");
            AddForeignKey("dbo.Talents", "StudentId", "dbo.Students", "StudentId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Talents", "StudentId", "dbo.Students");
            DropIndex("dbo.Talents", new[] { "StudentId" });
            DropColumn("dbo.Talents", "StudentId");
            DropTable("dbo.Students");
        }
    }
}
