using LibraryMVC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMVC.Core.ViewModels
{
    public class BookListViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        //public IEnumerable<BookFormat> BookFormats { get; set; }
        public IEnumerable<BookGenre> BookGenres { get; set; }
    }
}
