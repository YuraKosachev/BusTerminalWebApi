namespace BusTerminalWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buses",
                c => new
                    {
                        BusId = c.Int(nullable: false, identity: true),
                        BusModel = c.String(),
                        BusDescription = c.String(),
                        BusNumberOfSeats = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BusId);
            
            CreateTable(
                "dbo.BusStops",
                c => new
                    {
                        BusStopId = c.Int(nullable: false, identity: true),
                        BusStopName = c.String(),
                        BusStopDescrition = c.String(),
                    })
                .PrimaryKey(t => t.BusStopId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        VoyageId = c.Int(nullable: false),
                        TicketId = c.Int(nullable: false),
                        StatusOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketId = c.Int(nullable: false, identity: true),
                        PassengerFirstName = c.String(),
                        PassengerLastName = c.String(),
                        PassengerDocumentNumber = c.String(),
                        PassengerSeatNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TicketId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        AspUserId = c.String(),
                        UserFirstName = c.String(),
                        UserLastName = c.String(),
                        UserBirthDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Voyages",
                c => new
                    {
                        VoyageId = c.Int(nullable: false, identity: true),
                        DepartureBusStopId = c.Int(nullable: false),
                        ArrivalBusStopId = c.Int(nullable: false),
                        BusId = c.Int(nullable: false),
                        VoyageName = c.String(),
                        TicketCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.VoyageId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Voyages");
            DropTable("dbo.Users");
            DropTable("dbo.Tickets");
            DropTable("dbo.Orders");
            DropTable("dbo.BusStops");
            DropTable("dbo.Buses");
        }
    }
}
