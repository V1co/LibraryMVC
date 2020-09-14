using LibraryMVC.Core.Models;
using System.Collections.Generic;

namespace LibraryMVC.Core.ViewModels
{
    public class BookListViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<BookFormat> BookFormats { get; set; }
        public IEnumerable<BookGenre> BookGenres { get; set; }
    }
}
