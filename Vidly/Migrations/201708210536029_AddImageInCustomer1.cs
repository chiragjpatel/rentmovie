namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddImageInCustomer1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Image", c => c.Binary(null));
        }

        public override void Down()
        {
            DropColumn("dbo.Customers", "Image");
        }
    }
}
