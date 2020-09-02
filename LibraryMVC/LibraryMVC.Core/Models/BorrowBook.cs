using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMVC.Core.Models
{
    public class BorrowBook
    {
        public string BorrowBookId { get; set; }
        public string BookId { get; set; }
        public string UserName { get; set; }
    }
}
