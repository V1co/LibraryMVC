﻿using System.Collections.Generic;
using System.ComponentModel;

namespace LibraryMVC.Core.ViewModels
{
    public class CustomersViewModel
    {
        public string CustomerId { get; set; }
        [DisplayName("Last Name")]
        public string CustomerName { get; set; }
        [DisplayName("First Name")]
        public string CustomerFirstName { get; set; }
        public List<BorrowedBooksViewModel> BorrowedBooks { get; set; }
    }
}
