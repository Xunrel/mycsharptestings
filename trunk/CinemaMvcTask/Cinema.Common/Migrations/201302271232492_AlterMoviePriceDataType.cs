namespace CinemaCommon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterMoviePriceDataType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Movies", "Price", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("Movies", "Price", c => c.Decimal());
        }
    }
}
