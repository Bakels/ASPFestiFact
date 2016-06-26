namespace FestivalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actor",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Movie_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Movie", t => t.Movie_ID)
                .Index(t => t.Movie_ID);
            
            CreateTable(
                "dbo.Executor",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        HomeCountry = c.String(),
                        Genre = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Show",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        Image = c.Binary(),
                        ExecutorID = c.Int(nullable: false),
                        RoomID = c.Int(nullable: false),
                        FestivalID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Executor", t => t.ExecutorID, cascadeDelete: true)
                .ForeignKey("dbo.Room", t => t.RoomID, cascadeDelete: true)
                .ForeignKey("dbo.Festival", t => t.FestivalID, cascadeDelete: true)
                .Index(t => t.ExecutorID)
                .Index(t => t.RoomID)
                .Index(t => t.FestivalID);
            
            CreateTable(
                "dbo.Festival",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Banner = c.Binary(),
                        Type = c.String(),
                        Genre = c.String(),
                        MinAge = c.Int(nullable: false),
                        MaxAge = c.Int(nullable: false),
                        OrganisationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Organisaton", t => t.OrganisationID)
                .Index(t => t.OrganisationID);
            
            CreateTable(
                "dbo.FestivalDate",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Datum = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Adress = c.String(),
                        City = c.String(),
                        Postcode = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Room",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Capacity = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Location", t => t.LocationID, cascadeDelete: true)
                .Index(t => t.LocationID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Role = c.String(),
                        Logged = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Picture",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Image = c.Binary(),
                        Festival_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Festival", t => t.Festival_ID)
                .Index(t => t.Festival_ID);
            
            CreateTable(
                "dbo.Ticket",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Price = c.Double(nullable: false),
                        VisitorID = c.Int(nullable: false),
                        ShowID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Show", t => t.ShowID, cascadeDelete: true)
                .ForeignKey("dbo.Visitor", t => t.VisitorID, cascadeDelete: true)
                .Index(t => t.VisitorID)
                .Index(t => t.ShowID);
            
            CreateTable(
                "dbo.Visitor",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FestivalDateFestival",
                c => new
                    {
                        FestivalDate_ID = c.Int(nullable: false),
                        Festival_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FestivalDate_ID, t.Festival_ID })
                .ForeignKey("dbo.FestivalDate", t => t.FestivalDate_ID, cascadeDelete: true)
                .ForeignKey("dbo.Festival", t => t.Festival_ID, cascadeDelete: true)
                .Index(t => t.FestivalDate_ID)
                .Index(t => t.Festival_ID);
            
            CreateTable(
                "dbo.LocationFestival",
                c => new
                    {
                        Location_ID = c.Int(nullable: false),
                        Festival_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Location_ID, t.Festival_ID })
                .ForeignKey("dbo.Location", t => t.Location_ID, cascadeDelete: true)
                .ForeignKey("dbo.Festival", t => t.Festival_ID, cascadeDelete: true)
                .Index(t => t.Location_ID)
                .Index(t => t.Festival_ID);
            
            CreateTable(
                "dbo.Organisaton",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Name = c.String(),
                        Comment = c.String(),
                        Tel = c.String(),
                        Acces = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.ArtistOrGroup",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        ArtistName = c.String(),
                        Image = c.Binary(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Executor", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Movie",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        MovieName = c.String(),
                        Director = c.String(),
                        PublishYear = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Executor", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Manager",
                c => new
                    {
                        ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.ID)
                .Index(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Manager", "ID", "dbo.User");
            DropForeignKey("dbo.Movie", "ID", "dbo.Executor");
            DropForeignKey("dbo.ArtistOrGroup", "ID", "dbo.Executor");
            DropForeignKey("dbo.Organisaton", "ID", "dbo.User");
            DropForeignKey("dbo.Actor", "Movie_ID", "dbo.Movie");
            DropForeignKey("dbo.Ticket", "VisitorID", "dbo.Visitor");
            DropForeignKey("dbo.Ticket", "ShowID", "dbo.Show");
            DropForeignKey("dbo.Show", "FestivalID", "dbo.Festival");
            DropForeignKey("dbo.Picture", "Festival_ID", "dbo.Festival");
            DropForeignKey("dbo.Festival", "OrganisationID", "dbo.Organisaton");
            DropForeignKey("dbo.Show", "RoomID", "dbo.Room");
            DropForeignKey("dbo.Room", "LocationID", "dbo.Location");
            DropForeignKey("dbo.LocationFestival", "Festival_ID", "dbo.Festival");
            DropForeignKey("dbo.LocationFestival", "Location_ID", "dbo.Location");
            DropForeignKey("dbo.FestivalDateFestival", "Festival_ID", "dbo.Festival");
            DropForeignKey("dbo.FestivalDateFestival", "FestivalDate_ID", "dbo.FestivalDate");
            DropForeignKey("dbo.Show", "ExecutorID", "dbo.Executor");
            DropIndex("dbo.Manager", new[] { "ID" });
            DropIndex("dbo.Movie", new[] { "ID" });
            DropIndex("dbo.ArtistOrGroup", new[] { "ID" });
            DropIndex("dbo.Organisaton", new[] { "ID" });
            DropIndex("dbo.LocationFestival", new[] { "Festival_ID" });
            DropIndex("dbo.LocationFestival", new[] { "Location_ID" });
            DropIndex("dbo.FestivalDateFestival", new[] { "Festival_ID" });
            DropIndex("dbo.FestivalDateFestival", new[] { "FestivalDate_ID" });
            DropIndex("dbo.Ticket", new[] { "ShowID" });
            DropIndex("dbo.Ticket", new[] { "VisitorID" });
            DropIndex("dbo.Picture", new[] { "Festival_ID" });
            DropIndex("dbo.Room", new[] { "LocationID" });
            DropIndex("dbo.Festival", new[] { "OrganisationID" });
            DropIndex("dbo.Show", new[] { "FestivalID" });
            DropIndex("dbo.Show", new[] { "RoomID" });
            DropIndex("dbo.Show", new[] { "ExecutorID" });
            DropIndex("dbo.Actor", new[] { "Movie_ID" });
            DropTable("dbo.Manager");
            DropTable("dbo.Movie");
            DropTable("dbo.ArtistOrGroup");
            DropTable("dbo.Organisaton");
            DropTable("dbo.LocationFestival");
            DropTable("dbo.FestivalDateFestival");
            DropTable("dbo.Visitor");
            DropTable("dbo.Ticket");
            DropTable("dbo.Picture");
            DropTable("dbo.User");
            DropTable("dbo.Room");
            DropTable("dbo.Location");
            DropTable("dbo.FestivalDate");
            DropTable("dbo.Festival");
            DropTable("dbo.Show");
            DropTable("dbo.Executor");
            DropTable("dbo.Actor");
        }
    }
}
