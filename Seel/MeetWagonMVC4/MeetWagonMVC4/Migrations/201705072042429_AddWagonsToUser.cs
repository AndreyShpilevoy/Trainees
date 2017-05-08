namespace MeetWagonMVC4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWagonsToUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserProfile", "Wagon_WagonId", "dbo.Wagons");
            DropIndex("dbo.UserProfile", new[] { "Wagon_WagonId" });
            CreateTable(
                "dbo.WagonUserProfiles",
                c => new
                    {
                        Wagon_WagonId = c.Int(nullable: false),
                        UserProfile_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Wagon_WagonId, t.UserProfile_UserId })
                .ForeignKey("dbo.Wagons", t => t.Wagon_WagonId, cascadeDelete: true)
                .ForeignKey("dbo.UserProfile", t => t.UserProfile_UserId, cascadeDelete: true)
                .Index(t => t.Wagon_WagonId)
                .Index(t => t.UserProfile_UserId);
            
            DropColumn("dbo.UserProfile", "Wagon_WagonId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProfile", "Wagon_WagonId", c => c.Int());
            DropIndex("dbo.WagonUserProfiles", new[] { "UserProfile_UserId" });
            DropIndex("dbo.WagonUserProfiles", new[] { "Wagon_WagonId" });
            DropForeignKey("dbo.WagonUserProfiles", "UserProfile_UserId", "dbo.UserProfile");
            DropForeignKey("dbo.WagonUserProfiles", "Wagon_WagonId", "dbo.Wagons");
            DropTable("dbo.WagonUserProfiles");
            CreateIndex("dbo.UserProfile", "Wagon_WagonId");
            AddForeignKey("dbo.UserProfile", "Wagon_WagonId", "dbo.Wagons", "WagonId");
        }
    }
}
