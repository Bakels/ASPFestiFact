namespace FestivalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditPicture : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Picture", "Festival_ID", "dbo.Festival");
            DropIndex("dbo.Picture", new[] { "Festival_ID" });
            CreateTable(
                "dbo.PictureFestival",
                c => new
                    {
                        Picture_ID = c.Int(nullable: false),
                        Festival_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Picture_ID, t.Festival_ID })
                .ForeignKey("dbo.Picture", t => t.Picture_ID, cascadeDelete: true)
                .ForeignKey("dbo.Festival", t => t.Festival_ID, cascadeDelete: true)
                .Index(t => t.Picture_ID)
                .Index(t => t.Festival_ID);
            
            DropColumn("dbo.Picture", "Festival_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Picture", "Festival_ID", c => c.Int());
            DropForeignKey("dbo.PictureFestival", "Festival_ID", "dbo.Festival");
            DropForeignKey("dbo.PictureFestival", "Picture_ID", "dbo.Picture");
            DropIndex("dbo.PictureFestival", new[] { "Festival_ID" });
            DropIndex("dbo.PictureFestival", new[] { "Picture_ID" });
            DropTable("dbo.PictureFestival");
            CreateIndex("dbo.Picture", "Festival_ID");
            AddForeignKey("dbo.Picture", "Festival_ID", "dbo.Festival", "ID");
        }
    }
}
