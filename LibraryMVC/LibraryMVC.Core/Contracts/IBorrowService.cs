using LibraryMVC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMVC.Core.Contracts
{
    public interface IBorrowService
    {
        void CreateBorrow(Borrow Borrow);
    }
}
