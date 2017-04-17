namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteGenreFromBook : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Books", "genre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "genre", c => c.String());
        }
    }
}
