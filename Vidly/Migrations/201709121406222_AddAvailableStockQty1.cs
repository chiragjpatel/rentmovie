namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddAvailableStockQty1 : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                   UPDATE Movies SET AvailableStockQty = StockQty
                ");
        }

        public override void Down()
        {
        }
    }
}
