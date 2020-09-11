namespace LibraryMVC.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeOfRecommend : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BorrowedBooksViewModels", "CustomersViewModel_Id", "dbo.CustomersViewModels");
            DropIndex("dbo.BorrowedBooksViewModels", new[] { "CustomersViewModel_Id" });
            AddColumn("dbo.Customers", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Customers", "FirstName", c => c.String());
            AlterColumn("dbo.Customers", "LastName", c => c.String());
            AlterColumn("dbo.Customers", "Email", c => c.String());
            AlterColumn("dbo.Customers", "Street", c => c.String());
            AlterColumn("dbo.Customers", "City", c => c.String());
            AlterColumn("dbo.Customers", "PostCode", c => c.String());
            DropColumn("dbo.Books", "NumberOfBooks");
            DropColumn("dbo.Customers", "Phone");
            DropTable("dbo.CustomersViewModels");
            DropTable("dbo.BorrowedBooksViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BorrowedBooksViewModels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Borrowed = c.Boolean(nullable: false),
                        CustomersViewModel_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomersViewModels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Street = c.String(nullable: false),
                        City = c.String(nullable: false),
                        County = c.String(),
                        PostCode = c.String(nullable: false),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "Phone", c => c.String());
            AddColumn("dbo.Books", "NumberOfBooks", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "PostCode", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Street", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "FirstName", c => c.String(nullable: false));
            DropColumn("dbo.Customers", "PhoneNumber");
            CreateIndex("dbo.BorrowedBooksViewModels", "CustomersViewModel_Id");
            AddForeignKey("dbo.BorrowedBooksViewModels", "CustomersViewModel_Id", "dbo.CustomersViewModels", "Id");
        }
    }
}
