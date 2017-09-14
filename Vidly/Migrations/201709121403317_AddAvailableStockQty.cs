namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAvailableStockQty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "AvailableStockQty", c => c.Int(nullable: false));

            Sql(@"
                   UPDATE Movies INSERT INTO AvailableStockQty = StockQty
                ");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "AvailableStockQty");
        }
    }
}
