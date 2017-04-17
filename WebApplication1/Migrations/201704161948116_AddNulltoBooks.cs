namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNulltoBooks : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "price", c => c.Single());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "price", c => c.Single(nullable: false));
        }
    }
}
