namespace BusTerminalWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationVoyageAndBus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Voyages", "BusStop_BusStopId", c => c.Int());
            AddColumn("dbo.Voyages", "ArrivalBusStop_BusStopId", c => c.Int());
            AddColumn("dbo.Voyages", "DepartureBusStop_BusStopId", c => c.Int());
            CreateIndex("dbo.Voyages", "BusId");
            CreateIndex("dbo.Voyages", "BusStop_BusStopId");
            CreateIndex("dbo.Voyages", "ArrivalBusStop_BusStopId");
            CreateIndex("dbo.Voyages", "DepartureBusStop_BusStopId");
            AddForeignKey("dbo.Voyages", "BusStop_BusStopId", "dbo.BusStops", "BusStopId");
            AddForeignKey("dbo.Voyages", "ArrivalBusStop_BusStopId", "dbo.BusStops", "BusStopId");
            AddForeignKey("dbo.Voyages", "BusId", "dbo.Buses", "BusId", cascadeDelete: true);
            AddForeignKey("dbo.Voyages", "DepartureBusStop_BusStopId", "dbo.BusStops", "BusStopId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Voyages", "DepartureBusStop_BusStopId", "dbo.BusStops");
            DropForeignKey("dbo.Voyages", "BusId", "dbo.Buses");
            DropForeignKey("dbo.Voyages", "ArrivalBusStop_BusStopId", "dbo.BusStops");
            DropForeignKey("dbo.Voyages", "BusStop_BusStopId", "dbo.BusStops");
            DropIndex("dbo.Voyages", new[] { "DepartureBusStop_BusStopId" });
            DropIndex("dbo.Voyages", new[] { "ArrivalBusStop_BusStopId" });
            DropIndex("dbo.Voyages", new[] { "BusStop_BusStopId" });
            DropIndex("dbo.Voyages", new[] { "BusId" });
            DropColumn("dbo.Voyages", "DepartureBusStop_BusStopId");
            DropColumn("dbo.Voyages", "ArrivalBusStop_BusStopId");
            DropColumn("dbo.Voyages", "BusStop_BusStopId");
        }
    }
}
