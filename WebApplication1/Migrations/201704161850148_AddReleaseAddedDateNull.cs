namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReleaseAddedDateNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "ReleaseDate", c => c.DateTime());
            AlterColumn("dbo.Books", "DateAdded", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "DateAdded", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Books", "ReleaseDate", c => c.DateTime(nullable: false));
        }
    }
}
