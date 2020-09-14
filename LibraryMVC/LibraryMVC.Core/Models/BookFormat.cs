using System;
using System.ComponentModel;

namespace LibraryMVC.Core.Models
{
    public class BookFormat : BaseEntity
    {
        [DisplayName("Format Name")]
        public String Format { get; set; }

    }
}
