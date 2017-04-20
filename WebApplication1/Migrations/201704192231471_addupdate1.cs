namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addupdate1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "ReleaseDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "ReleaseDate", c => c.DateTime());
        }
    }
}
