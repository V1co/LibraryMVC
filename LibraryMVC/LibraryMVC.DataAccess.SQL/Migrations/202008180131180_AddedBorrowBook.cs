namespace LibraryMVC.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBorrowBook : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Borrows", t => t.BorrowId)
                .Index(t => t.BorrowId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BorrowBooks", "BorrowId", "dbo.Borrows");
            DropIndex("dbo.BorrowBooks", new[] { "BorrowId" });
            DropTable("dbo.BorrowBooks");
            DropTable("dbo.Borrows");
        }
    }
}
