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
        [DisplayName("Writer First Name")]
        public String WriterFirstName { get; set; }
        [DisplayName("Writer Last Name")]
        public String WriterLastName { get; set; }
        [DisplayName("Released")]
        public DateTime ReleaseDate { get; set; }
        [DisplayName("Publisher")]
        public String Publisher { get; set; }
        [DisplayName("Number of Books")]
        public int NumberOfBooks { get; set; }
        public String Genre { get; set; }
        public String Format { get; set; }
        public String Description { get; set; }
        public String Image { get; set; }
        public static int Count { get; set; }

        public Book()
        {
            
        }
    }
}
