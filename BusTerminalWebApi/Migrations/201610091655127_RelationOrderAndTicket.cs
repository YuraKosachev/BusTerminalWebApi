namespace BusTerminalWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationOrderAndTicket : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "Order_OrderId", c => c.Int());
            CreateIndex("dbo.Tickets", "Order_OrderId");
            AddForeignKey("dbo.Tickets", "Order_OrderId", "dbo.Orders", "OrderId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "Order_OrderId", "dbo.Orders");
            DropIndex("dbo.Tickets", new[] { "Order_OrderId" });
            DropColumn("dbo.Tickets", "Order_OrderId");
        }
    }
}
