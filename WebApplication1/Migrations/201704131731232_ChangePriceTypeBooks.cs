namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePriceTypeBooks : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "price", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "price", c => c.String());
        }
    }
}
