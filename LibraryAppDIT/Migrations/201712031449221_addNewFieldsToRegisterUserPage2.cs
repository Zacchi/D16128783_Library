namespace LibraryAppDIT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNewFieldsToRegisterUserPage2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "MemberNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "MemberNumber", c => c.String());
        }
    }
}
