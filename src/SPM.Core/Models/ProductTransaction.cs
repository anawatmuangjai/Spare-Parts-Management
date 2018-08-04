using System;
using System.Collections.Generic;

namespace SPM.Core.Models
{
    public partial class ProductTransaction
    {
        public int TransactionId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string TransectionType { get; set; }
        public DateTime TransactionDate { get; set; }

        public Product Product { get; set; }
    }
}
