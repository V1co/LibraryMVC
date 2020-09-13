namespace LibraryMVC.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "NumberOfBorrows", c => c.Int(nullable: false));
            DropColumn("dbo.Books", "Availability");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Availability", c => c.Boolean(nullable: false));
            DropColumn("dbo.Books", "NumberOfBorrows");
        }
    }
}
