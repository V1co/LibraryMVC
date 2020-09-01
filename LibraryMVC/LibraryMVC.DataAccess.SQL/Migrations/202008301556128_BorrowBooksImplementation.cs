namespace LibraryMVC.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BorrowBooksImplementation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Books", new[] { "Customer_Id" });
            CreateTable(
                "dbo.CustomerToBooks",
                c => new
                    {
                        CustomerToBookId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                        Book_Id = c.String(maxLength: 128),
                        Customer_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CustomerToBookId)
                .ForeignKey("dbo.Books", t => t.Book_Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .Index(t => t.Book_Id)
                .Index(t => t.Customer_Id);
            
            DropColumn("dbo.Books", "Customer_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Customer_Id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.CustomerToBooks", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.CustomerToBooks", "Book_Id", "dbo.Books");
            DropIndex("dbo.CustomerToBooks", new[] { "Customer_Id" });
            DropIndex("dbo.CustomerToBooks", new[] { "Book_Id" });
            DropTable("dbo.CustomerToBooks");
            CreateIndex("dbo.Books", "Customer_Id");
            AddForeignKey("dbo.Books", "Customer_Id", "dbo.Customers", "Id");
        }
    }
}
