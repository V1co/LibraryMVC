namespace LibraryMVC.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Books", "NumberOfBooks");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "NumberOfBooks", c => c.Int(nullable: false));
        }
    }
}
