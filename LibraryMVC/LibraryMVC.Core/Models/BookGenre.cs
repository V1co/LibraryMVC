using System;
using System.ComponentModel;

namespace LibraryMVC.Core.Models
{
    public class BookGenre : BaseEntity
    {
        [DisplayName("Genre Name")]
        public String Genre { get; set; }

    }
}
