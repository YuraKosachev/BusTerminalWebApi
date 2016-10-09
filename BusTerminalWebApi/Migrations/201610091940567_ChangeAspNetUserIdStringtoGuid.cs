namespace BusTerminalWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAspNetUserIdStringtoGuid : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Buses", "BusModel", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "AspUserId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "AspUserId", c => c.String());
            AlterColumn("dbo.Buses", "BusModel", c => c.String());
        }
    }
}
