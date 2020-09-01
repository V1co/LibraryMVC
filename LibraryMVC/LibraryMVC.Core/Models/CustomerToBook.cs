using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMVC.Core.Models
{
    public class CustomerToBook
    {
        public int CustomerToBookId { get; set; }
        public string CustomerId { get; set; }
        public string BookId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Book Book { get; set; }

    }
}
