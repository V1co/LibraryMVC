namespace LibraryMVC.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refresh : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CustomerToBooks", "Customer");
            DropColumn("dbo.CustomerToBooks", "Book");
            DropTable("dbo.BorrowBooks");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BorrowBooks",
                c => new
                    {
                        BorrowBookId = c.String(nullable: false, maxLength: 128),
                        BookId = c.String(),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.BorrowBookId);
            
            AddColumn("dbo.CustomerToBooks", "Book", c => c.String());
            AddColumn("dbo.CustomerToBooks", "Customer", c => c.String());
        }
    }
}
