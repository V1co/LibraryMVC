namespace LibraryMVC.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewIdeaBorrowBook : DbMigration
    {
        public override void Up()
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BorrowBooks");
        }
    }
}
