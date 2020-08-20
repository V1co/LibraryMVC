using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMVC.Core.Models
{
    public class Borrow : BaseEntity
    {
        public Borrow()
        {
            this.BorrowBooks = new List<BorrowBook>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
        public string BorrowStatus { get; set; }
        public virtual ICollection<BorrowBook> BorrowBooks { get; set; }
    }
}
