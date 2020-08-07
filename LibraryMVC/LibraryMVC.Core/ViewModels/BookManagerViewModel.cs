using LibraryMVC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMVC.Core.ViewModels
{
    public class BookManagerViewModel
    {
        public Book Book { get; set; }
        public IEnumerable<BookFormat> Formats { get; set; }
        public IEnumerable<BookGenre> Genres { get; set; }
    }
}
