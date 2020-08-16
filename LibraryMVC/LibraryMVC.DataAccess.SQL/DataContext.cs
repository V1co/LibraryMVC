using LibraryMVC.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMVC.DataAccess.SQL
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("DefaultConnection") {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookGenre> Genres { get; set; }
        public DbSet<BookFormat> Formats { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
