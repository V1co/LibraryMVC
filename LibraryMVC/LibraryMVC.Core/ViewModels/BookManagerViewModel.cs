using LibraryMVC.Core.Models;
using System.Collections.Generic;

namespace LibraryMVC.Core.ViewModels
{
    public class BookManagerViewModel
    {
        public Book Book { get; set; }
        public IEnumerable<BookFormat> Formats { get; set; }
        public IEnumerable<BookGenre> Genres { get; set; }
    }
}
