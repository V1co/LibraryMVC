﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMVC.Core.Models
{
    public class Customer: BaseEntity
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
        public virtual ICollection<CustomerToBook> CustomersToBooks { get; set; }
        public Customer() {
        }
    }
}
