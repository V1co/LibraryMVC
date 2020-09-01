using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMVC.Core.ViewModels
{
    public class CustomersViewModel
    {
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerFirstName { get; set; }
        public List<BorrowedBooksViewModel> BorrowedBooks { get; set; }
    }
}
