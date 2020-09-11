namespace LibraryMVC.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NumberOfBorrows : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "NumberOfBorrows", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "NumberOfBorrows");
        }
    }
}
