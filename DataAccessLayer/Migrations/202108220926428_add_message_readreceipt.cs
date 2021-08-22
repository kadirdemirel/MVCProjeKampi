namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_message_readreceipt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "ReadReceipt", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "ReadReceipt");
        }
    }
}
