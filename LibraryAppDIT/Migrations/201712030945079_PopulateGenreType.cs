namespace LibraryAppDIT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreType : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT GenreTypes ON");
            Sql("INSERT INTO GenreTypes (Id, Name) VALUES (1, 'Comedy')");
            Sql("INSERT INTO GenreTypes (Id, Name) VALUES (2, 'Drama')");
            Sql("INSERT INTO GenreTypes (Id, Name) VALUES (3, 'Horror')");
            Sql("INSERT INTO GenreTypes (Id, Name) VALUES (4, 'Romance')");
            Sql("INSERT INTO GenreTypes (Id, Name) VALUES (5, 'Tragedy')");
            Sql("INSERT INTO GenreTypes (Id, Name) VALUES (6, 'Mythology')");
            Sql("INSERT INTO GenreTypes (Id, Name) VALUES (7, 'Adventure')");
            Sql("INSERT INTO GenreTypes (Id, Name) VALUES (8, 'Fairy Tale')");
            Sql("INSERT INTO GenreTypes (Id, Name) VALUES (9, 'OTher')");
            Sql("SET IDENTITY_INSERT GenreTypes OFF");
        }
        
        public override void Down()
        {
        }
    }
}
