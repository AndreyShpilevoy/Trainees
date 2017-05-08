namespace MeetWagonMVC4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWagon : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Wagons",
                c => new
                    {
                        WagonId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        DateAdded = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.WagonId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Wagons");
        }
    }
}
