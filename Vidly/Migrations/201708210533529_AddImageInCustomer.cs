namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageInCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "ImageUrl");
        }
    }
}
