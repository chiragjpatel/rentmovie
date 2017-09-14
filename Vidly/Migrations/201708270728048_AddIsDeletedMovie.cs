namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddIsDeletedMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "IsDeleted", c => c.Boolean(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Movies", "IsDeleted");
        }
    }
}
