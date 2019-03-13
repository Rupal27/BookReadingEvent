namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookReadingEvent",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EventType = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Location = c.String(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        Duration = c.Int(nullable: false),
                        Description = c.String(maxLength: 4),
                        OtherDetails = c.String(maxLength: 50),
                        InviteByEmail = c.String(maxLength: 500),
                        UserID = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BookReadingEventID = c.Int(),
                        Comment = c.String(nullable: false),
                        EmailID = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BookReadingEvent", t => t.BookReadingEventID)
                .Index(t => t.BookReadingEventID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        FullName = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookReadingEvent", "UserID", "dbo.User");
            DropForeignKey("dbo.Comments", "BookReadingEventID", "dbo.BookReadingEvent");
            DropIndex("dbo.Comments", new[] { "BookReadingEventID" });
            DropIndex("dbo.BookReadingEvent", new[] { "UserID" });
            DropTable("dbo.User");
            DropTable("dbo.Comments");
            DropTable("dbo.BookReadingEvent");
        }
    }
}
