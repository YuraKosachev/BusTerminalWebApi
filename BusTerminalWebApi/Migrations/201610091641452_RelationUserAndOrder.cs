namespace BusTerminalWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationUserAndOrder : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Orders", "UserId");
            AddForeignKey("dbo.Orders", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropIndex("dbo.Orders", new[] { "UserId" });
        }
    }
}
