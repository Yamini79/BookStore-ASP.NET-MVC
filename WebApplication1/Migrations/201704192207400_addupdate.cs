namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addupdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "bname", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "bname", c => c.String());
        }
    }
}
