namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO[dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'3f6babe9-63ae-4fb8-a78c-db55a6926b0b', N'admin@vidly.com', 0, N'AN6q5os0vT9IXeFcyfkjivx8/vlCstDzVzLTH5zJfUzqMCoEmMXO8LE9qicE7NVZxA==', N'0e9e9538-c961-401f-ac3c-4db242d258f8', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
            INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'766c1801-f21c-46fc-ac15-544cc0007476', N'chir_pat@hotmail.com', 0, N'AAykzt3o81/xRsrgHws1fBYR5LWYgCUifefOCkl+vSfVyE4hPQl888G2vMqz+IE3NQ==', N'bdad5c7d-f74b-4153-856b-ede6952f6c09', NULL, 0, 0, NULL, 1, 0, N'chir_pat@hotmail.com')
            INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'c565d0e1-9055-47b5-9a4b-af80c9517546', N'guest@vidly.com', 0, N'AN8Kq1Y59jvKcPvbJs1q9Tw9n0IUcfkY/UsGWDHJRSEjSSpf0IUSmm98ti0szd1wcw==', N'74c5e331-2f6b-471f-8d2f-36574e89be42', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'7f4a6d35-7ca9-4dd5-82a2-905b40e9bd11', N'CanManageMovies')
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3f6babe9-63ae-4fb8-a78c-db55a6926b0b', N'7f4a6d35-7ca9-4dd5-82a2-905b40e9bd11')



                ");
        }

        public override void Down()
        {
        }
    }
}
