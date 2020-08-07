using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMVC.Core.Models
{
    public class BookGenre : BaseEntity
    {
        //[DisplayName("Genre Name")]
        public String Genre { get; set; }

        public BookGenre()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
