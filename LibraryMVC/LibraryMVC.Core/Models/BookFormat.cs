using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMVC.Core.Models
{
    public class BookFormat : BaseEntity
    {
        //[DisplayName("Format Name")]
        public String Format { get; set; }

        public BookFormat()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
