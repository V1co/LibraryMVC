namespace LibraryMVC.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BorrowingLogic : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BorrowBooks", "BorrowId", "dbo.Borrows");
            DropIndex("dbo.BorrowBooks", new[] { "BorrowId" });
            AddColumn("dbo.Books", "Customer_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Books", "Customer_Id");
            AddForeignKey("dbo.Books", "Customer_Id", "dbo.Customers", "Id");
            DropTable("dbo.Borrows");
            DropTable("dbo.BorrowBooks");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BorrowBooks",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        BorrowId = c.String(maxLength: 128),
                        BookId = c.String(),
                        BookTitle = c.String(),
                        Image = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Borrows",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Street = c.String(),
                        City = c.String(),
                        County = c.String(),
                        PostCode = c.String(),
                        BorrowStatus = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Books", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Books", new[] { "Customer_Id" });
            DropColumn("dbo.Books", "Customer_Id");
            CreateIndex("dbo.BorrowBooks", "BorrowId");
            AddForeignKey("dbo.BorrowBooks", "BorrowId", "dbo.Borrows", "Id");
        }
    }
}
