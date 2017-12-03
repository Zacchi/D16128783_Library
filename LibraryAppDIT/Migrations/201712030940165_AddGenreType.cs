namespace LibraryAppDIT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GenreTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Books", "GenreTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Books", "GenreTypeId");
            AddForeignKey("dbo.Books", "GenreTypeId", "dbo.GenreTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.Books", "Genre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Genre", c => c.String());
            DropForeignKey("dbo.Books", "GenreTypeId", "dbo.GenreTypes");
            DropIndex("dbo.Books", new[] { "GenreTypeId" });
            DropColumn("dbo.Books", "GenreTypeId");
            DropTable("dbo.GenreTypes");
        }
    }
}
