namespace LibraryAppDIT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3ac5f458-a751-4f0d-a9f6-5004c83afc73', N'admin@vzlibrary.com', 0, N'AHBLs1g5nJVLBpRPzG0GjVnSlHZm+XwtbVCcVMTtzNRWE3Kr7paB6bFX78Bfck+prQ==', N'fb34f850-671c-45b9-a97e-34c59af48c38', NULL, 0, 0, NULL, 1, 0, N'admin@vzlibrary.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'793795c9-066b-4c85-9b89-00d3d4c2cb7f', N'staff@vzlibrary.com', 0, N'AKrclygmvI0j6MvRoxO4Df6MibpSerluo6gWwa72ePKwgWSdTgPOuvwnboyLLPjAtg==', N'bcce1619-2215-448f-9fae-c3cf27b05cb4', NULL, 0, 0, NULL, 1, 0, N'staff@vzlibrary.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'87b84fb8-4389-4def-b0c4-1db7e95cba2a', N'StoreManager')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3ac5f458-a751-4f0d-a9f6-5004c83afc73', N'87b84fb8-4389-4def-b0c4-1db7e95cba2a')

");

        }
        
        public override void Down()
        {
        }
    }
}
