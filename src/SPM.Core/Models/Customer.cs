using System;
using System.Collections.Generic;

namespace SPM.Core.Models
{
    public partial class Customer
    {
        public Customer()
        {
            SalesOrder = new HashSet<SalesOrder>();
        }

        public int CustomerId { get; set; }
        public int PersonId { get; set; }
        public DateTime ModifyDate { get; set; }

        public Person Person { get; set; }
        public ICollection<SalesOrder> SalesOrder { get; set; }
    }
}
