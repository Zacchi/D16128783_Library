namespace LibraryAppDIT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNewFieldsToRegisterUserPage4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegisterViewModels", "Phone", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegisterViewModels", "Phone");
        }
    }
}
