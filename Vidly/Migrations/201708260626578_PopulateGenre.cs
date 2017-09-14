namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(Name) VALUES('Action')");
            Sql("INSERT INTO Genres(Name) VALUES('Comedy')");
            Sql("INSERT INTO Genres(Name) VALUES('Horror')");
            Sql("INSERT INTO Genres(Name) VALUES('Drama')");
            Sql("INSERT INTO Genres(Name) VALUES('Sci/Fic')");
            Sql("INSERT INTO Genres(Name) VALUES('Bollywood')");

        }

        public override void Down()
        {
        }
    }
}
