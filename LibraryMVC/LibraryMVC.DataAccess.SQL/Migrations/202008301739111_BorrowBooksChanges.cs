namespace LibraryMVC.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BorrowBooksChanges : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.CustomerToBooks", new[] { "Book_Id" });
            DropIndex("dbo.CustomerToBooks", new[] { "Customer_Id" });
            DropColumn("dbo.CustomerToBooks", "BookId");
            DropColumn("dbo.CustomerToBooks", "CustomerId");
            RenameColumn(table: "dbo.CustomerToBooks", name: "Book_Id", newName: "BookId");
            RenameColumn(table: "dbo.CustomerToBooks", name: "Customer_Id", newName: "CustomerId");
            AlterColumn("dbo.CustomerToBooks", "CustomerId", c => c.String(maxLength: 128));
            AlterColumn("dbo.CustomerToBooks", "BookId", c => c.String(maxLength: 128));
            CreateIndex("dbo.CustomerToBooks", "CustomerId");
            CreateIndex("dbo.CustomerToBooks", "BookId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.CustomerToBooks", new[] { "BookId" });
            DropIndex("dbo.CustomerToBooks", new[] { "CustomerId" });
            AlterColumn("dbo.CustomerToBooks", "BookId", c => c.Int(nullable: false));
            AlterColumn("dbo.CustomerToBooks", "CustomerId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.CustomerToBooks", name: "CustomerId", newName: "Customer_Id");
            RenameColumn(table: "dbo.CustomerToBooks", name: "BookId", newName: "Book_Id");
            AddColumn("dbo.CustomerToBooks", "CustomerId", c => c.Int(nullable: false));
            AddColumn("dbo.CustomerToBooks", "BookId", c => c.Int(nullable: false));
            CreateIndex("dbo.CustomerToBooks", "Customer_Id");
            CreateIndex("dbo.CustomerToBooks", "Book_Id");
        }
    }
}
