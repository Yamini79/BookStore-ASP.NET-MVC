namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReleaseAddDateAvailCopiestoBooks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Books", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Books", "AvailCopies", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "AvailCopies");
            DropColumn("dbo.Books", "DateAdded");
            DropColumn("dbo.Books", "ReleaseDate");
        }
    }
}
