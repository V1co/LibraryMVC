using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMVC.Core.Models
{
    public class Book : BaseEntity
    {
        [StringLength(30)]
        [DisplayName("Book Title")]
        public String title { get; set; }
        public String writerFirstName { get; set; }
        public String writerLastName { get; set; }
        public DateTime releaseDate { get; set; }
        public String publisher { get; set; }
        public int numberOfBooks { get; set; }
        public String genre { get; set; }
        public List<Format> formats { get; set; }
        public String description { get; set; }
        public static int count { get; set; }

        public Book()
        {

        }
    }
}
