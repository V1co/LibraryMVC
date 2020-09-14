using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibraryMVC.Core.Models
{
    public class Book : BaseEntity
    {
        [Required]
        [StringLength(30)]
        [DisplayName("Book Title")]
        public String Title { get; set; }
        [Required]
        [DisplayName("Writer First Name")]
        public String WriterFirstName { get; set; }
        [Required]
        [DisplayName("Writer Last Name")]
        public String WriterLastName { get; set; }
        [DisplayName("Released")]
        public DateTime ReleaseDate { get; set; }
        [DisplayName("Publisher")]
        public String Publisher { get; set; }
        [Required]
        public String Genre { get; set; }
        [Required]
        public String Format { get; set; }
        [Required]
        public String Description { get; set; }
        public String Image { get; set; }
        [DisplayName("Number of borrows")]
        public int NumberOfBorrows { get; set; }
        public virtual ICollection<CustomerToBook> CustomersToBooks { get; set; }
        public Book()
        {
        }
    }
}
