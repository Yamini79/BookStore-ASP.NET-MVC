namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Genres ON");
            Sql("INSERT INTO Genres (Id, Type ) VALUES (1,'Romance')");
            Sql("INSERT INTO Genres (Id, Type ) VALUES (2,'Horror')");
            Sql("INSERT INTO Genres (Id, Type ) VALUES (3,'Mystery')");
            Sql("INSERT INTO Genres (Id, Type ) VALUES (4,'Drama')");
            Sql("INSERT INTO Genres (Id, Type ) VALUES (5,'Thriller')");
            Sql("SET IDENTITY_INSERT Genres OFF");
        }
        
        public override void Down()
        {
        }
    }
}
