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
        public String Title { get; set; }
        public String WriterFirstName { get; set; }
        public String WriterLastName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public String Publisher { get; set; }
        public int NumberOfBooks { get; set; }
        public String Genre { get; set; }
        public List<Format> Formats { get; set; }
        public String Description { get; set; }
        public String Image { get; set; }
        public static int Count { get; set; }

        public Book()
        {

        }
    }
}
