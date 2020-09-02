namespace LibraryMVC.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FurtherBorrowImprovements : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerToBooks", "Customer", c => c.String());
            AddColumn("dbo.CustomerToBooks", "Book", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerToBooks", "Book");
            DropColumn("dbo.CustomerToBooks", "Customer");
        }
    }
}
