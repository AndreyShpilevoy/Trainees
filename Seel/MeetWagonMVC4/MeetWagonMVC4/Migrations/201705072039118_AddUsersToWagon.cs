namespace MeetWagonMVC4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUsersToWagon : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfile", "Wagon_WagonId", c => c.Int());
            AddForeignKey("dbo.UserProfile", "Wagon_WagonId", "dbo.Wagons", "WagonId");
            CreateIndex("dbo.UserProfile", "Wagon_WagonId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.UserProfile", new[] { "Wagon_WagonId" });
            DropForeignKey("dbo.UserProfile", "Wagon_WagonId", "dbo.Wagons");
            DropColumn("dbo.UserProfile", "Wagon_WagonId");
        }
    }
}
