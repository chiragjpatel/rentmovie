namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsDeletedIsNotNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "IsDeleted", c => c.Boolean());
        }
    }
}
