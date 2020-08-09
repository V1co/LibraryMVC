namespace LibraryMVC.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Title = c.String(maxLength: 30),
                        WriterFirstName = c.String(),
                        WriterLastName = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        Publisher = c.String(),
                        NumberOfBooks = c.Int(nullable: false),
                        Genre = c.String(),
                        Format = c.String(),
                        Description = c.String(),
                        Image = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BookFormats",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Format = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BookGenres",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Genre = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BookGenres");
            DropTable("dbo.BookFormats");
            DropTable("dbo.Books");
        }
    }
}
