using LibraryMVC.Core.Models;
using System.Data.Entity;

namespace LibraryMVC.DataAccess.SQL
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookGenre> Genres { get; set; }
        public DbSet<BookFormat> Formats { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerToBook> CustomersToBooks { get; set; }

    }
}
