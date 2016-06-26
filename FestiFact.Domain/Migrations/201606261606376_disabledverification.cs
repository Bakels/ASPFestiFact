namespace FestivalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class disabledverification : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Festival", "Name", c => c.String());
            AlterColumn("dbo.Festival", "Description", c => c.String());
            AlterColumn("dbo.Festival", "Type", c => c.String());
            AlterColumn("dbo.Festival", "Genre", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Festival", "Genre", c => c.String(nullable: false));
            AlterColumn("dbo.Festival", "Type", c => c.String(nullable: false));
            AlterColumn("dbo.Festival", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Festival", "Name", c => c.String(nullable: false));
        }
    }
}
