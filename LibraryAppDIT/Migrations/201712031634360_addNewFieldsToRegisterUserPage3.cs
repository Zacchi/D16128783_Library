namespace LibraryAppDIT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNewFieldsToRegisterUserPage3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RegisterViewModels",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        Address = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 100),
                        ConfirmPassword = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RegisterViewModels");
        }
    }
}
