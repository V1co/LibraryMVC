using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMVC.Core.Models
{
    public class BorrowBook : BaseEntity
    {
        public string BorrowId { get; set; }
        public string BookId { get; set; }
        public string BookTitle { get; set; }
        public string Image { get; set; }
    }
}
