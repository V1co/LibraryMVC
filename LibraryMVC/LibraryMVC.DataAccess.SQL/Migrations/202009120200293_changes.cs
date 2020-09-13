namespace LibraryMVC.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "Title", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Books", "WriterFirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "WriterLastName", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "Genre", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "Format", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "Description", c => c.String());
            AlterColumn("dbo.Books", "Format", c => c.String());
            AlterColumn("dbo.Books", "Genre", c => c.String());
            AlterColumn("dbo.Books", "WriterLastName", c => c.String());
            AlterColumn("dbo.Books", "WriterFirstName", c => c.String());
            AlterColumn("dbo.Books", "Title", c => c.String(maxLength: 30));
        }
    }
}
