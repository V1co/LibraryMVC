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
        [Required]
        [DisplayName("Book Title")]
        public String Title { get; set; }
        [DisplayName("Writer First Name")]
        [Required]
        public String WriterFirstName { get; set; }
        [DisplayName("Writer Last Name")]
        [Required]
        public String WriterLastName { get; set; }
        [DisplayName("Release Date")]
        [Required]
        public DateTime ReleaseDate { get; set; }
        [DisplayName("Publisher")]
        [Required]
        public String Publisher { get; set; }
        [DisplayName("Number of Books")]
        [Required]
        public int NumberOfBooks { get; set; }
        [Required]
        public String Genre { get; set; }
        //[Required] trzeba stworzyc formaty
        public List<Format> Formats { get; set; }
        [Required]
        public String Description { get; set; }
        
        public String Image { get; set; }
        public static int Count { get; set; }

        public Book()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
