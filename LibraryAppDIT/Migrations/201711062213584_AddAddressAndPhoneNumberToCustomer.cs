namespace LibraryAppDIT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAddressAndPhoneNumberToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Address", c => c.String());
            AddColumn("dbo.Customers", "PhoneNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "PhoneNumber");
            DropColumn("dbo.Customers", "Address");
        }
    }
}
