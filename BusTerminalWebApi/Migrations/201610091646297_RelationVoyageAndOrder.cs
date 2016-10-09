namespace BusTerminalWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationVoyageAndOrder : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Orders", "VoyageId");
            AddForeignKey("dbo.Orders", "VoyageId", "dbo.Voyages", "VoyageId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "VoyageId", "dbo.Voyages");
            DropIndex("dbo.Orders", new[] { "VoyageId" });
        }
    }
}
