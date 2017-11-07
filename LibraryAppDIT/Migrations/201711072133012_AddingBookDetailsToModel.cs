namespace LibraryAppDIT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingBookDetailsToModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        ISBN = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Genre = c.String(),
                        Author = c.String(),
                        publishedYear = c.String(),
                    })
                .PrimaryKey(t => t.ISBN);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Books");
        }
    }
}
