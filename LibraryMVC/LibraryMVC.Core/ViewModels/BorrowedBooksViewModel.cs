﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMVC.Core.ViewModels
{
    public class BorrowedBooksViewModel
    {
        public string BorrowedBookId { get; set; }
        public string BookId { get; set; }
        public string Title { get; set; }
        public string UserName { get; set; }
    }
}
